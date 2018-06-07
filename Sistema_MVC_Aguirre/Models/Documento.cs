using System.IO;
using System.Web;

namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Documento")]
    public partial class Documento
    {
        [Key]
        public int documento_id { get; set; }

        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string extension { get; set; }

        [Required]
        [StringLength(20)]
        public string tamanio { get; set; }

        [Required]
        [StringLength(250)]
        public string tipo { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Categoria Categoria { get; set; }

        // METHODS
        public List<Documento> Listar()
        {
            var documentos = new List<Documento>();

            try
            {
                //DB connection
                using (var db = new Model_Sistema())
                {
                    documentos = db.Documento.Include("Categoria").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return documentos;
        }

        public Documento Obtener(int id)
        {
            var documentos = new Documento();
            try
            {
                using (var db = new Model_Sistema())
                {
                    documentos = db.Documento.Include("Categoria").Where(x => x.documento_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return documentos;
        }

        public List<Documento> Buscar(string criterio)
        {
            var documentos = new List<Documento>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    documentos = db.Documento.Include("Categoria").Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return documentos;
        }

        public void Guardar(HttpPostedFileBase file, string extensionAntigua)
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    var doc = db.Entry(this);

                    if (this.documento_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }

                    db.SaveChanges();

                    if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/Documents/" + documento_id + extensionAntigua)))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/Documents/" + documento_id + extensionAntigua));
                    }

                    file.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Documents/" + documento_id + extension));

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
                var _context = new Model_Sistema();
                var doc = _context.Documento.Find(documento_id);

                if (File.Exists(HttpContext.Current.Server.MapPath("~/Uploads/Documents/" + documento_id + doc.extension)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/Documents/" + documento_id + doc.extension));
                }

                _context.Documento.Remove(doc);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
