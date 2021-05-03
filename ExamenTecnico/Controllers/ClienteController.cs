using AutoMapper;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly LCliente _logica;
        public ClienteController(
            ILogger<ClienteController> logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _logica = new LCliente(_configuration);
        }

        [HttpGet]
        public ActionResult Get(string busqueda = "")
        {
            try
            {
                var retorno = _mapper.Map<List<ClienteList>>(_logica.Listar(busqueda));
                var respuesta = new Response<IEnumerable<ClienteList>>(retorno, 200);
                if (retorno.Count > 0)
                { return Ok(retorno); }
                else
                {
                    return NoContent();
                }
            }
            catch (ExcepcionLogica ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        [HttpPost]
        public ActionResult Post(ClientePost cliente)
        {
            try
            {
                var clienteInterno = _mapper.Map<Cliente>(cliente);
                var retorno = _logica.Agregar(clienteInterno);
                if (retorno != 0)
                { return Ok(retorno); }
                else
                { return StatusCode(500); }
            }
            catch (ExcepcionLogica ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
