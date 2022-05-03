using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Models;
using ProyectoASE.Prueba_Arbol;

namespace ProyectoASE.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public PruebaArbolAVL<PacientesModel> Pacientes = new PruebaArbolAVL<PacientesModel>
        {

        };

        public List<PacientesModel> Edit = new List<PacientesModel>();

        public List<PacientesModel> SearchResult = new List<PacientesModel>
        {
            new PacientesModel
            {
                Name = "No se encuentra",
                NextAppoint = null,
                Description = null,
            }
        };

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }
    }
}
