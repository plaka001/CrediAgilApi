namespace BM.Api.Cliente
{
    using Soporte.Api.Entidades;
    using Soporte.Api.Entidades.General;

    public interface IBMCliente
    {
       DTRespuesta<DTCliente> CrearCliente(DTCliente objCliente);
        DTRespuesta<DTCliente> BuscarClienteByDni(string dni, int idDni);
    }
}
