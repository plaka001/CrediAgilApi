using Soporte.Api.Entidades.BaseDatos;
using Soporte.Api.Entidades.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Api.Maestros
{
    public interface IBMMaestro
    {
        DTRespuesta<DTPais> CrearPais(DTPais pais);
        DTRespuesta<DTDepartamento> CrearDepartamento(DTDepartamento depa);
        DTRespuesta<DTCiudad> CrearCiudad(DTCiudad ciudad);
        DTRespuesta<DTDni> CrearTipoDni(DTDni dni);
        DTRespuesta<DTFrecuenciaPago> CrearFrecuenciaPago(DTFrecuenciaPago frecuenciaPago);
        DTRespuesta<DTPais> EliminarPais(int pais);
        DTRespuesta<DTDepartamento> EliminarDepartamento(int depa);
        DTRespuesta<DTCiudad> EliminarCiudad(int ciudad);
        DTRespuesta<DTDni> EliminarTipoDni(int dni);
        DTRespuesta<DTFrecuenciaPago> EliminarFrecuenciaPago(int frecuencia);
    }
}
