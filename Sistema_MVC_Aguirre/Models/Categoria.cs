namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    //Add these
    using System.Linq;
    using System.Data.Entity;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Documento = new HashSet<Documento>();
            Galeria = new HashSet<Galeria>();
        }

        [Key]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Galeria> Galeria { get; set; }

        // METHODS
        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            try
            {
                //DB connection
                using (var db = new Model_Sistema())
                {
                    categorias = db.Categoria.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return categorias;
        }

        public Categoria Obtener(int id)
        {
            var categorias = new Categoria();
            try
            {
                using (var db = new Model_Sistema())
                {
                    categorias = db.Categoria.Where(x => x.categoria_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return categorias;
        }

        public List<Categoria> Buscar(string criterio)
        {
            var categorias = new List<Categoria>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    categorias = db.Categoria.Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return categorias;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.categoria_id > 0)
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
                    if (this.categoria_id > 0)
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
