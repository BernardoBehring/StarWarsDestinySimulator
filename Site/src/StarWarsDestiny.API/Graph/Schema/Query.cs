using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using StarWarsDestiny.API.Graph.Types;
using StarWarsDestiny.API.Graph.Types.Filters;
using StarWarsDestiny.Common.Util.Extensions;
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
            
            var fields = context.GetExpandableFields();

            return await _cardService.GetAllWithCardFilter(filter, fields.ToArray());
        }
    }
}
