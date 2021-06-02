
namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class DTCupoCliente
    {
        [Key]
        public int IdCupo { get; set; }
        public decimal? Cupo { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
