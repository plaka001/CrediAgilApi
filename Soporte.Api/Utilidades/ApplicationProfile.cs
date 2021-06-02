namespace Soporte.Api.Utilidades
{
    using DM.Api.BaseDeDatos.Modelos;
    using Soporte.Api.Entidades;
    using Soporte.Api.Entidades.BaseDatos;

    public class ApplicationProfile: AutoMapper.Profile
    {
        public ApplicationProfile()
        {

            CreateMap<Cliente, DTCliente>().ReverseMap();
            CreateMap<CuposCliente,DTCupoCliente >().ReverseMap();
            CreateMap<Credito, DTCredito>().ReverseMap();
            CreateMap<Ciudade, DTCiudad>().ReverseMap();
            CreateMap<Departamento, DTDepartamento>().ReverseMap();
            CreateMap<Paise, DTPais>().ReverseMap();
            CreateMap<Fecruencium, DTFrecuenciaPago>().ReverseMap();
            CreateMap<TipoDni, DTDni>().ReverseMap();

        }
    }
}
