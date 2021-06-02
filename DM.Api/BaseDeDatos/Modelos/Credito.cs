namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class Credito
    {
        public int IdCredito { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Valor { get; set; }
        public int? IdPlazo { get; set; }
        public int? IdFrecuencia { get; set; }
        public DateTime? FechaTransaccion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Fecruencium IdFrecuenciaNavigation { get; set; }
    }
}
