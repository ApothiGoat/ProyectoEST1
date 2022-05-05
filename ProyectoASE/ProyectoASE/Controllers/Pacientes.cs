using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Helpers;
using ProyectoASE.Models;
using ProyectoASE.Prueba_Arbol;

namespace ProyectoASE.Controllers
{
    public class Pacientes : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            return View(Data.Instance.Pacientes);
        }

        // GET: Pacientes/Details/5
        //ESTE SERVIRÁ COMO NUESTRO EDIT PORQUE EL EDIT NO SIRVE, IDKW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public ActionResult Details(long id)
        {
            var resultado = PacientesModel.SearchDPI(Convert.ToInt64(id));
            return View(resultado);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var nextAppoint = collection["NextAppoint"] != string.Empty ? Convert.ToDateTime(collection["NextAppoint"]) : default;
                var informacion = PacientesModel.Save(new PacientesModel
                {
                    Name = collection["Name"],
                    DPI = Convert.ToInt64(collection["DPI"]),
                    Age = Convert.ToInt32(collection["Age"]),
                    PhoneN = Convert.ToInt32(collection["PhoneN"]),
                    LastAppoint = Convert.ToDateTime(collection["LastAppoint"]),
                    NextAppoint = nextAppoint,
                    Description = collection["Description"],
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacientes/Edit/5
        //ESTE NO SIRVE!!!!!!! NO TOCAR!!!!!!
        public ActionResult Edit(long dpi)
        {
            return View();
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(long dpi, IFormCollection collection)
        {
            try
            {
                var nextAppoint = collection["NextAppoint"] != string.Empty ? Convert.ToDateTime(collection["NextAppoint"]) : default;
                var informacion = PacientesModel.EditSave(new PacientesModel
                {
                    Name = collection["Name"],
                    DPI = Convert.ToInt64(collection["DPI"]),
                    Age = Convert.ToInt32(collection["Age"]),
                    PhoneN = Convert.ToInt32(collection["PhoneN"]),
                    LastAppoint = Convert.ToDateTime(collection["LastAppoint"]),
                    NextAppoint = nextAppoint,
                    Description = collection["Description"],
                }, dpi);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pacientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Busqueda(string option, string search)
        {
            if (option == "Name")
            {
                try
                {
                    var Nombres = PacientesModel.SearchName(search);
                    if(Nombres.Count == 0)
                    {
                        Data.Instance.SearchResult = new List<PacientesModel>
                        {
                            new PacientesModel
                            {
                                Name = "No se encuentra",
                                NextAppoint = null,
                                Description = null,
                            }
                        };
                        View(Data.Instance.SearchResult);
                    }
                    else
                    {
                        return View(Nombres);
                    }
                }
                catch (Exception)
                {

                    return View(RedirectToAction(nameof(Index)));
                }
            }
            else if (option == "DPI")
            {
                try
                {
                    var resultado = PacientesModel.SearchDPI(Convert.ToInt64(search));
                    if (resultado == null)
                    {
                        Data.Instance.SearchResult.Clear();
                        Data.Instance.SearchResult = new List<PacientesModel>
                        {
                            new PacientesModel
                            {
                                Name = "No se encuentra",
                                NextAppoint = null,
                                Description = null,
                            }
                        };
                        View(Data.Instance.SearchResult);
                    }
                    else
                    {
                        PacientesModel.SearchSave(resultado);
                        View(Data.Instance.SearchResult);
                    }
                }
                catch (Exception)
                {

                    return View(Data.Instance.Pacientes);
                }
            }
            else
            {
                return View(Data.Instance.Pacientes);
            }
            return View();
        }
        public ActionResult PlusSix()
        {
            try
            {
                var pacientes = PacientesModel.Six();
                return View(pacientes);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Ortodoncia()
        {
            try
            {
                var pacientes = PacientesModel.SearchOrtodoncia();
                return View(pacientes);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Caries()
        {
            try
            {
                var pacientes = PacientesModel.SearchCaries();
                return View(pacientes);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Specific()
        {
            try
            {
                var pacientes = PacientesModel.Searchspecific();
                return View(pacientes);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
