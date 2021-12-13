using System.Collections.Generic;

namespace StarWars.Api.ViewModels
{
    public class NegociarItensViewModel
    {
        #region Properties

        public int IdRebelde1 { get; set; }
        public ICollection<ItemViewModel> ItensRebelde1 { get; set; }
        public int IdRebelde2 { get; set; }
        public ICollection<ItemViewModel> ItensRebelde2 { get; set; }

        #endregion
    }
}