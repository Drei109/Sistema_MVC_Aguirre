namespace Sistema_MVC_Aguirre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;


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
                    usuarios = db.Usuario.Include("Persona").ToList();
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
                    usuarios = db.Usuario.Include("Persona").Where(x => x.usuario_id == id).SingleOrDefault();
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
            string estadousu = "";
            switch (criterio)
            {
                case "Activo":
                    estadousu = "A";
                    break;
                case "Inactivo":
                    estadousu = "I";
                    break;
            }

            try
            {
                using (var db = new Model_Sistema())
                {
                    usuario = db.Usuario.Include("Persona").Where(x => x.usuario1.Contains(criterio) 
                              || x.Persona.apellido.Contains(criterio)
                              || x.estado == estadousu)
                              .ToList();
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

        public ResponseModel ValidarLogin(string usuario, string password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new Model_Sistema())
                {
                    password = HashHelper.MD5(password);
                    var usu = db.Usuario.Where(x => x.usuario1 == usuario)
                                            .Where(x => x.clave == password)
                                            .SingleOrDefault();

                    if (usu != null)
                    {
                        SessionHelper.AddUserToSession(usu.usuario_id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o password incorrecto");
                    }
                }
            }
            catch
            {
                throw;
            }

            return rm;
        }

        public ResponseModel GuardarPerfil(HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new Model_Sistema())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var Usu = db.Entry(this);
                    Usu.State = EntityState.Modified;

                    if (Foto != null)
                    {
                        string extension = Path.GetDirectoryName(Foto.FileName).ToLower();
                        int size = 1024 * 1024 * 5;
                        var filtroextension = new[]{".jpg",".jpeg",".png",".gif"};
                        var extensiones = Path.GetExtension(Foto.FileName);

                        if (filtroextension.Contains(extensiones) && (Foto.ContentLength <= size))
                        {
                            string archivo = Path.GetFileName(Foto.FileName);
                            Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + archivo));
                            this.avatar = archivo;
                        }
                        else
                        {
                            Usu.Property(x => x.avatar).IsModified = false; 
                        }

                        if (this.usuario_id == 0) Usu.Property(x => x.usuario_id).IsModified = false;
                        if (this.persona_id == 0) Usu.Property(x => x.persona_id).IsModified = false;
                        if (this.usuario1 == null) Usu.Property(x => x.usuario1).IsModified = false;
                        if (this.nivel == null) Usu.Property(x => x.nivel).IsModified = false;
                        if (this.estado == null) Usu.Property(x => x.estado).IsModified = false;
                        if (this.clave == null) Usu.Property(x => x.clave).IsModified = false;

                        db.SaveChanges();
                        rm.SetResponse(true);

                    }

                }
            }
            catch (DbEntityValidationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }
    }
}
