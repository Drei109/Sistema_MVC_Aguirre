namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Galeria")]
    public partial class Galeria
    {
        [Key]
        public int galeria_id { get; set; }

        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(250)]
        public string imagen { get; set; }

        [Required]
        [StringLength(250)]
        public string thumbail { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Categoria Categoria { get; set; }

        // METHODS
        public List<Galeria> Listar()
        {
            var galerias = new List<Galeria>();

            try
            {
                //DB connection
                using (var db = new Model_Sistema())
                {
                    galerias = db.Galeria.Include("Categoria").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return galerias;
        }

        public Galeria Obtener(int id)
        {
            var galerias = new Galeria();
            try
            {
                using (var db = new Model_Sistema())
                {
                    galerias = db.Galeria.Include("Categoria").Where(x => x.galeria_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return galerias;
        }

        public List<Galeria> Buscar(string criterio)
        {
            var galerias = new List<Galeria>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    galerias = db.Galeria.Include("Categoria").Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return galerias;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.galeria_id > 0)
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
                    if (this.galeria_id > 0)
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
