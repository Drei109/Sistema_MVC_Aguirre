namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int persona_id { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(30)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Persona Persona { get; set; }

        // METHODS
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();

            try
            {
                //DB connection
                using (var db = new Model_Sistema())
                {
                    usuarios = db.Usuario.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public Usuario Obtener(int id)
        {
            var usuarios = new Usuario();
            try
            {
                using (var db = new Model_Sistema())
                {
                    usuarios = db.Usuario.Where(x => x.usuario_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return usuarios;
        }

        public List<Usuario> Buscar(string criterio)
        {
            var usuario = new List<Usuario>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    usuario = db.Usuario.Where(x => x.usuario1.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.usuario_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.usuario_id > 0)
                    {
                        db.Entry(this).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
