using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class OrdenCN
    {
        private static ORDENDAL obj = new ORDENDAL();

        public static List<ordenCE> listarOrden()
        {
            return obj.listarOrden();

        }
        //PARA LISTAR LOS ACTUALES
        public static List<ORDENTRABAJO> listarOrde()
        {
            return obj.listarOrde();
        }
        public static ordenCE detalleorden(int id)//DETALLE

        {
            return obj.detalleorden(id);
        }

        public static void agregar(ORDENTRABAJO orden)//AGREGAR UTILIZANDO LINQ.
        {
            obj.agregar(orden);
        }

        public static void editar(ORDENTRABAJO orden)
        {
            obj.editar(orden);

        }
        public static void elimina(int id)//ELIMINAR
        {
            obj.elimina(id);
        }

        ////AGREGAR DETALLE A LA ORDEN
        //public static void guardarDT(/*int ordenid,*/ DETALLEORDEN[] detalle/*int trabajoid, int materialid, string cantidad, string observacion*/)
        //{
        //    obj.guardarDT(/*ordenid,*/ detalle/*trabajoid, materialid, cantidad, observacion*/);
        //}

        }
    }
