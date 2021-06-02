namespace BM.Api.Cliente
{
    using AutoMapper;
    using DM.Api.Cliente;
    using DM.Api.Cupo;
    using Soporte.Api.Entidades;
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BMCliente : IBMCliente
    {
        private IDMCliente _objCliente;
        private IDMCupo _objCupo;
        private readonly IMapper _Objmapper;
        public BMCliente(IDMCliente iDMCliente, IDMCupo idMCupo,  IMapper mapper)
        {
            _objCliente = iDMCliente;
            _objCupo = idMCupo;
            _Objmapper = mapper;
        }
        public DTRespuesta<DTCliente> CrearCliente(DTCliente objCliente)
        {
            DTRespuesta<DTCliente> Resp = new DTRespuesta<DTCliente>();
            DTMensaje mensaje = new DTMensaje();
            string IdCliente = "IdCliente";
            try
            {
                DM.Api.BaseDeDatos.Modelos.Cliente objClient = new DM.Api.BaseDeDatos.Modelos.Cliente();
                objClient = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.Cliente>(objCliente);
                int id = _objCliente.Create(objClient, IdCliente);

                //Una vez se crea el cliente se inserta el cupo
                if (id > 0)
                {
                    string IdCupo = "IdCupo";
                    DTCupoCliente cupo = new DTCupoCliente();
                    cupo.IdCliente = id;
                    cupo.Cupo = 2000000;
                    cupo.FechaRegistro = DateTime.Now;

                    DM.Api.BaseDeDatos.Modelos.CuposCliente objCupo = new DM.Api.BaseDeDatos.Modelos.CuposCliente();
                    objCupo = _Objmapper.Map<DM.Api.BaseDeDatos.Modelos.CuposCliente>(cupo);
                    int IdCupoGenerado =  _objCupo.Create(objCupo, IdCupo);
                    if (IdCupoGenerado > 0)
                    {
                        mensaje.Error = false;
                        mensaje.Message = "Éxito";
                        Resp.Mensaje = mensaje;
                    }
                    else
                    {
                        mensaje.Error = true;
                        mensaje.Message = "Error al crear el cupo del cliente";
                        Resp.Mensaje = mensaje;
                    }
                }
                else
                {
                    mensaje.Error = true;
                    mensaje.Message = "Error al crear el cliente";
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

        public DTRespuesta<DTCliente> BuscarClienteByDni(string dni, int idDni)
        {
            DTRespuesta<DTCliente> resp = new DTRespuesta<DTCliente>();
            List<DTCliente> objCLiente = new List<DTCliente>();
          
            DTMensaje mensaje = new DTMensaje();

            try
            {
                DM.Api.BaseDeDatos.Modelos.Cliente objClient = new DM.Api.BaseDeDatos.Modelos.Cliente();
                var Query = _objCliente.GetAll();
                if (Query != null)
                {
                    foreach (DM.Api.BaseDeDatos.Modelos.Cliente item in Query)
                    {
                        DTCliente clienteList = new DTCliente();
                        clienteList = _Objmapper.Map<DTCliente>(item);
                        objCLiente.Add(clienteList);
                    }

                    if (objCLiente.Count > 0)
                    {
                        resp.Data = objCLiente.Where(x => x.Dni == dni && x.IdDni == idDni).FirstOrDefault();
                        mensaje.Error = false;
                        mensaje.Message = "Éxito";
                        resp.Mensaje = mensaje;
                    }
                    if (resp.Data == null)
                    {
                        mensaje.Error = false;
                        mensaje.Message = "Los datos ingresados no se encuentran en la base de datos";
                        resp.Mensaje = mensaje;
                    }
                }
                else
                {
                    mensaje.Error = false;
                    mensaje.Message = "No hay datos para mostrar";
                    resp.Mensaje = mensaje;
                }
            }
            catch (Exception)
            {

                mensaje.Error = true;
                mensaje.Message = "Error contacte al administrador";
                resp.Mensaje = mensaje;
            }
            return resp;
        }
    }
}
