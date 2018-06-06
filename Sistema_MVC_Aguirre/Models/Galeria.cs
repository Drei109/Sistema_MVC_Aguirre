using System.Data.Entity.Infrastructure;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

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

        //[Required]
        [StringLength(250)]
        public string imagen { get; set; }

        //[Required]
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

        public string GuardarImagen(HttpPostedFileBase imagen)
        {
            var nombreImagen = "";
            const int size = 1024 * 1024 * 5;
            var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extensiones = Path.GetExtension(imagen.FileName);
            

            if (filtroextension.Contains(extensiones) && (imagen.ContentLength <= size))
            {
                nombreImagen = "Galeria_" + galeria_id + "_imagen" + extensiones;
                var nombreThumb = "Galeria_" + galeria_id + "_thumbnail.jpeg";
                imagen.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Galeria/" + nombreImagen));
                var image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Uploads/Galeria/" + nombreImagen));
                var thumb = image.GetThumbnailImage(80, 80, () => false, IntPtr.Zero);
                thumb.Save(HttpContext.Current.Server.MapPath("~/Uploads/Galeria/" + nombreThumb));
            }

            return nombreImagen;
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

        public List<Galeria> BuscarPorCategoria(string criterio)
        {
            var galerias = new List<Galeria>();
            int id = Convert.ToInt32(criterio);
            try
            {
                using (var db = new Model_Sistema())
                {
                    galerias = db.Galeria.Include("Categoria").Where(x => x.categoria_id == id).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return galerias;
        }
    }
    
}
