namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DTFrecuenciaPago
    {
        [Key]
        public int IdFecruencia { get; set; }
        public string Fecruencia { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
