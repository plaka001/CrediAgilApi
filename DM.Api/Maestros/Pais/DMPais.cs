

namespace DM.Api.Maestros.Pais
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;

    public class DMPais : BaseRepository<BaseDeDatos.Modelos.Paise>, IDMPais
    {
        public DMPais(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
