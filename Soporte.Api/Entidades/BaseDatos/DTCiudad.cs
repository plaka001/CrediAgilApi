namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
  
    public class DTCiudad
    {
        [Key]
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public int? IdDepartamento { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
