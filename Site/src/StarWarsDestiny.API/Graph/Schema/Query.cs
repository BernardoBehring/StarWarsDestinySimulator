using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using StarWarsDestiny.API.Graph.Types;
using StarWarsDestiny.API.Graph.Types.Filters;
using StarWarsDestiny.Model.Dto;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.API.Graph.Schema
{
    public class Query : ObjectGraphType
    {
        private readonly ICardService _cardService;

        public Query(ICardService cardService)
        {
            FieldAsync<ListGraphType<CardGraphType>>("cards", "Query to all cards", ArgumentsListCard(), ResolveList);
            _cardService = cardService;
        }

        private QueryArguments ArgumentsListCard()
        {
            return new QueryArguments(new List<QueryArgument>
            {
                new QueryArgument<CardFilterGraphType>
                {
                    Name = "filter"
                }                
            });
        }

        private async Task<object> ResolveList(ResolveFieldContext<object> context)
        {
            var filter = context.GetArgument<CardFilter>("filter");
            
            var fields = GetExpandableFields(ResolveFields(context));

            return await _cardService.GetAllWithCardFilter(filter, fields.ToArray());
        }

        private static string[] ResolveFields<TSource>(ResolveFieldContext<TSource> context)
        {
            if (context.SubFields == default)
                return Array.Empty<string>();

            var items = new Collection<string>();

            ResolveForSubFields(context, items);

            return items.ToArray();
        }

        private static void ResolveForSubFields<TSource>(ResolveFieldContext<TSource> context, Collection<string> items)
        {
            foreach (var (fieldName, fieldValue) in context.SubFields.Select(x => (x.Key, x.Value)))
            {
                items.Add(fieldName.ToPascalCase());
                Resolve(items, $"{fieldName}.", fieldValue);
            }
        }

        private static void Resolve(ICollection<string> items, string parent, INode nodes)
        {
            foreach (var node in nodes.Children)
            {
                switch (node)
                {
                    case SelectionSet selectionSet:
                        Resolve(items, parent, selectionSet);
                        break;
                    case Field field:
                        var name = $"{parent.ToPascalCase()}{field.Name.ToPascalCase()}";
                        items.Add(name);
                        Resolve(items, $"{name}.", node);
                        break;
                }
            }
        }
        
        private IEnumerable<string> GetExpandableFields(IEnumerable<string> fields)
        {
            if (fields == null) yield break;

            foreach (var field in fields?.Where(x => !string.IsNullOrWhiteSpace(x) && x.Contains('.')))
            {
                var subFields = field.Split('.');
                yield return string.Join(".", subFields.Take(subFields.Length - 1));
            }
        }
    }
}
