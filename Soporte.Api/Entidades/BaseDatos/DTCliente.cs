namespace Soporte.Api.Entidades
{
    using System.ComponentModel.DataAnnotations;

    public class DTCliente
    {
        [Key]
        public int IdCliente { get; set; }
        public int? IdDni { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdPais { get; set; }
    }
}
