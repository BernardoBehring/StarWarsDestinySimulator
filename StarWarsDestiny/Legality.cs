﻿using System.Collections.Generic;

namespace StarWarsDestiny.Model
{
    public class Legality : EntityId
    {
        public string Name { get; set; }
        public ICollection<BalanceForce> BalanceForces { get; set; }
    }
}
