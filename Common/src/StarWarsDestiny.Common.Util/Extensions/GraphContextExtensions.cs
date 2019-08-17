using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarWarsDestiny.Common.Util.Extensions
{
    public static class GraphContextExtensions
    {
        private static string[] ResolveFields<TSource>(this ResolveFieldContext<TSource> context)
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

        public static IEnumerable<string> GetExpandableFields<TSource>(this ResolveFieldContext<TSource> context)
        {
            var fields = context.ResolveFields();

            if (fields == null) yield break;

            foreach (var field in fields?.Where(x => !string.IsNullOrWhiteSpace(x) && x.Contains('.')))
            {
                var subFields = field.Split('.');
                yield return string.Join(".", subFields.Take(subFields.Length - 1));
            }
        }
    }
}
