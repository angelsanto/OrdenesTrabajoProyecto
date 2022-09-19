using ENTIDAD;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
  public  class SOLICITUDAL
    {

        public List<solicitudCE> ListarSoli()
        {
            //CONSULTA PARA MOSTRAR EL EMPLEADO CON SU CARGO Y DEPARTAMENTO

            string sql = @"SELECT 
                         SD.ID_SOLIORDEN,SD.DESCRIPCION,SD.FECHASOLI,SD.ID_EMPLE,SD.ID_CATEGORIA,SD.ID_DEPARTA,E.NON,E.APELLIDO,T.CATEGORIA,D.DEPARTAMENTO
                         FROM SOLIORDEN SD
                         INNER JOIN EMPLEADO E ON SD.ID_EMPLE=E.ID_EMPLE
                         INNER JOIN TIPOSERVICIO T ON SD.ID_CATEGORIA=T.ID_CATEGORIA
                         INNER JOIN DEPARTAMENTO D ON SD.ID_DEPARTA=D.ID_DEPARTA
                         WHERE NOT EXISTS (SELECT NULL
                         FROM ORDENTRABAJO O
                         WHERE O.ID_SOLIORDEN = SD.ID_SOLIORDEN)";

            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION Y CERRARLA LLAMAR A LOS REGISTROS.
            {
                /*db.Configuration.LazyLoadingEnabled = false;*///PARA QUE NO LLEVE DATOS DEL EMPLEADO
                //return db.SOLIORDEN.ToList();
                return db.Database.SqlQuery<solicitudCE>(sql).ToList();
            }

        }

        public List<solicitudCE> ListarSolicitud()
        {
            //CONSULTA PARA MOSTRAR EL EMPLEADO CON SU CARGO Y DEPARTAMENTO

            string sql = @"SELECT 
                         SD.ID_SOLIORDEN,SD.DESCRIPCION,SD.FECHASOLI,SD.ID_EMPLE,SD.ID_CATEGORIA,SD.ID_DEPARTA,E.NON,E.APELLIDO,T.CATEGORIA,D.DEPARTAMENTO
                         FROM SOLIORDEN SD
                         INNER JOIN EMPLEADO E ON SD.ID_EMPLE=E.ID_EMPLE
                         INNER JOIN TIPOSERVICIO T ON SD.ID_CATEGORIA=T.ID_CATEGORIA
                         INNER JOIN DEPARTAMENTO D ON SD.ID_DEPARTA=D.ID_DEPARTA";

            using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION Y CERRARLA LLAMAR A LOS REGISTROS.
            {
                return db.Database.SqlQuery<solicitudCE>(sql).ToList();
            }

        }

        public solicitudCE detallesoli(int id)//DETALLE

        {//CONSULTA PARA QUE AL DETALLE ME APARESCAN LOS NOMBRES DE LOS CARGOS Y DEPARTAMENTOS Y NO EL ID
            string sql = @"select 
                         SD.ID_SOLIORDEN,SD.DESCRIPCION,SD.FECHASOLI,SD.ID_EMPLE,SD.ID_CATEGORIA,SD.ID_DEPARTA,E.NON,E.APELLIDO,T.CATEGORIA,D.DEPARTAMENTO
                         from SOLIORDEN SD
                         INNER JOIN EMPLEADO E ON SD.ID_EMPLE=E.ID_EMPLE
                         INNER JOIN TIPOSERVICIO T ON SD.ID_CATEGORIA=T.ID_CATEGORIA
                         INNER JOIN DEPARTAMENTO D ON SD.ID_DEPARTA=D.ID_DEPARTA
                         WHERE  SD.ID_SOLIORDEN = @SOLICITUID";

            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.Database.SqlQuery<solicitudCE>(sql,
                    new SqlParameter("@SOLICITUID", id)).FirstOrDefault();
                //return db.SOLIORDEN.Find(id);
            }

        }

        public void agregar(SOLIORDEN solicitud)//AGREGAR UTILIZANDO LINQ.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.SOLIORDEN.Add(solicitud);
                db.SaveChanges();
            }

        }

        public void elimina(int id)//ELIMINAR
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.SOLIORDEN.Find(id);
                db.SOLIORDEN.Remove(d);
                db.SaveChanges();

            }

        }

    }
}
