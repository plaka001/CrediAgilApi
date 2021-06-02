namespace BM.Api.Credito
{
    using AutoMapper;
    using DM.Api.Cliente;
    using DM.Api.Credito;
    using DM.Api.Cupo;
    using Soporte.Api.Entidades;
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BMCredito : IBMCredito
    {
        private IDMCliente _objCliente;
        private IDMCupo _objCupo;
        private IDMCredito _objCredito;
        private readonly IMapper _Objmapper;
        public BMCredito(IDMCliente dmCliente, IDMCupo dmCupo, IDMCredito dmCredito, IMapper mapper)
        {
            _objCliente = dmCliente;
            _objCupo = dmCupo;
            _objCredito = dmCredito;
            _Objmapper = mapper;
        }

        public DTRespuesta<DTCreditoAprobado> CrearCredito(DTCredito credito)
        {
            DTRespuesta<DTCreditoAprobado> resp = new DTRespuesta<DTCreditoAprobado>();
            DTMensaje mensaje = new DTMensaje();
            List<DTCliente> listClientes = new List<DTCliente>();

            try
            {
                // Validamos que la persona que solicita el crédito este en la base de datos
                var Cliente = _objCliente.GetAllBy(i => i.IdCliente == credito.IdCliente).FirstOrDefault();
                if (Cliente != null)
                {
                    //Consultamos el cupo del cliente 
                    var Cupo = _objCupo.GetAllBy(i => i.IdCliente == credito.IdCliente).FirstOrDefault();

                    //Validamos si puede hacer el crédito por el valor solicitado según su cupo
                    if (Cupo.Cupo >= credito.Valor)
                    {
                        //Validamos si el plazo está permitido según el valor del crédito
                        var valorCredito = credito.Valor;
                        bool PlazoValido = ValidarPlazoCrdito(valorCredito, credito.IdPlazo);
                        if (PlazoValido == true)
                        {
                            //Creamos el credito 
                            int idCredito = GenerarCredito(credito);

                            if (idCredito > 0)
                            {
                                // Actualizamos el cupo del cliente
                                ActualizarCupoCliente(credito, Cupo);
                                mensaje.Error = false;
                                mensaje.Message = "Crédito creado correctamente";
                                resp.Mensaje = mensaje;
                            }
                            else
                            {
                                mensaje.Error = true;
                                mensaje.Message = "Error al crear el crédito";
                                resp.Mensaje = mensaje;
                            }
                        }
                        else
                        {
                            mensaje.Error = true;
                            mensaje.Message = "Plazo no valido";
                            resp.Mensaje = mensaje;
                        }

                    }
                    else
                    {
                        mensaje.Error = false;
                        mensaje.Message = "No tienes cupo disponible, su cupo  es: "+Cupo.Cupo+"";
                        resp.Mensaje = mensaje;
                    }
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "No se encontró el cliente";
                    resp.Mensaje = mensaje;
                }
            }
            catch (Exception)
            {
                mensaje.Error = true;
                mensaje.Message = "Error al crear el cupo del cliente";
                resp.Mensaje = mensaje;
            }
            return resp;
        }

        private void ActualizarCupoCliente(DTCredito credito, DM.Api.BaseDeDatos.Modelos.CuposCliente cupo)
        {
            try
            {
                DM.Api.BaseDeDatos.Modelos.CuposCliente objCupoActual = new DM.Api.BaseDeDatos.Modelos.CuposCliente();
                DTCupoCliente cupoNuevo = new DTCupoCliente();
                cupoNuevo.Cupo = cupo.Cupo - credito.Valor;
                cupoNuevo.IdCliente = credito.IdCliente;
                cupoNuevo.IdCupo = cupo.IdCupo;
                cupoNuevo.FechaModificacion = DateTime.Now;
                objCupoActual = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.CuposCliente>(cupoNuevo);
                _objCupo.Update(objCupoActual);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Este metodo genera el crédito
        private int GenerarCredito(DTCredito credito)
        {
            int id;
            try
            {
                string IdCredito = "IdCredito";
                DM.Api.BaseDeDatos.Modelos.Credito objCredit = new DM.Api.BaseDeDatos.Modelos.Credito();
                objCredit = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Credito>(credito);
                 id = _objCredito.Create(objCredit, IdCredito);
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }


        //Este metodo valida el plazo según el valor del cupo
        private bool ValidarPlazoCrdito(decimal? valorCredito, int? plazoCupo)
        {
            bool repuesta = false;
            if (valorCredito > 0 && valorCredito < 100000 && plazoCupo > 0 && plazoCupo <= 2)
            {
                repuesta = true;
            }
            else if (valorCredito >= 100001 && valorCredito <= 500000 && plazoCupo <= 4)
            {
                repuesta = true;
            }
            else if (valorCredito >= 500001 && valorCredito <= 1000000 && plazoCupo <= 6)
            {
                repuesta = true;
            }
            else if (valorCredito >= 1000001 && plazoCupo <= 12)
            {
                repuesta = true;
            }
            return repuesta;
        }
    }
}
