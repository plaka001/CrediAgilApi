namespace BM.Api.Credito
{
    using Soporte.Api.Entidades.BaseDatos;
    using Soporte.Api.Entidades.General;
    public interface IBMCredito
    {
        DTRespuesta<DTCreditoAprobado> CrearCredito(DTCredito credito);
    }
}
