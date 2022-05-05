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
    public delegate int CompararDescription<T>(T Des);

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

            if (diff.Value.TotalDays > 183 && last.Description == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int SearchOrto(PacientesModel Des)
        {
            DateTime? today = DateTime.Today;
            TimeSpan? diff = today - Des.LastAppoint;

            if (Des.Description.Contains("Ortodoncia") || Des.Description.Contains("ortodoncia"))
            {
                if (diff.Value.TotalDays > 61)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int SearchCarie(PacientesModel Des)
        {
            DateTime? today = DateTime.Today;
            TimeSpan? diff = today - Des.LastAppoint;

            if (Des.Description.Contains("Caries") || Des.Description.Contains("caries"))
            {
                if (diff.Value.TotalDays > 122)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int SearchSpecific(PacientesModel Des)
        {

            DateTime? today = DateTime.Today;
            TimeSpan? diff = today - Des.LastAppoint;

            if (Des.Description.Contains("Caries") || Des.Description.Contains("caries") || Des.Description.Contains("Ortodoncia") || Des.Description.Contains("ortodoncia") || Des.Description == "")
            {
                return 0;
            }
            else
            {
                if (diff.Value.TotalDays > 183)
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
}
