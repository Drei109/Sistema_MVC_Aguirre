namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;    

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int persona_id { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        // METHODS
        public List<Persona> Listar()
        {
            var personas = new List<Persona>();

            try
            {
                //DB connection
                using (var db = new Model_Sistema())
                {
                    personas = db.Persona.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return personas;
        }

        public Persona Obtener(int id)
        {
            var personas = new Persona();
            try
            {
                using (var db = new Model_Sistema())
                {
                    personas = db.Persona.Where(x => x.persona_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return personas;
        }

        public List<Persona> Buscar(string criterio)
        {
            var personas = new List<Persona>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    personas = db.Persona.Where(x => x.nombre.Contains(criterio) || x.apellido.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return personas;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.persona_id > 0)
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
                    if (this.persona_id > 0)
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
