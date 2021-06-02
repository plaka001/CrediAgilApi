namespace DM.Api.Maestros.Ciudad
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;

    public  class DMCiudad : BaseRepository<BaseDeDatos.Modelos.Ciudade>, IDMCiudad
    {
        public DMCiudad(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
