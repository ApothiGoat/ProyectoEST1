using ProyectoASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE
{
    public delegate int Comparar<T>(T a, T b);

    public class Comparar
    {
        public static int CompName(PacientesModel a, PacientesModel b)
        {
            if (a.Name != b.Name)
            {
                if (a.Name.CompareTo(b.Name) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
