using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class TiposerviCN
    {
        private static TIPOSERVDAL obj = new TIPOSERVDAL();

        public static List<TIPOSERVICIO> listarTiposervi()
        {
            return obj.listarTiposervi();

        }

        public static void agregar(TIPOSERVICIO tiposervicio)//AGREGAR UTILIZANDO LINQ
        {
            obj.agregar(tiposervicio);
        }

        public static TIPOSERVICIO detalleservicio(int id)
        {
            return obj.detalleservicio(id);

        }

        public static void elimina(int id)
        {
            obj.elimina(id);
        }

        public static void editar(TIPOSERVICIO tiposervicio)
        {
            obj.editar(tiposervicio);
        }

        }
}
