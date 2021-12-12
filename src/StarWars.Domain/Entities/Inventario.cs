using System.Collections.Generic;

namespace StarWars.Domain.Entities
{
    public class Inventario
    {
        #region Properties

        public ICollection<Item> Itens { get; set; }

        #endregion
    }
}