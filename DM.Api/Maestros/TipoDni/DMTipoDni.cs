namespace DM.Api.Maestros.TipoDni
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;

    public class DMTipoDni: BaseRepository<BaseDeDatos.Modelos.TipoDni>, IDMTipoDni
    {
        public DMTipoDni(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
