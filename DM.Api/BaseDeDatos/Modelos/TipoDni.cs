namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class TipoDni
    {
        public TipoDni()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdDni { get; set; }
        public string TipoDni1 { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
