using ProyectoASE.Models;
using ProyectoASE.Prueba_Arbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE
{
    public delegate int Comparar<T>(T a, T b);
    public delegate int CompararN<T>(string a, T b);
    public delegate int CompararD<T>(long a, T b);
    public delegate int CompararTime<T>(T last);

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
        public static int SearchDPI(long a, PacientesModel b)
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
        public static int SixMonths(PacientesModel last)
        {
            DateTime? today = DateTime.Today;
            TimeSpan? diff = today - last.LastAppoint;
            if(diff.Value.TotalDays > 180)
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
