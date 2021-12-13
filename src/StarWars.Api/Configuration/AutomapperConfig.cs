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
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<Localizacao, LocalizacaoViewModel>().ReverseMap();
            CreateMap<Rebelde, LocalizacaoUpdateViewModel>()
                .ForMember(x => x.IdRebelde, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.NomeDaBase, y => y.MapFrom(z => z.Localizacao.NomeDaBase))
                .ForMember(x => x.Latitude, y => y.MapFrom(z => z.Localizacao.Latitude))
                .ForMember(x => x.Longitude, y => y.MapFrom(z => z.Localizacao.Longitude))
                .ReverseMap();
        }

        #endregion
    }
}