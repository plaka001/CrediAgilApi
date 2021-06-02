namespace DM.Api.BaseDeDatos.Context
{
    using DM.Api.BaseDeDatos.Modelos;
    using Microsoft.EntityFrameworkCore;
    public partial class CrediAgilContext : DbContext
    {
        public CrediAgilContext()
        {
        }

        public CrediAgilContext(DbContextOptions<CrediAgilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Credito> Creditos { get; set; }
        public virtual DbSet<CuposCliente> CuposClientes { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Fecruencium> Fecruencia { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }
        public virtual DbSet<TipoDni> TipoDnis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JT4IJ00;Initial Catalog=CrediAgil;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PK__Ciudades__D4D3CCB0B571D85F");

                entity.ToTable("Ciudades", "Credito");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Ciudades__FechaM__33D4B598");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466429F27E568");

                entity.ToTable("Cliente", "Credito");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.IdDni).HasColumnName("IdDNI");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCiudad)
                    .HasConstraintName("FK__Cliente__IdCiuda__38996AB5");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Cliente__IdDepar__398D8EEE");

                entity.HasOne(d => d.IdDniNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDni)
                    .HasConstraintName("FK__Cliente__IdDNI__3B75D760");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__Cliente__IdPais__3A81B327");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.HasKey(e => e.IdCredito)
                    .HasName("PK__Credito__EF6108CB5D2BB027");

                entity.ToTable("Credito", "Credito");

                entity.Property(e => e.FechaTransaccion).HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Credito__IdClien__44FF419A");

                entity.HasOne(d => d.IdFrecuenciaNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdFrecuencia)
                    .HasConstraintName("FK__Credito__IdFrecu__46E78A0C");

                entity.Property(e => e.IdPlazo).HasColumnType("int");
            
            });

            modelBuilder.Entity<CuposCliente>(entity =>
            {
                entity.HasKey(e => e.IdCupo)
                    .HasName("PK__CuposCli__3E4BB16A7D9A5FDB");

                entity.ToTable("CuposCliente", "Credito");

                entity.Property(e => e.Cupo).HasColumnType("money");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CuposClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__CuposClie__Fecha__3E52440B");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DFD53B906");

                entity.ToTable("Departamentos", "Credito");

                entity.Property(e => e.Departamento1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Departamento");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK__Departame__Fecha__30F848ED");
            });

            modelBuilder.Entity<Fecruencium>(entity =>
            {
                entity.HasKey(e => e.IdFecruencia)
                    .HasName("PK__Fecruenc__51F1EF2B1734CA9B");

                entity.ToTable("Fecruencia", "Credito");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.Fecruencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Paises__FC850A7BAA38D7FB");

                entity.ToTable("Paises", "Credito");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<TipoDni>(entity =>
            {
                entity.HasKey(e => e.IdDni)
                    .HasName("PK__TipoDNI__0E66FCB81E7479EF");

                entity.ToTable("TipoDNI", "Credito");

                entity.Property(e => e.IdDni).HasColumnName("IdDNI");

                entity.Property(e => e.FechaModificacion).HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.TipoDni1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoDNI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
