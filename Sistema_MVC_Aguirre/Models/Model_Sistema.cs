namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public partial class Model_Sistema : DbContext
    {
        public Model_Sistema()
            : base("name=Model_Sistema2")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Documento)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Galeria)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.extension)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.tamanio)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.thumbail)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}
