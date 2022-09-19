using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
   public class MATERIALDAL
    {
        public List<MATERIALES> ListarMaterial() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {

                db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO TRAIGA LOS DATOS DEL EPLEADO YA QUE TIENE UN RELACION CON ESA TABLA PARA LLENAR EL DROPDONLIST
                return db.MATERIALES.ToList();

            }

        }

        public void Agregar(MATERIALES material)
        {

            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION A LA BASE DE DATOS Y TAMBIEN PARA CERRARLA.
            {
                db.MATERIALES.Add(material);// METODO PARA GUARDAR.
                db.SaveChanges();

            }
        }

        public MATERIALES detalleMateri(int id)//PARA TRAER EL DETALLE DE LOS REGISTROS
        {
            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.MATERIALES.Where(d => d.ID_MATERIAL == id).FirstOrDefault();// PARA BUSCAR EN LA BASE DE DATOS
                //return db.MATERIALES.Find(id);//PARA BUSCAR EN LA BASE DE DATOS

            }

        }

        public void editar(MATERIALES material)
        {
            using (var db = new BSORDENTRABAJOEntities()) //PARA EDITAR LOS REGISTROS.
            {
                var d = db.MATERIALES.Find(material.ID_MATERIAL);
                d.METERIAL = material.METERIAL;
                db.SaveChanges();

            }
        }

        public void elimina(int id)//ELIMINA LOS REGISROS.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var dl = db.MATERIALES.Find(id);
                db.MATERIALES.Remove(dl);
                db.SaveChanges();
            }
        }
    }
}
