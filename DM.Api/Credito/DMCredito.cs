namespace DM.Api.Credito
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;
    public class DMCredito : BaseRepository<BaseDeDatos.Modelos.Credito>, IDMCredito
    {
        public DMCredito(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
