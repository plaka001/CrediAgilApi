namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudades = new HashSet<Ciudade>();
            Clientes = new HashSet<Cliente>();
        }

        public int IdDepartamento { get; set; }
        public string Departamento1 { get; set; }
        public int? IdPais { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Paise IdPaisNavigation { get; set; }
        public virtual ICollection<Ciudade> Ciudades { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
