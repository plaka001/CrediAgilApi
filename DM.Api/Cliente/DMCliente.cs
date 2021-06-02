namespace DM.Api.Cliente
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;
    public class DMCliente: BaseRepository<BaseDeDatos.Modelos.Cliente>, IDMCliente
    {
        public DMCliente(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
