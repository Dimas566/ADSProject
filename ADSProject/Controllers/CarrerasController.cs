using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADSProject.Controllers
{
    public class CarrerasController : Controller
    {
        // instancia del servicio encargado de proveer los metodos
        public ServiceCarreras servicio = new ServiceCarreras();

        public CarrerasController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var carrera = servicio.obtenerTodos();
            return View(carrera);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var carrera = new Carrera();
            // Si el id tiene un valor; entonces se procede  a buscar
            if (id.HasValue)
            {
                carrera = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operacion;
            return View(carrera);
        }

        [HttpPost]
        public ActionResult Form(Carrera carrera)
        {
            try
            {
                // Si el ID es 0; entonces se esta insertando
                if (carrera.id == 0)
                {
                    servicio.insertar(carrera);
                }
                else
                {
                    // Si el ID es distinto de cero entonces estamos modificando
                    servicio.modificar(carrera.id, carrera);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                // Eliminar un 
                servicio.eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}