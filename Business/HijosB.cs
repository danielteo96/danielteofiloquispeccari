using Data.HijosDAO;
using Entity.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HijosB
    {
        HijosDAO hijosDAO = new HijosDAO();
        

        public List<Hijos> Listarhijos()
        {
            List<Hijos> hijosB = hijosDAO.Obtenerhijos(1);


            return hijosB;
        }
        public Hijos insertarhijos(Hijos paramhijos) { 
        Hijos hijos = hijosDAO.Agregar(paramhijos);
            return hijos;
        }

        public Hijos actualizarhijos(Hijos paramhijos)
        {
            Hijos hijos = hijosDAO.Modificar(paramhijos);
            return hijos;
        }
        public void eliminarhijos(int idhijo)
        {
             hijosDAO.eliminar(idhijo);
            
        }
    }
}
