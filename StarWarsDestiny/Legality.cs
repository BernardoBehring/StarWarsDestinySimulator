using StarWarsDestiny.Model.Common;
using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Legality : ModelOnlyName
    {
        public ICollection<BalanceForce> BalanceForces { get; set; }
    }
}
