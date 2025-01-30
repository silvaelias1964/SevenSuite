using Application.Models;
using Business.Services;
using DataAccess;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;

namespace SevenSuite.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ISeveClieService seveClieService;
        private readonly IEstadoCivilService estadoCivilService;

        public RegistroController(
            ISeveClieService seveClieService, 
            IEstadoCivilService estadoCivilService) 
        {            
            this.seveClieService = seveClieService;
            this.estadoCivilService = estadoCivilService;
        }

        /// <summary>
        /// Listado de Registros
        /// </summary>
        /// <returns></returns>
        public IActionResult Listado()
        {
            return View(seveClieService.GetAll().ToList());
        }

        /// <summary>
        /// Metodo de creación de datos, Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            LlenarListas();
            return View();
        }
       

        /// <summary>
        /// POST: RegistroController/Create 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeveClieModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    seveClieService.Add(model);
                    TempData["mensaje"] = "El registro se ha creado correctamente.";
                    return Redirect("~/Registro/Listado");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en los datos, revise..");

                    LlenarListas();

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                LlenarListas();

                return View(model);
            }
        }



        /// <summary>
        /// GET: RegistroController/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {

            LlenarListas();

            // Busqueda del registro
            var datos = seveClieService.GetById(id);
            // Mapeado
            if (datos != null)
            {
                var entityModel = new SeveClieModel()
                {
                    id_clie = datos.id_clie,
                    nombre = datos.nombre,
                    genero = datos.genero,
                    cedula = datos.cedula,
                    fecha_nac=datos.fecha_nac,
                    id_estado_civil=datos.id_estado_civil
                };
                return View(entityModel);

            }
            return Redirect("~/Registro/Listado");
        }

        /// <summary>
        /// POST: RegistroController/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeveClieModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    seveClieService.Edit(model);
                    TempData["mensaje"] = "El registro se ha actualizado correctamente.";
                    return Redirect("~/Registro/Listado");

                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en los datos, revise..");

                    LlenarListas();

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                LlenarListas();

                return View(model);
            }
        }


        /// <summary>
        /// GET: RegistroController/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            LlenarListas();

            // Busqueda del registro
            var datos = seveClieService.GetById(id);
            // Mapeado
            if (datos != null)
            {
                var entityModel = new SeveClieModel()
                {
                    id_clie = datos.id_clie,
                    nombre = datos.nombre,
                    genero = datos.genero,
                    cedula = datos.cedula,
                    fecha_nac = datos.fecha_nac,
                    id_estado_civil = datos.id_estado_civil
                };
                return View(entityModel);

            }
            return Redirect("~/Registro/Listado");
        }


        /// <summary>
        /// POST: RegistroController/Delete/5 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SeveClieModel entity)
        {
            try
            {
                string estado = seveClieService.Delete(id);

                if (estado == "")
                {
                    TempData["mensaje"] = "El registro se ha borrado correctamente.";
                    return Redirect("~/Registro/Listado");
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error en el borrado de datos: " + estado);

                    LlenarListas();

                    return View(entity);
                }
            }
            catch (Exception ex)
            {
                foreach (var error in ex.Message.Split("*"))
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                LlenarListas();

                return View(entity);
            }
        }




        /// <summary>
        /// GET: RegistroController/See/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult See(int id)
        {
            LlenarListas();

            // Busqueda del registro
            var datos = seveClieService.GetById(id);
            // Mapeado
            if (datos != null)
            {
                var entityModel = new SeveClieModel()
                {
                    id_clie = datos.id_clie,
                    nombre = datos.nombre,
                    genero = datos.genero,
                    cedula = datos.cedula,
                    fecha_nac = datos.fecha_nac,
                    id_estado_civil = datos.id_estado_civil
                };
                return View(entityModel);

            }
            return Redirect("~/Registro/Listado");

        }

        /// <summary>
        /// Reporte (no finalizado)
        /// </summary>
        /// <returns></returns>
        public IActionResult Reporte()
        {
            //Document doc = new Document(PageSize.Letter);            
            //MemoryStream ms = new MemoryStream();
            //PdfWriter pdfWriter = PdfWriter.GetInstance(doc, ms);
            //doc.AddAuthor("Elias Silva");
            //doc.AddTitle("Reporte de Prueba SS");
            //doc.Open();
            //doc.Add(new Phrase("Prueba de reporte"));
            //pdfWriter.Close();
            //doc.Close();
            
            //return File(ms.ToArray(), "application/pdf");
            return View();            
        }


        /// <summary>
        /// Llenar las listas de los dropdown
        /// </summary>
        private void LlenarListas()
        {
            // Lista estado civil
            List<SelectListItem> lstEdo = new List<SelectListItem>();
            var lista= estadoCivilService.EstadoCivilList();                        
            foreach (var item in lista)
            {                
                lstEdo.Add(new SelectListItem() { Text = item.Text, Value = item.Value });
            }
            lstEdo[0].Selected = true;
            ViewBag.Estado = lstEdo;

            // Listado Genero
            List<SelectListItem> lstGen = new List<SelectListItem>();
            lstGen.Add(new SelectListItem() { Text = "Masculino", Value = "M" });
            lstGen.Add(new SelectListItem() { Text = "Femenino", Value = "F" });            
            ViewBag.Genero = lstGen;


        }


    }
}
