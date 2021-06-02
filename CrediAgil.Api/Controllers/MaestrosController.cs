//####################################################################
// Project:         CrediAgil (SisteCredito)
// Author:          John Marlon Cano
// DATA:            01/06/2021
// Comment:         Controlador encargado de gestionar los maestros
//####################################################################
namespace CrediAgil.Api.Controllers
{
    using BM.Api.Maestros;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;

    [Route("api/[controller]")]
    [ApiController]
    public class MaestrosController : ControllerBase
    {
        private IBMMaestro _objMaestros;
        public MaestrosController(IBMMaestro bMMaestro)
        {
            _objMaestros = bMMaestro;
        }


        #region Crear maestros

        /// <summary>
        /// Maestro para crear el país
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearPais")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTPais>> CrearPais(DTPais pais)
        {
            DTRespuesta<DTPais> Resp = new DTRespuesta<DTPais>();
            try
            {
                Resp = _objMaestros.CrearPais(pais);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para crear el departamento
        /// </summary>
        /// <param name="depa"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearDepartamento")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTDepartamento>> CrearDepartamento(DTDepartamento depa)
        {
            DTRespuesta<DTDepartamento> Resp = new DTRespuesta<DTDepartamento>();
            try
            {
                Resp = _objMaestros.CrearDepartamento(depa);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para crear la ciudad
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCiudad")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTCiudad>> CrearCiudad(DTCiudad ciudad)
        {
            DTRespuesta<DTCiudad> Resp = new DTRespuesta<DTCiudad>();
            try
            {
                Resp = _objMaestros.CrearCiudad(ciudad);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para crear los tipos de DNI
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearTipoDni")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTDni>> CrearTipoDni(DTDni dni)
        {
            DTRespuesta<DTDni> Resp = new DTRespuesta<DTDni>();
            try
            {
                Resp = _objMaestros.CrearTipoDni(dni);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para crear las frecuencias de pago para los créditos 
        /// </summary>
        /// <param name="frecuenciaPago"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearFrecuenciaPago")]
        [EnableCors("CorsApi")]
        public ActionResult<DTRespuesta<DTFrecuenciaPago>> CrearFrecuenciaPago(DTFrecuenciaPago frecuenciaPago)
        {
            DTRespuesta<DTFrecuenciaPago> Resp = new DTRespuesta<DTFrecuenciaPago>();
            try
            {
                Resp = _objMaestros.CrearFrecuenciaPago(frecuenciaPago);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }
        #endregion
        #region Eliminar maestros

        /// <summary>
        ///  Maestro para eliminar los paises
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsApi")]
        [Route("EliminarPais")]
        public ActionResult<DTRespuesta<DTPais>> EliminarPais(int pais)
        {
            DTRespuesta<DTPais> Resp = new DTRespuesta<DTPais>();
            try
            {
                Resp = _objMaestros.EliminarPais(pais);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para eliminar los departamentos
        /// </summary>
        /// <param name="depa"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsApi")]
        [Route("EliminarDepartamento")]
        public ActionResult<DTRespuesta<DTDepartamento>> EliminarDepartamento(int depa)
        {
            DTRespuesta<DTDepartamento> Resp = new DTRespuesta<DTDepartamento>();
            try
            {
                Resp = _objMaestros.EliminarDepartamento(depa);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para eliminar las ciudades
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsApi")]
        [Route("EliminarCiudad")]
        public ActionResult<DTRespuesta<DTCiudad>> EliminarCiudad(int ciudad)
        {
            DTRespuesta<DTCiudad> Resp = new DTRespuesta<DTCiudad>();
            try
            {
                Resp = _objMaestros.EliminarCiudad(ciudad);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para eliminar los tipos de DNI
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsApi")]
        [Route("EliminarTipoDni")]
        public ActionResult<DTRespuesta<DTDni>> EliminarTipoDni(int dni)
        {
            DTRespuesta<DTDni> Resp = new DTRespuesta<DTDni>();
            try
            {
                Resp = _objMaestros.EliminarTipoDni(dni);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        /// <summary>
        /// Maestro para eliminar las frecuencias de pago
        /// </summary>
        /// <param name="frecuencia"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("CorsApi")]
        [Route("EliminarFrecuenciaPago")]
        public ActionResult<DTRespuesta<DTFrecuenciaPago>> EliminarFrecuenciaPago(int frecuencia)
        {
            DTRespuesta<DTFrecuenciaPago> Resp = new DTRespuesta<DTFrecuenciaPago>();
            try
            {
                Resp = _objMaestros.EliminarFrecuenciaPago(frecuencia);
            }
            catch (System.Exception ex)
            {

            }
            return Resp;
        }

        #endregion
    }
}
