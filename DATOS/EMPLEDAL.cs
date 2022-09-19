using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class EMPLEDAL
    {

        public void agregar(EMPLEADO empleado)//AGREGAR UTILIZANDO LINQ.
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                db.EMPLEADO.Add(empleado);
                db.SaveChanges();
            }

        }
        public List<empleadoCE> listaremple()//LISTAR EMPLEADOS
        {//CONSULTA PARA MOSTRAR EL EMPLEADO CON SU CARGO Y DEPARTAMENTO
            string sql = @"SELECT 
                         E.ID_EMPLE,E.DNI,E.NON,E.APELLIDO,E.ID_CARGO,E.ID_DEPARTA,C.CARGO,D.DEPARTAMENTO
                         FROM EMPLEADO E
                         INNER JOIN CARGO C ON E.ID_CARGO=C.ID_CARGO
                         INNER JOIN DEPARTAMENTO D ON E.ID_DEPARTA=D.ID_DEPARTA";

            using (var db = new BSORDENTRABAJOEntities())
            {
                return db.Database.SqlQuery<empleadoCE>(sql).ToList();
            }
        }


        public empleadoCE detallemple(int id)//DETALLE

        {//CONSULTA PARA QUE AL DETALLE ME APARESCAN LOS NOMBRES DE LOS CARGOS Y DEPARTAMENTOS Y NO EL ID
            string sql = @"SELECT 
                         E.ID_EMPLE,E.DNI,E.NON,E.APELLIDO,E.ID_CARGO,E.ID_DEPARTA,C.CARGO,D.DEPARTAMENTO
                         FROM EMPLEADO E
                         INNER JOIN CARGO C ON E.ID_CARGO=C.ID_CARGO
                         INNER JOIN DEPARTAMENTO D ON E.ID_DEPARTA=D.ID_DEPARTA
                         WHERE  E.ID_EMPLE = @EMPLEADOID";

            using (var db = new BSORDENTRABAJOEntities())
            {

                return db.Database.SqlQuery<empleadoCE>(sql,
                    new SqlParameter("@EMPLEADOID", id)).FirstOrDefault();
                //return db.EMPLEADO.Find(id);
            }

        }
        public void elimina(int id)//ELIMINAR
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var d = db.EMPLEADO.Find(id);
                db.EMPLEADO.Remove(d);
                db.SaveChanges();

            }

        }

        public void editar (EMPLEADO empleado)
        {
            using (var db = new BSORDENTRABAJOEntities())
            {
                var origen = db.EMPLEADO.Find(empleado.ID_EMPLE);
                origen.DNI = empleado.DNI;
                origen.NON = empleado.NON;
                origen.APELLIDO = empleado.APELLIDO;
                origen.ID_CARGO = empleado.ID_CARGO;
                origen.ID_DEPARTA = empleado.ID_DEPARTA;
                db.SaveChanges();
            }
        }
   
    }
}
