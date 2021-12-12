using AutoMapper;
using StarWars.Api.ViewModels;
using StarWars.Domain.Entities;

namespace StarWars.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        #region Constructors

        public AutomapperConfig()
        {
            CreateMap<Rebelde, RebeldeViewModel>().ReverseMap();
            CreateMap<Inventario, InventarioViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Lozalizacao, LozalizacaoViewModel>().ReverseMap();
        }

        #endregion
    }
}