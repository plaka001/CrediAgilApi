namespace DM.Api.Maestros.Departamento
{
    using DM.Api.BaseDeDatos.Context;
    using DM.Api.Repository;
    public class DMDepartamento : BaseRepository<BaseDeDatos.Modelos.Departamento>, IDMDepartamento
    {
        public DMDepartamento(CrediAgilContext Db) : base(Db)
        {

        }
    }
}
