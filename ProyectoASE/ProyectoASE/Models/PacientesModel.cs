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
        public string Name { get; set; }
        [StringLength(13)]
        public long DPI { get; set; }
        [StringLength(3)]
        public int Age { get; set; }
        [StringLength(11)]
        public int PhoneN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastAppoint { get; set; }    
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NextAppoint { get; set; }

        public string Description { get; set; }

        public static bool Save(PacientesModel model)
        {
            Data.Instance.Pacientes.Ingresar(model, Comparar.CompName);
            return true;
        }
        public static bool EditSave(PacientesModel model)
        {
            return true;
        }
        public static bool SearchSave(PacientesModel model)
        {
            Data.Instance.SearchResult.Clear();
            Data.Instance.SearchResult.Add(model);
            return true;
        }
        public static PacientesModel SearchName(string nombre)
        {            
            return Data.Instance.Pacientes.BusquedaCN(nombre, Comparar.SearchName); ;
        }
        public static PacientesModel SearchDPI(long dpi)
        {  
            return Data.Instance.Pacientes.BusquedaCD(dpi, Comparar.SearchDPI); ;
        }
    }
}
