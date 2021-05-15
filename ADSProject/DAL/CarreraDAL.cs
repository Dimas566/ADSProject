using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADSProject.Models.Context;

namespace ADSProject.DAL
{
    public class CarreraDAL
    {
        // Listado de carreras, a nivel de memoria del proyecto
        //public static List<Carrera> lstCarreras = new List<Carrera>();

        // Instancia del contexto que nos permite conectarnos a la BD
        private MyDbContext _context;

        // En este constructor se recibe el contexto
        // que se manda desde el servicio
        public CarreraDAL(MyDbContext context) { _context = context; }

        public int insertarCarrera(Carrera carrera)
        {
            try
            {
                // Se agrega la carrera que se insertará
                _context.Carrera.Add(carrera);
                // Se guardan los cambios en la BD
                _context.SaveChanges();
                // Se retorna el ID de la carrera recien insertada
                return carrera.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarCarrera(int id, Carrera carrera)
        {
            try
            {
                // Primero se consulta la carrera
               var currentItem = _context.Carrera.SingleOrDefault(temp => temp.id == id);
                // trasladar los valores de la carrera que queremos modificar
                // al registro que acabamos de consultar
                _context.Entry(currentItem).CurrentValues.SetValues(carrera);
                // guardar los cambios en la BD
                _context.SaveChanges();
                // retornamos el ID de la carrera recién modificada
                return carrera.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para eliminar un elemento del listado
        public bool eliminarCarrera(int id)
        {
            try
            {
                // Se consulta la carrera que se quiere eliminar por el ID
                var item = _context.Carrera.SingleOrDefault(x => x.id == id);
                // Remover la carrera recien consultada
                _context.Carrera.Remove(item);
                // Se guardan los cambios en la BD
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para listar todas las carreras
        public List<Carrera> obtenerTodos()
        {
            try
            {
                // Se consultan todos los registros de carrera
                var listado = _context.Carrera.ToList();
                // Retorno el listado de registros.
                return listado;
            } catch( Exception )
            {
                throw;
            }
        }

        // para encontrar un elemento por ID
        public Carrera obtenerPorID(int id)
        {
            try
            {
                // Se obtiene el registro usando el ID
                var elementos = _context.Carrera.SingleOrDefault(temp => temp.id == id);
                // Se retornan los registros
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}