namespace DM.Api.BaseDeDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    public partial class Cliente
    {
        public Cliente()
        {
            Creditos = new HashSet<Credito>();
            CuposClientes = new HashSet<CuposCliente>();
        }

        public int IdCliente { get; set; }
        public int? IdDni { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int? IdCiudad { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdPais { get; set; }

        public virtual Ciudade IdCiudadNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual TipoDni IdDniNavigation { get; set; }
        public virtual Paise IdPaisNavigation { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
        public virtual ICollection<CuposCliente> CuposClientes { get; set; }
    }
}
