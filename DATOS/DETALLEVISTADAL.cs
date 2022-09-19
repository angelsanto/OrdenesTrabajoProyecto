using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
  public class DETALLEVISTADAL
    {
     
        BSORDENTRABAJOEntities contex =null;
        public List<detalleCE> listadetalle()
        {
            string sql = @"SELECT
                          ID_DETALLE,DO.ID_ORDEN,DO.ID_TRABAJO,T.TRABAJOS,DO.ID_MATERIAL,M.METERIAL,CANTIDAD,OBSERVACION
                          FROM DETALLEORDEN DO
                          INNER JOIN TRABAJOSREALIZADOS T ON T.ID_TRABAJO=DO.ID_TRABAJO
                          INNER JOIN MATERIALES M ON M.ID_MATERIAL=DO.ID_MATERIAL";

            using (var db = new BSORDENTRABAJOEntities())
            {
                return db.Database.SqlQuery<detalleCE>(sql).ToList();
            }

        }

        public List<DETALLEORDEN> lista(int id)
        {
           
            contex = new BSORDENTRABAJOEntities();
                return contex.DETALLEORDEN.Where(x=>x.ID_ORDEN==id).ToList();
           
        }
        
        public void elimina(int id)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.DETALLEORDEN.Find(id);
                db.DETALLEORDEN.Remove(d);
                db.SaveChanges();

            }
        }
        //GUARDAR DETALLE A LA ORDEN
        public void guardarDT(DETALLEORDEN[] detalle)
        {

            using (var db = new BSORDENTRABAJOEntities())
            {
                
                foreach (var item in detalle)
                {
                    DETALLEORDEN D = new DETALLEORDEN();
                    D.ID_ORDEN = item.ID_ORDEN;
                    D.ID_TRABAJO = item.ID_TRABAJO;
                    D.ID_MATERIAL = item.ID_MATERIAL;
                    D.CANTIDAD = item.CANTIDAD;
                    D.OBSERVACION = item.OBSERVACION;
                    db.DETALLEORDEN.Add(D);
                }
                db.SaveChanges();
            }
        }
    }
}
