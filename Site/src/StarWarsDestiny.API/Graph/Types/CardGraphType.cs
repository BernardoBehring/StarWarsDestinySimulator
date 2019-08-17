using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class CardGraphType : ObjectGraphType<Card>
    {
        public CardGraphType()
        {
            Name = "CardGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, true, typeof(StringGraphType));
            Field(x => x.Subtitle, true, typeof(StringGraphType));
            Field(x => x.Text, true, typeof(StringGraphType));
            Field(x => x.Number, false, typeof(IntGraphType));
            Field(x => x.ArtistId, true, typeof(IntGraphType));
            Field(x => x.AffiliationId, false, typeof(IntGraphType));
            Field(x => x.FactionId, false, typeof(IntGraphType));
            Field(x => x.ColorId, false, typeof(IntGraphType));
            Field(x => x.RarityId, false, typeof(IntGraphType));
            Field(x => x.DieId, true, typeof(IntGraphType));
            Field(x => x.SetStarWarsId, false, typeof(IntGraphType));
            Field(x => x.Points, true, typeof(IntGraphType));
            Field(x => x.ElitePoints, true, typeof(IntGraphType));
            Field(x => x.Health, true, typeof(IntGraphType));
            Field(x => x.Cost, true, typeof(IntGraphType));
            Field(x => x.IsCharacter, false, typeof(BooleanGraphType));
            Field(x => x.IsSuport, false, typeof(BooleanGraphType));
            Field(x => x.IsUpgrade, false, typeof(BooleanGraphType));
            Field(x => x.IsUnique, false, typeof(BooleanGraphType));
            Field(x => x.Flavor, true, typeof(StringGraphType));
            Field(x => x.Image, true, typeof(StringGraphType));

            Field(x => x.SetStarWars, true, typeof(SetStarWarsGraphType));
            Field(x => x.Die, true, typeof(DieGraphType));
            Field(x => x.Rarity, true, typeof(RarityGraphType));
            Field(x => x.Color, true, typeof(ColorGraphType));
            Field(x => x.Faction, true, typeof(FactionGraphType));
            Field(x => x.Affiliation, true, typeof(AffiliationGraphType));
            Field(x => x.Artist, true, typeof(ArtistGraphType));
            Field(x => x.CardTypes, true, typeof(ListGraphType<CardTypeGraphType>));
        }
    }
}
