using AutoMapper;
using Fiap.Api.Alertas.Models;
using Fiap.Api.Alertas.Services;
using Fiap.Api.Alertas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alertas.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaService _alertaService;
        private readonly IMapper _mapper;

        public AlertaController(IAlertaService alertaService, IMapper mapper)
        {
            _alertaService = alertaService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<AlertaViewModel>> Get()
        //{
        //    var lista = _alertaService.ListarAlertas();
        //    var viewModelList = _mapper.Map<IEnumerable<AlertaViewModel>>(lista);

        //    if (viewModelList == null)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(viewModelList);
        //    }

        //}

        [HttpGet]
        public ActionResult<IEnumerable<AlertaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var alertas = _alertaService.ListarAlertas(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<AlertaViewModel>>(alertas);

            var viewModel = new AlertaPaginacaoViewModel
            {
                Alertas = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public ActionResult<AlertaViewModel> Get([FromRoute] long id)
        {
            var model = _alertaService.ObterAlertaPorId(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = _mapper.Map<AlertaViewModel>(model);

                return Ok(viewModel);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] AlertaViewModel viewModel)
        {
            var model = _mapper.Map<AlertaModel>(viewModel);
            _alertaService.CriarAlerta(model);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            _alertaService.DeletarAlerta(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] long id, [FromBody] AlertaViewModel viewModel)
        {
            if (viewModel.Id == id)
            {
                var model = _mapper.Map<AlertaModel>(viewModel);
                _alertaService.AtualizarAlerta(model);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }


        }
    }
}
