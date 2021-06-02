
namespace Soporte.Api.Entidades.BaseDatos
{
    using System;
    using System.ComponentModel.DataAnnotations;
 

    public class DTCredito
    {
        [Key]
        public int IdCredito { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Valor { get; set; }
        public int? IdPlazo { get; set; }
        public int? IdFrecuencia { get; set; }
        public DateTime? FechaTransaccion { get; set; }
    }
}
