using GraphQL.Types;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.API.Graph.Types
{
    public class DiceActionGraphType : ObjectGraphType<DiceAction>
    {
        public DiceActionGraphType()
        {
            Name = "DiceActionGraphType";
            Field(x => x.Id, false, typeof(IntGraphType));
            Field(x => x.Name, false, typeof(StringGraphType));
        }
    }
}
