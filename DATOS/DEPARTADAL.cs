using ENTIDAD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DEPARTADAL
    {     
            public void agregar(DEPARTAMENTO departamento)//AGREGAR UTILIZANDO LINQ
            {
                using (var db = new BSORDENTRABAJOEntities())
                {
                    db.DEPARTAMENTO.Add(departamento);
                    db.SaveChanges();
                }

            }
            public List<DEPARTAMENTO> ListarDepart()
            {
                using (var db = new BSORDENTRABAJOEntities())//PARA ABRIR LA CONEXION Y CERRARLA LLAMAR A LOS REGISTROS.
                {
                    db.Configuration.LazyLoadingEnabled = false;//PARA QUE NO LLEVE DATOS DEL EMPLEADO
                    return db.DEPARTAMENTO.ToList();

                }

            }
            public DEPARTAMENTO detalledepa(int id)//DETALLE

            {
                using (var db = new BSORDENTRABAJOEntities())
                {

                    return db.DEPARTAMENTO.Find(id);
                }

            }
            public void editar(DEPARTAMENTO departamento)//EDITAR
            {

                using (var db = new BSORDENTRABAJOEntities())

                {
                    var d = db.DEPARTAMENTO.Find(departamento.ID_DEPARTA);
                    d.DEPARTAMENTO1 = departamento.DEPARTAMENTO1;
                    db.SaveChanges();
                }
            }
            public void elimina(int id)//ELIMINAR
            {
                using (var db = new BSORDENTRABAJOEntities())
                {
                    var d = db.DEPARTAMENTO.Find(id);
                    db.DEPARTAMENTO.Remove(d);
                    db.SaveChanges();

                }

            }

        }
    }

