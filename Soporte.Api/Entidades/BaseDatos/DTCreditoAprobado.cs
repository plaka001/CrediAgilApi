
namespace Soporte.Api.Entidades.BaseDatos
{
    using System.ComponentModel.DataAnnotations;
    public class DTCreditoAprobado
    {
        [Key]
        public double ValorCredito { get; set; }
        public int PlazoCredito { get; set; }
        public double CupoRestante { get; set; }
    }
}
