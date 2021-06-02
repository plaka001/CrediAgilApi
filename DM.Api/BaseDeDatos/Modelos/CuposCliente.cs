namespace DM.Api.BaseDeDatos.Modelos
{
    using DM.Api.BaseDeDatos.Modelos;
    using System;
    using System.Collections.Generic;
    public partial class CuposCliente
    {
        public int IdCupo { get; set; }
        public decimal? Cupo { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
