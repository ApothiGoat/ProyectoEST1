using ProyectoASE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE
{
    public delegate int Comparar<T>(T a, T b);
    public delegate int CompararN<T>(string a, T b);
    public delegate int CompararD<T>(int a, T b);

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
        public static int SearchName(string a, PacientesModel b)
        {
            if (a == b.Name)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static int SearchDPI(int a, PacientesModel b)
        {
            if (a == b.DPI)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
