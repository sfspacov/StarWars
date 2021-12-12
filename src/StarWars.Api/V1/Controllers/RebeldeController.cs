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
            var rebeldes = _mapper.Map<IList<RebeldeViewModel>>(_iRebeldeApplication.GetAll());

            return CustomResponse(rebeldes);
        }

        [HttpGet("GetBySku/{sku}")]
        public ActionResult<RebeldeViewModel> GetBySku(int sku)
        {
            var rebelde = _mapper.Map<RebeldeViewModel>(_iRebeldeApplication.GetBySku(sku));

            if (rebelde != null)
                return CustomResponse(rebelde);

            return CustomResponse();
        }

        [HttpPost("Adicionar")]
        public ActionResult Adicionar(RebeldeViewModel rebeldeModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var rebelde = _iRebeldeApplication.Create(_mapper.Map<Rebelde>(rebeldeModel));

            return CustomResponse(rebelde);
        }

        [HttpPut("Atualizar")]
        public ActionResult Atualizar(RebeldeViewModel rebeldeModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var rebelde = _iRebeldeApplication.Update(_mapper.Map<Rebelde>(rebeldeModel));

            return CustomResponse(rebelde);
        }

        [HttpDelete("DeleteBySku/{sku}")]
        public ActionResult DeleteBySku(int sku)
        {
            _iRebeldeApplication.DeleteBySku(sku);

            return CustomResponse("Produto deletado com sucesso!");
        }

        #endregion
    }
}