
namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class DTPais
    {
        [Key]
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
