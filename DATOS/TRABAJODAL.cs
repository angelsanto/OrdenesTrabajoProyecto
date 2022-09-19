using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
 public  class TRABAJODAL
    {
        public List<trabajoCE> ListarTrabajo()
        {
            string sql = @" SELECT 
                            TR.ID_TRABAJO,TR.TRABAJOS,TR.ID_CATEGORIA,T.CATEGORIA
                            FROM TRABAJOSREALIZADOS TR
                            INNER JOIN TIPOSERVICIO T ON TR.ID_CATEGORIA=T.ID_CATEGORIA";

            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION Y CERRARLA LLAMAR A LOS REGISTROS.
            {
                //db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO LLEVE DATOS DEL EMPLEADO
                //return db.TRABAJOSREALIZADOS.ToList();
                return db.Database.SqlQuery<trabajoCE>(sql).ToList();

            }

        }
        //PARA HACER EL SELECT EN CASCADA CON CONDICIONALES.
        public List<TRABAJOSREALIZADOS> ListarTraba(int ID_CATEGO)
        {
            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION Y CERRARLA LLAMAR A LOS REGISTROS.
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO LLEVE DATOS DE OTRA TABLA.
                return db.TRABAJOSREALIZADOS.Where(x => x.ID_CATEGORIA==ID_CATEGO).ToList();
            }

        }

        public void agregar(TRABAJOSREALIZADOS trabajo)//AGREGAR UTILIZANDO LINQ.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.TRABAJOSREALIZADOS.Add(trabajo);
                db.SaveChanges();
            }

        }

        public trabajoCE detalletrabajo(int id)
        {
            string sql = @" SELECT 
                            TR.ID_TRABAJO,TR.TRABAJOS,TR.ID_CATEGORIA,T.CATEGORIA
                            FROM TRABAJOSREALIZADOS TR
                            INNER JOIN TIPOSERVICIO T ON TR.ID_CATEGORIA=T.ID_CATEGORIA
                            WHERE TR.ID_TRABAJO=@TRABAJOID";

            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.Database.SqlQuery<trabajoCE>(sql,
                   new SqlParameter("@TRABAJOID", id)).FirstOrDefault();
                //return db.TRABAJOSREALIZADOS.Find(id);
            }
        }


        public void editar(TRABAJOSREALIZADOS trabajo)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var origen = db.TRABAJOSREALIZADOS.Find(trabajo.ID_TRABAJO);
                origen.TRABAJOS = trabajo.TRABAJOS;
                origen.ID_CATEGORIA = trabajo.ID_CATEGORIA;
                db.SaveChanges();
            }
        }

        public void elimina(int id)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.TRABAJOSREALIZADOS.Find(id);
                db.TRABAJOSREALIZADOS.Remove(d);
                db.SaveChanges();

            }
        }
    }
}
