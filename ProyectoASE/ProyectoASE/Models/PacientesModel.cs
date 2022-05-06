using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Helpers;

namespace ProyectoASE.Models
{
    public class PacientesModel
    {
        [StringLength(45)]
        [Display(Name = "Nombre"), Required]
        public string Name { get; set; }
        [StringLength(13)]
        [Display(Name = "DPI"), Required]
        public long DPI { get; set; }
        [StringLength(3)]
        [Display(Name = "Edad"), Required]
        public int Age { get; set; }
        [StringLength(11)]
        [Display(Name = "Telefono de contacto"), Required]
        public int PhoneN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ultima Consulta"), Required]
        public DateTime LastAppoint { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Proxima Consulta")]
        public DateTime? NextAppoint { get; set; }

        [Display(Name = "Descripcion"), Required]
        public string Description { get; set; }

        public static bool Save(PacientesModel model)
        {
            bool succes = Data.Instance.Pacientes.Ingresar(model, Comparar.CompName, Comparar.CheckDay);
            return succes;
        }
        public static bool EditSave(PacientesModel model, long dpi)
        {
            Data.Instance.Pacientes.EditarCall(model, dpi, Comparar.SearchDPI);
            return true;
        }
        public static bool SearchSave(PacientesModel model)
        {
            Data.Instance.SearchResult.Clear();
            Data.Instance.SearchResult.Add(model);
            return true;
        }
        public static List<PacientesModel> SearchName(string nombre)
        {
            return Data.Instance.Pacientes.BusquedaCN(nombre, Comparar.SearchName);
        }
        public static PacientesModel SearchDPI(long dpi)
        {
            return Data.Instance.Pacientes.BusquedaCD(dpi, Comparar.SearchDPI);
        }
        public static List<PacientesModel> Six()
        {
            return Data.Instance.Pacientes.FindFollowUpNeeded(Comparar.SixMonths);
        }

        public static List<PacientesModel> SearchOrtodoncia()
        {

           return Data.Instance.Pacientes.FindOrtodoncia(Comparar.SearchOrto);
        }

        public static List<PacientesModel> SearchCaries()
        {
            return Data.Instance.Pacientes.FindCaries(Comparar.SearchCarie);
        }

        public static List<PacientesModel> Searchspecific()
        {
            return Data.Instance.Pacientes.FindSpecific(Comparar.SearchSpecific);
        }
    }
}
