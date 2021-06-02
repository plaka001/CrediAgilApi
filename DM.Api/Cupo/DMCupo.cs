namespace DM.Api.Cupo
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;

    public class DMCupo :BaseRepository<BaseDeDatos.Modelos.CuposCliente>, IDMCupo
    {
        public DMCupo(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
