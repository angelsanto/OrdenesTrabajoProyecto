using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{

    //CAPA DE DATOS ES LA QUE HACE LAS ACCIONES DEL CRUD DE LAS TABLAS DE LA BASE DE DATOS
    public class CARGODAL
    {
        public void Agregar(CARGO cargo)
        {
           
            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION A LA BASE DE DATOS Y TAMBIEN PARA CERRARLA.
            {
                db.CARGO.Add(cargo);// METODO PARA GUARDAR.
                db.SaveChanges();

            }
        }

        public List<CARGO> ListarCargo() //ESTA LINEA LISTA LOS REGISTROS QUE SE MUSTRAN EN LAS TABLAS.
        {   
            using (var db = new BSORDENTRABAJOEntities())
    {

                db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO TRAIGA LOS DATOS DEL EPLEADO YA QUE TIENE UN RELACION CON ESA TABLA PARA LLENAR EL DROPDONLIST
                return db.CARGO.ToList();

    }

    }
        public CARGO detalleCargo(int id)//PARA TRAER EL DETALLE DE LOS REGISTROS
        {
            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.CARGO.Where(d => d.ID_CARGO == id).FirstOrDefault();// PARA BUSCAR EN LA BASE DE DATOS
                //return db.CARGO.Find(id);

            }

        }

        public void editar (CARGO cargo)
        {
            using (var db = new BSORDENTRABAJOEntities()) //PARA EDITAR LOS REGISTROS.
            {
                var d = db.CARGO.Find(cargo.ID_CARGO);
                d.CARGO1 = cargo.CARGO1;
                db.SaveChanges();

            }
        }

        public void elimina (int id)//ELIMINA LOS REGISROS.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var dl = db.CARGO.Find(id);
                db.CARGO.Remove(dl);
                db.SaveChanges();
            }
        }

    }

}
