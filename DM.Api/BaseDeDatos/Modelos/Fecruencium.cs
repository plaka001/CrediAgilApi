namespace DM.Api.BaseDeDatos.Modelos
{
    using DM.Api.BaseDeDatos.Modelos;
    using System;
    using System.Collections.Generic;
    public partial class Fecruencium
    {
        public Fecruencium()
        {
            Creditos = new HashSet<Credito>();
        }

        public int IdFecruencia { get; set; }
        public string Fecruencia { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
