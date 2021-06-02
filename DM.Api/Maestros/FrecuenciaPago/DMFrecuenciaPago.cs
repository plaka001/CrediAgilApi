

namespace DM.Api.Maestros.FrecuenciaPago
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;

    public class DMFrecuenciaPago : BaseRepository<BaseDeDatos.Modelos.Fecruencium>, IDMFrecuenciaPago
    {
        public DMFrecuenciaPago(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
