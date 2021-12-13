using AutoMapper;
using StarWars.Api.Controllers;
using StarWars.Api.ViewModels;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StarWars.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RebeldeController : MainApiController
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IRebeldeApplication _rebeldeApplication;

        #endregion

        #region Constructors

        public RebeldeController(INotificator notificator, IMapper mapper, IRebeldeApplication rebeldeApplication) : base(notificator)
        {
            _mapper = mapper;
            _rebeldeApplication = rebeldeApplication;
        }

        #endregion

        #region Public Methods

        [HttpGet("RetornaTodos")]
        public ActionResult<IList<RebeldeViewModel>> RetornaTodos()
        {
            var result = _mapper.Map<IList<RebeldeViewModel>>(_rebeldeApplication.RetornarTodos());

            return CustomResponse(result);
        }

        [HttpPost("Adicionar")]
        public ActionResult Adicionar(RebeldeViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = _rebeldeApplication.Criar(_mapper.Map<Rebelde>(viewModel));

            return CustomResponse(result);
        }

        [HttpPatch("Atualizar")]
        public ActionResult AtualizarLocalizacao(LocalizacaoUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = _rebeldeApplication.AtualizarLocalizacao(_mapper.Map<Rebelde>(viewModel));

            return CustomResponse(result);
        }

        [HttpPatch("ReportarTraidor/{idRebelde}")]
        public ActionResult ReportarTraidor(int idRebelde)
        {
            var result = _rebeldeApplication.ReportarTraidor(idRebelde);

            return CustomResponse(result);
        }

        [HttpPatch("EhTraidor/{idRebelde}")]
        public ActionResult EhTraidor(int idRebelde)
        {
            var result = _rebeldeApplication.EhTraidor(idRebelde);

            return CustomResponse(result);
        }

        [HttpPatch("NegociarItens")]
        public ActionResult NegociarItens(NegociarItensViewModel viewModel)
        {
            var itensRebelde1 = _mapper.Map<ICollection<Item>>(viewModel.ItensRebelde1);
            var itensRebelde2 = _mapper.Map<ICollection<Item>>(viewModel.ItensRebelde2);

            _rebeldeApplication.NegociarItens(viewModel.IdRebelde1, itensRebelde1, viewModel.IdRebelde2, itensRebelde2);

            return CustomResponse("Negociação realizada com sucesso!");
        }
        #endregion
    }
}