using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_MVC_Aguirre.Models
{
    public class DocumentoService : IDisposable
    {

        private static bool UpdateDatabase = false;
        private Model_Sistema entities;

        public DocumentoService(Model_Sistema entities)
        {
            this.entities = entities;
        }

        public IList<Documento> GetAll()
        {
            var result = HttpContext.Current.Session["Documentos"] as IList<Documento>;

            if (result == null || UpdateDatabase)
            {
                result = entities.Documento.Select(documento => new Documento
                {
                    documento_id = documento.documento_id,
                    nombre = documento.nombre,
                    descripcion = documento.descripcion,
                    extension = documento.extension,
                    tamanio = documento.tamanio,
                    Categoria = new Categoria()
                    {
                        categoria_id = documento.Categoria.categoria_id,
                        nombre = documento.Categoria.nombre
                    },
                    
                }).ToList();

                HttpContext.Current.Session["Documentos"] = result;
            }

            return result;
        }

        public IEnumerable<Documento> Read()
        {
            return GetAll();
        }

        public void Create(Documento documento)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.documento_id).FirstOrDefault();
                var id = (first != null) ? first.documento_id : 0;

                documento.documento_id = id + 1;

                if (documento.categoria_id == null)
                {
                    documento.categoria_id = 1;
                }

                if (documento.Categoria == null)
                {
                    documento.Categoria = new Categoria() { categoria_id = 1, nombre = "Tipo1" };
                }

                GetAll().Insert(0, documento);
            }
            else
            {
                var entity = new Documento();

                entity.documento_id = documento.documento_id;
                entity.nombre = documento.nombre;
                entity.descripcion = documento.descripcion;
                entity.extension = documento.extension;
                entity.tamanio = documento.tamanio;                
                entity.categoria_id = documento.categoria_id;

                if (entity.categoria_id == null)
                {
                    entity.categoria_id = 1;
                }

                if (documento.Categoria != null)
                {
                    entity.categoria_id = documento.Categoria.categoria_id;
                }

                entities.Documento.Add(entity);
                entities.SaveChanges();

                documento.documento_id = entity.documento_id;
            }
        }

        public void Update(Documento documento)
        {
            if (!UpdateDatabase)
            {
                var target = One(e => e.categoria_id == documento.documento_id);

                if (target != null)
                {
                    target.nombre = documento.nombre;
                    target.descripcion = documento.descripcion;
                    target.extension = documento.extension;
                    target.tamanio = documento.tamanio;
                    target.categoria_id = documento.categoria_id;

                    if (documento.categoria_id == null)
                    {
                        documento.categoria_id = 1;
                    }

                    if (documento.Categoria != null)
                    {
                        documento.categoria_id = documento.Categoria.categoria_id;
                    }
                    else
                    {
                        documento.Categoria = new Categoria()
                        {
                            categoria_id = (int)documento.categoria_id,
                            nombre = entities.Categoria.Where(s => s.categoria_id == documento.categoria_id).Select(s => s.nombre).First()
                        };
                    }

                    target.categoria_id = documento.categoria_id;
                    target.Categoria = documento.Categoria;
                }
            }
            else
            {
                var entity = new Documento();

                entity.documento_id = documento.documento_id;
                entity.nombre = documento.nombre;
                entity.descripcion = documento.descripcion;
                entity.extension = documento.extension;
                entity.tamanio = documento.tamanio;
                entity.categoria_id = documento.categoria_id;

                if (documento.Categoria != null)
                {
                    entity.categoria_id = documento.Categoria.categoria_id;
                }

                entities.Documento.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Destroy(Documento documento)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.categoria_id == documento.categoria_id);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new Documento();

                entity.categoria_id = documento.categoria_id;

                entities.Documento.Attach(entity);

                entities.Documento.Remove(entity);

                //var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

                //foreach (var orderDetail in orderDetails)
                //{
                //    entities.Order_Details.Remove(orderDetail);
                //}

                entities.SaveChanges();
            }
        }

        public Documento One(Func<Documento, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}