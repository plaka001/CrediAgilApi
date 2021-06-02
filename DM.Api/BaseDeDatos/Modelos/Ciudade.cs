namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class Ciudade
    {
        public Ciudade()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public int? IdDepartamento { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
