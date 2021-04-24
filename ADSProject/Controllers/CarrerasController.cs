using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

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
                // Validamos que el modelo carrera sea valido
                // segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid)
                {
                    // Esta variable nos sirve para saber si una carrera ha sida
                    // insertada correctamente.
                    int id = 0;
                    // Si el ID es 0; entonces se esta insertando
                    if (carrera.id == 0)
                    {
                       id = servicio.insertar(carrera);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                       id = servicio.modificar(carrera.id, carrera);
                    }

                    // Si el id es mayor a cero, entonces la operacion es correcta
                    if ( id > 0 )
                    {
                        // Si la operacion fue exitosa entonces devolvemos un codigo 200(Sucess)
                        return new JsonHttpStatusResult(carrera, HttpStatusCode.OK);
                    }
                    else
                    {
                        // Si la operación no fue exitosa entonces devolvemos un codigo 202(Accepted)
                        return new JsonHttpStatusResult(carrera, HttpStatusCode.Accepted);
                    }

                } else
                {
                    // Si hubo errores en la validación, entonces devolvemos todos 
                    // los errores del modelo con un código 400 (BadRequest)
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(temp => temp.Errors);
                    return new JsonHttpStatusResult(allErrors, HttpStatusCode.BadRequest);
                }
               // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(carrera, HttpStatusCode.InternalServerError);
               // throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(int id, string operacion)
        {
            try
            {
                // variable que permite controlar si fue eliminado correctamente
                bool correcto = false;
                // Eliminar una carrera
                correcto = servicio.eliminar(id);

                // Si la eliminación fue correcta
                if (correcto)
                {
                    // Se devuelve el id del elemento eliminado
                    // y se retonar un código 200 (sucess)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.OK);
                }else
                {
                    // Si no se puede eliminar, entonces se retorna un código 202(accepted)
                    return new JsonHttpStatusResult(new { id }, HttpStatusCode.Accepted);
                }
               // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new JsonHttpStatusResult(new { id }, HttpStatusCode.InternalServerError);
                //throw;
            }
        }
    }
}