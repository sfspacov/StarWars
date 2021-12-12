using System.Collections.Generic;

namespace StarWars.Api.ViewModels
{
    public class InventarioViewModel
    {
        #region Properties

        public ICollection<ItemViewModel> Itens { get; set; }

        #endregion
    }
}