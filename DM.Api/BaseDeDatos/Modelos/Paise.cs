namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class Paise
    {
        public Paise()
        {
            Clientes = new HashSet<Cliente>();
            Departamentos = new HashSet<Departamento>();
        }

        public int IdPais { get; set; }
        public string Pais { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
