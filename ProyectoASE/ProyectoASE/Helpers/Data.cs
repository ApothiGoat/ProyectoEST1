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
