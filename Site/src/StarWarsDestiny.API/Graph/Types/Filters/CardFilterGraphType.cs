using GraphQL.Types;
using StarWarsDestiny.Model.Dto;

namespace StarWarsDestiny.API.Graph.Types.Filters
{
    public class CardFilterGraphType : InputObjectGraphType<CardFilter>
    {
        public CardFilterGraphType()
        {
            Name = "CardFilterGraphType";

            Field(x => x.Id, true, typeof(IntGraphType));
            Field(x => x.Name, true, typeof(StringGraphType));
            Field(x => x.Subtitle, true, typeof(StringGraphType));
            Field(x => x.Text, true, typeof(StringGraphType));
            Field(x => x.Number, true, typeof(IntGraphType));
            Field(x => x.ArtistId, true, typeof(IntGraphType));
            Field(x => x.AffiliationId, true, typeof(IntGraphType));
            Field(x => x.FactionId, true, typeof(IntGraphType));
            Field(x => x.ColorId, true, typeof(IntGraphType));
            Field(x => x.RarityId, true, typeof(IntGraphType));
            Field(x => x.SetStarWarsId, true, typeof(IntGraphType));
            Field(x => x.Points, true, typeof(IntGraphType));
            Field(x => x.ElitePoints, true, typeof(IntGraphType));
            Field(x => x.Health, true, typeof(IntGraphType));
            Field(x => x.Cost, true, typeof(IntGraphType));
            Field(x => x.IsCharacter, true, typeof(BooleanGraphType));
            Field(x => x.IsSuport, true, typeof(BooleanGraphType));
            Field(x => x.IsUpgrade, true, typeof(BooleanGraphType));
            Field(x => x.IsUnique, true, typeof(BooleanGraphType));
        }
    }
}
