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
        private readonly IRebeldeApplication _iRebeldeApplication;

        #endregion

        #region Constructors

        public RebeldeController(INotificator notificator, IMapper mapper, IRebeldeApplication iRebeldeApplication) : base(notificator)
        {
            _mapper = mapper;
            _iRebeldeApplication = iRebeldeApplication;
        }

        #endregion

        #region Public Methods

        [HttpGet("RetornaTodos")]
        public ActionResult<IList<RebeldeViewModel>> RetornaTodos()
        {
            var result = _mapper.Map<IList<RebeldeViewModel>>(_iRebeldeApplication.RetornarTodos());

            return CustomResponse(result);
        }

        [HttpGet("RetornarPorId/{id}")]
        public ActionResult<RebeldeViewModel> RetornarPorId(int id)
        {
            var result = _mapper.Map<RebeldeViewModel>(_iRebeldeApplication.RetornarPorId(id));

            return result != null ? CustomResponse(result) : CustomResponse();
        }

        [HttpPost("Adicionar")]
        public ActionResult Adicionar(RebeldeViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = _iRebeldeApplication.Criar(_mapper.Map<Rebelde>(viewModel));

            return CustomResponse(result);
        }

        [HttpPatch("Atualizar")]
        public ActionResult AtualizarLocalizacao(LocalizacaoUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = _iRebeldeApplication.AtualizarLocalizacao(_mapper.Map<Rebelde>(viewModel));

            return CustomResponse(result);
        }

        [HttpPatch("ReportarTraidor/{idRebelde}")]
        public ActionResult ReportarTraidor(int idRebelde)
        {
            var result = _iRebeldeApplication.ReportarTraidor(idRebelde);

            return CustomResponse(result);
        }

        [HttpPatch("EhTraidor/{idRebelde}")]
        public ActionResult EhTraidor(int idRebelde)
        {
            var result = _iRebeldeApplication.EhTraidor(idRebelde);

            return CustomResponse(result);
        }

        #endregion
    }
}