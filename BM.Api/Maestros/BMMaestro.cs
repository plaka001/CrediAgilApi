namespace BM.Api.Maestros
{
    using AutoMapper;
    using DM.Api.BaseDeDatos.Modelos;
    using DM.Api.Maestros.Ciudad;
    using DM.Api.Maestros.Departamento;
    using DM.Api.Maestros.FrecuenciaPago;
    using DM.Api.Maestros.Pais;
    using DM.Api.Maestros.TipoDni;
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;
    using System;
    using System.Linq;

    public class BMMaestro : IBMMaestro
    {
        private IDMCiudad _objCiudad;
        private IDMDepartamento _objDepartamento;
        private IDMPais _objPais;
        private IDMFrecuenciaPago _objFrecuencia;
        private IDMTipoDni _objTipoDni;
        private readonly IMapper _Objmapper;

        public BMMaestro(IDMCiudad dMCiudad,IDMDepartamento dMDepartamento,IDMPais dMPais,IDMTipoDni dMTipoDni,IDMFrecuenciaPago dMFrecuenciaPago,IMapper mapper)
        {
            _objCiudad = dMCiudad;
            _objDepartamento = dMDepartamento;
            _objPais = dMPais;
            _objFrecuencia = dMFrecuenciaPago;
            _objTipoDni = dMTipoDni;
            _Objmapper = mapper;
        }

        #region Crear maestros
        public DTRespuesta<DTCiudad> CrearCiudad(DTCiudad ciudad)
        {
            DTRespuesta<DTCiudad> Resp = new DTRespuesta<DTCiudad>();
            DTMensaje mensaje = new DTMensaje();
            string Id = "IdCiudad";
            try
            {
                DM.Api.BaseDeDatos.Modelos.Ciudade objCiudad = new DM.Api.BaseDeDatos.Modelos.Ciudade();
                objCiudad = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Ciudade>(ciudad);
                int id = _objCiudad.Create(objCiudad, Id);

               
                if (id > 0)
                {
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear la ciudad";
                    Resp.Mensaje = mensaje;
                }
            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTDepartamento> CrearDepartamento(DTDepartamento depa)
        {
            DTRespuesta<DTDepartamento> Resp = new DTRespuesta<DTDepartamento>();
            DTMensaje mensaje = new DTMensaje();
            string Id = "IdDepartamento";
            try
            {
                DM.Api.BaseDeDatos.Modelos.Departamento objDepa = new DM.Api.BaseDeDatos.Modelos.Departamento();
                objDepa = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Departamento>(depa);
                int id = _objDepartamento.Create(objDepa, Id);

                if (id > 0)
                {
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear el departamento";
                    Resp.Mensaje = mensaje;
                }
            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTFrecuenciaPago> CrearFrecuenciaPago(DTFrecuenciaPago frecuenciaPago)
        {
            DTRespuesta<DTFrecuenciaPago> Resp = new DTRespuesta<DTFrecuenciaPago>();
            DTMensaje mensaje = new DTMensaje();
            string Id = "IdFecruencia";
            try
            {
                DM.Api.BaseDeDatos.Modelos.Fecruencium objFrecuencia = new DM.Api.BaseDeDatos.Modelos.Fecruencium();
                objFrecuencia = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Fecruencium>(frecuenciaPago);
                int id = _objFrecuencia.Create(objFrecuencia, Id);
                if (id > 0)
                {
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear la frecuencia de pago";
                    Resp.Mensaje = mensaje;
                }
            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTPais> CrearPais(DTPais pais)
        {
            DTRespuesta<DTPais> Resp = new DTRespuesta<DTPais>();
            DTMensaje mensaje = new DTMensaje();
            string Id = "IdPais";
            try
            {
                DM.Api.BaseDeDatos.Modelos.Paise objPais = new DM.Api.BaseDeDatos.Modelos.Paise();
                objPais = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Paise>(pais);
                int id = _objPais.Create(objPais, Id);
                if (id > 0)
                {
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear el pais";
                    Resp.Mensaje = mensaje;
                }

            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTDni> CrearTipoDni(DTDni dni)
        {
            DTRespuesta<DTDni> Resp = new DTRespuesta<DTDni>();
            DTMensaje mensaje = new DTMensaje();
            string Id = "IdDni";
            try
            {
                DM.Api.BaseDeDatos.Modelos.TipoDni objDni = new DM.Api.BaseDeDatos.Modelos.TipoDni();
                objDni = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.TipoDni>(dni);
                int id = _objTipoDni.Create(objDni, Id);

                if (id > 0)
                {
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear el tipo de DNI";
                    Resp.Mensaje = mensaje;
                }

            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }


        #endregion
        #region Eliminar maestros
        public DTRespuesta<DTPais> EliminarPais(int pais)
        {
            DTRespuesta<DTPais> Resp = new DTRespuesta<DTPais>();
            DTMensaje mensaje = new DTMensaje();
            try
            {
                Paise query = _objPais.GetAllBy(i => i.IdPais == pais).FirstOrDefault();

                if (query != null)
                {
                    _objPais.Delete(query);
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No se encontro el pais";
                    Resp.Mensaje = mensaje;
                }


            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTDepartamento> EliminarDepartamento(int depa)
        {
            DTRespuesta<DTDepartamento> Resp = new DTRespuesta<DTDepartamento>();
            DTMensaje mensaje = new DTMensaje();
            try
            {
                Departamento query = _objDepartamento.GetAllBy(i=> i.IdDepartamento == depa).FirstOrDefault();
               
                if (query != null)
                {
                    _objDepartamento.Delete(query);
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No se encuentra el departamento";
                    Resp.Mensaje = mensaje;
                }

   
            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTCiudad> EliminarCiudad(int ciudad)
        {
            DTRespuesta<DTCiudad> Resp = new DTRespuesta<DTCiudad>();
            DTMensaje mensaje = new DTMensaje();
            try
            {
                Ciudade query = _objCiudad.GetAllBy(i => i.IdCiudad == ciudad).FirstOrDefault();

                if (query != null)
                {
                    _objCiudad.Delete(query);
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No se encuentra la ciudad";
                    Resp.Mensaje = mensaje;
                }


            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTDni> EliminarTipoDni(int dni)
        {
            DTRespuesta<DTDni> Resp = new DTRespuesta<DTDni>();
            DTMensaje mensaje = new DTMensaje();
            try
            {
                TipoDni query = _objTipoDni.GetAllBy(i => i.IdDni == dni).FirstOrDefault();

                if (query != null)
                {
                    _objTipoDni.Delete(query);
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No se encuentra el tipo de DNI";
                    Resp.Mensaje = mensaje;
                }


            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }

        public DTRespuesta<DTFrecuenciaPago> EliminarFrecuenciaPago(int frecuencia)
        {
            DTRespuesta<DTFrecuenciaPago> Resp = new DTRespuesta<DTFrecuenciaPago>();
            DTMensaje mensaje = new DTMensaje();
            try
            {
                Fecruencium query = _objFrecuencia.GetAllBy(i => i.IdFecruencia == frecuencia).FirstOrDefault();

                if (query != null)
                {
                    _objFrecuencia.Delete(query);
                    mensaje.Error = false;
                    mensaje.Message = "Éxito";
                    Resp.Mensaje = mensaje;
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No se encuentra la frecuencia de pago";
                    Resp.Mensaje = mensaje;
                }


            }
            catch (Exception ex)
            {
                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                Resp.Mensaje = mensaje;
            }
            return Resp;
        }
        #endregion

    }
}
