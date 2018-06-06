using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_MVC_Aguirre.Models
{
    public class Consultas
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Count { get; set; }

        public Array TotalGalerias()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    var resultado =
                        from cat in db.Categoria
                            join gal in db.Galeria on cat.categoria_id
                                equals gal.categoria_id
                                into galeriaGroup
                            select new Consultas{ ID=cat.categoria_id ,Nombre = cat.nombre, Count = galeriaGroup.Count() };
                    return resultado.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}