

namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
  
    public class DTDepartamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string Departamento1 { get; set; }
        public int? IdPais { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
