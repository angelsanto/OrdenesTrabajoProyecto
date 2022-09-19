using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
   public class TIPOSERVDAL
    {

        public List<TIPOSERVICIO> listarTiposervi()
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.TIPOSERVICIO.ToList();
            }

        }

        public void agregar(TIPOSERVICIO tiposervicio)//AGREGAR UTILIZANDO LINQ
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.TIPOSERVICIO.Add(tiposervicio);
                db.SaveChanges();
            }

        }

        public TIPOSERVICIO detalleservicio (int id)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.TIPOSERVICIO.Find(id);
            }
        }

        public void elimina (int id)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.TIPOSERVICIO.Find(id);
                db.TIPOSERVICIO.Remove(d);
                db.SaveChanges();

            }
        }

        public void editar (TIPOSERVICIO tiposervicio)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.TIPOSERVICIO.Find(tiposervicio.ID_CATEGORIA);
                d.CATEGORIA = tiposervicio.CATEGORIA;
                db.SaveChanges();
            }
        }

    }

}

