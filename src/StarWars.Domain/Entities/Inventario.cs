using System.Collections.Generic;

namespace StarWars.Domain.Entities
{
    public class Inventario
    {
        #region Properties

        public uint Quantity { get; set; }

        public IList<Item> Warehouses { get; set; }

        #endregion
    }
}