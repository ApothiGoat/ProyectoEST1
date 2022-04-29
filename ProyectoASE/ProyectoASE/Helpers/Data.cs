using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Models;

namespace ProyectoASE.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public AVL<PacientesModel> Pacientes = new AVL<PacientesModel>();

        public List<PacientesModel> SearchResult = new List<PacientesModel>
        {
            new PacientesModel
            {
                Name = "No se encuentra",
                LastAppoint = null,
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
