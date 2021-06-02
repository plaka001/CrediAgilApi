//####################################################################
// Project:         CrediAgil (SisteCredito)
// Author:          John Marlon Cano
// DATA:            01/06/2021
// Comment:         Controlador encargado de gestionar el credito de los clientes
//####################################################################
namespace CrediAgil.Api.Controllers
{
    using BM.Api.Credito;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;
    using System;


    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsApi")]
    public class CreditoController : ControllerBase
    {
        private IBMCredito _objCredito;

        public CreditoController(IBMCredito bmCredito)
        {
            _objCredito = bmCredito;
        }

        /// <summary>
        /// Crear credito para los clientes
        /// </summary>
        /// <param name="credito"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCredito")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTCreditoAprobado>> CrearCredito(DTCredito credito)
        {
            DTRespuesta<DTCreditoAprobado> resp = new DTRespuesta<DTCreditoAprobado>();
            try
            {
                resp = _objCredito.CrearCredito(credito);
            }
            catch (Exception)
            {

                throw;
            }

            return resp;
        }

    }
}
