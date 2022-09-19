using ENTIDAD;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
   public class ORDENDAL
    {
        
        public List<ordenCE> listarOrden()
        {
            //CONSULTA PARA MOSTRAR EL EMPLEADO CON SU CARGO Y DEPARTAMENTO
            string sql = @"SELECT 
                           OT.ID_ORDEN,OT.FECHAINICIO,OT.FECHAFINAL,OT.ID_EMPLE,
                           E.NON,E.APELLIDO,OT.ID_MANTENI,M.MANTENIMIENTO,
                           OT.ID_SOLIORDEN,SO.DESCRIPCION
                           FROM ORDENTRABAJO OT
                           INNER JOIN EMPLEADO E ON OT.ID_EMPLE=E.ID_EMPLE
                           INNER JOIN MANTENIMIENTO M ON OT.ID_MANTENI=M.ID_MANTENI
                           INNER JOIN SOLIORDEN SO ON OT.ID_SOLIORDEN=SO.ID_SOLIORDEN";

            using (var db = new BSORDENTRABAJOEntities())
            {
               
                return db.Database.SqlQuery<ordenCE>(sql).ToList();
                //db.Configuration.LazyLoadingEnabled = false;
                //return db.ORDENTRABAJO.ToList();
            }

        }

        //PARA QUE SOLO LISTE EN EL SELEC LOS ACTUALES.
        public List<ORDENTRABAJO> listarOrde()
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var today = DateTime.Now.Date;
                return db.ORDENTRABAJO.Where(f => f.FECHAFINAL > today).ToList();//EXPRECION LAMBDA
            }

        }
        public ordenCE detalleorden(int id)//DETALLE

        {//CONSULTA PARA QUE AL DETALLE ME APARESCAN LOS NOMBRES DE LOS CARGOS Y DEPARTAMENTOS Y NO EL ID
            string sql = @"SELECT 
                           OT.ID_ORDEN,OT.FECHAINICIO,OT.FECHAFINAL,OT.ID_EMPLE,
                           E.NON,E.APELLIDO,OT.ID_MANTENI,M.MANTENIMIENTO,
                           OT.ID_SOLIORDEN,SO.DESCRIPCION
                           FROM ORDENTRABAJO OT
                           INNER JOIN EMPLEADO E ON OT.ID_EMPLE=E.ID_EMPLE
                           INNER JOIN MANTENIMIENTO M ON OT.ID_MANTENI=M.ID_MANTENI
                           INNER JOIN SOLIORDEN SO ON OT.ID_SOLIORDEN=SO.ID_SOLIORDEN
                           WHERE OT.ID_ORDEN=@ORDENID";

            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.Database.SqlQuery<ordenCE>(sql,
                    new SqlParameter("@ORDENID", id)).FirstOrDefault();
                //return db.EMPLEADO.Find(id);
            }
        }
        public void agregar(ORDENTRABAJO orden)//AGREGAR UTILIZANDO LINQ.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.ORDENTRABAJO.Add(orden);
                db.SaveChanges();
            }

        }

        public void editar(ORDENTRABAJO orden)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var origen = db.ORDENTRABAJO.Find(orden.ID_ORDEN);
                origen.FECHAINICIO = orden.FECHAINICIO;
                origen.FECHAFINAL = orden.FECHAFINAL;
                origen.ID_EMPLE = orden.ID_EMPLE;
                origen.ID_MANTENI = orden.ID_MANTENI;
                origen.ID_SOLIORDEN = orden.ID_SOLIORDEN;
                db.SaveChanges();
            }
        }

        public void elimina(int id)//ELIMINAR
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.ORDENTRABAJO.Find(id);
                db.ORDENTRABAJO.Remove(d);
                db.SaveChanges();

            }

        }
    }
}
