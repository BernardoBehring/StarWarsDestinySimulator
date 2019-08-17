using GraphQL.Types;

namespace StarWarsDestiny.API.Graph.Types
{
    public class CardTypeGraphType : ObjectGraphType<Model.CardType>
    {
        public CardTypeGraphType()
        {
            Name = "CardTypeGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.CardId, false, typeof(IntGraphType));
            Field(x => x.TypeId, false, typeof(IntGraphType));

            Field(x => x.Type, true, typeof(TypeGraphType));
            Field(x => x.Card, true, typeof(CardGraphType));
        }
    }
}
