using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class DiceFaceGraphType : ObjectGraphType<DiceFace>
    {
        public DiceFaceGraphType()
        {
            Name = "DiceFaceGraphType";

            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Value, false, typeof(StringGraphType));
            Field(x => x.IsModifier, false, typeof(BooleanGraphType));
            Field(x => x.DiceActionId, false, typeof(IntGraphType));
            Field(x => x.Cost, false, typeof(IntGraphType));
            Field(x => x.DieId, false, typeof(IntGraphType));

            Field(x => x.DiceAction, true, typeof(DiceActionGraphType));
        }
    }
}
