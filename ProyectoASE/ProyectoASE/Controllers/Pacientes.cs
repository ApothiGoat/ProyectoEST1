using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Helpers;
using ProyectoASE.Models;


namespace ProyectoASE.Controllers
{
    public class Pacientes : Controller
    {
        // GET: Pacientes
        public ActionResult Index(AVL<Pacientes> lista)
        {
            return View(Data.Instance.Pacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var informacion = PacientesModel.Save(new PacientesModel
                {
                    Name = collection["Name"],
                    DPI = Convert.ToInt64(collection["DPI"]),
                    Age = Convert.ToInt32(collection["Age"]),
                    PhoneN = Convert.ToInt32(collection["PhoneN"]),
                    LastAppoint = Convert.ToDateTime(collection["LastAppoint"]),
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
    }
}
