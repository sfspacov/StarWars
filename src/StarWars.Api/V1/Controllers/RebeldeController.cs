using AutoMapper;
using StarWars.Api.Controllers;
using StarWars.Api.ViewModels;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StarWars.Api.V1.Controllers
{
    /// <summary>
    /// Rebelde Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RebeldeController : MainApiController
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IRebeldeApplication _rebeldeApplication;
        private readonly ILocalizacaoApplication _localizacaoApplication;

        #endregion

        #region Constructors

        public RebeldeController(INotificator notificator, IMapper mapper, IRebeldeApplication rebeldeApplication, ILocalizacaoApplication localizacaoApplication) : base(notificator)
        {
            _mapper = mapper;
            _rebeldeApplication = rebeldeApplication;
            _localizacaoApplication = localizacaoApplication;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Retorna todos os rebeldes cadastrados no sistema
        /// </summary>
        /// <returns>List de Rebeldes</returns>
        [HttpGet("RetornaTodos")]
        public ActionResult<IEnumerable<RebeldeViewModel>> RetornaTodos()
        {
            var rebeldes = _rebeldeApplication.RetornarTodos();
            var result = _mapper.Map<IEnumerable<RebeldeViewModel>>(rebeldes);

            return CustomResponse(result);
        }

        /// <summary>
        /// Adicionar rebeldes. Um rebelde deve ter um nome, idade, gênero, localização (latitude, longitude e nome, na galáxia, da base ao qual faz parte).
        /// Um rebelde também possui um inventário que deverá ser passado na requisição com os recursos em sua posse.
        /// </summary>
        /// <param name="viewModel">Propriedades do rebelde a ser adicionado. O id é auto-increment</param>
        /// <returns>Rebelde adicionado</returns>
        [HttpPost("Adicionar")]
        public ActionResult Adicionar(RebeldeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = _rebeldeApplication.Criar(_mapper.Map<Rebelde>(viewModel));

            return CustomResponse(result);
        }

        /// <summary>
        /// Atualizar localização do rebelde.
        /// Um rebelde deve possuir a capacidade de reportar sua última localização, armazenando a nova latitude/longitude/nome(não é necessário rastrear as localizações, apenas sobrescrever a última é o suficiente).
        /// </summary>
        /// <param name="viewModel">Propriedades de localização a ser atualizada</param>
        /// <returns>Rebelde com a localização atualizada</returns>
        [HttpPatch("Atualizar")]
        public ActionResult AtualizarLocalizacao(LocalizacaoUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            _localizacaoApplication.Atualizar(new Localizacao

            {
                IdRebelde = viewModel.IdRebelde,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
                NomeDaBase = viewModel.NomeDaBase,
            });

            return CustomResponse();
        }

        /// <summary>
        /// Reportar um rebelde como traidor
        /// </summary>
        /// <param name="idRebelde">Id do Rebelde traidor</param>
        /// <returns>Mensagem de sucesso</returns>
        [HttpPatch("ReportarTraidor/{idRebelde}")]
        public ActionResult ReportarTraidor(int idRebelde)
        {
            var result = _rebeldeApplication.ReportarTraidor(idRebelde);

            return CustomResponse(result);
        }

        /// <summary>
        /// Retorna um booleando dizendo se um dado Rebelde é ou não traidor. Um rebelde é marcado como traidor quando, ao menos, três outros rebeldes reportarem a traição.
        /// </summary>
        /// <param name="idRebelde">Id do Rebelde traidor</param>
        /// <returns>Booleano dizendo se o rebelde é ou não traidor</returns>
        [HttpPatch("EhTraidor/{idRebelde}")]
        public ActionResult EhTraidor(int idRebelde)
        {
            var result = _rebeldeApplication.EhTraidor(idRebelde);

            return CustomResponse(result);
        }

        /// <summary>
        /// Negociar itens. Os rebeldes poderão negociar itens entre eles. Para isso é necessário fornecer o id dos rebeldes que irão negociar, assim como os itens a serem negociados
        /// </summary>
        /// <param name="viewModel">Id dos rebeldes e itens a serem negociados</param>
        /// <returns>Mensagem de sucesso</returns>
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