//####################################################################
// Project:         CrediAgil (SisteCredito)
// Author:          John Marlon Cano
// DATA:            01/06/2021
// Comment:         Controlador encargado de gestionar los clientes
//####################################################################
namespace CrediAgil.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Soporte.Api.Entidades;
    using Microsoft.AspNetCore.Cors;
    using BM.Api.Cliente;
    using Soporte.Api.Entidades.General;

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsApi")]
    public class ClientesController : ControllerBase
    {
        private IBMCliente _objCliente;

        public ClientesController(IBMCliente bMCliente)
        {
            _objCliente = bMCliente;
        }

        /// <summary>
        /// Crea el cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCliente")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTCliente>> CrearCliente(DTCliente cliente)
        {
            DTRespuesta<DTCliente> Resp = new DTRespuesta<DTCliente>();
            try
            {
                Resp =  _objCliente.CrearCliente(cliente);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }
        /// <summary>
        /// Busca el cliente según su DNI y el Id del DNI
        /// </summary>
        /// <param name="Dni"></param>
        /// <param name="IdDni"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarClienteByDni")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTCliente>> BuscarClienteByDni(string Dni, int IdDni)
        {
            DTRespuesta<DTCliente> Resp = new DTRespuesta<DTCliente>();
            try
            {
                Resp =  _objCliente.BuscarClienteByDni(Dni,IdDni);
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return Resp;
        }
    }
}
