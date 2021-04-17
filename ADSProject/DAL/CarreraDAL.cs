using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class CarreraDAL
    {
        // Listado de carreras, a nivel de memoria del proyecto
        public static List<Carrera> lstCarreras = new List<Carrera>();

        public CarreraDAL() { }

        public int insertarCarrera(Carrera carrera)
        {
            try
            {
                // Si el listado tiene elementos entonces se genera el ID.
                if (lstCarreras.Count > 0)
                {
                    carrera.id = lstCarreras.Last().id + 1;
                }
                else
                {
                    // Si el listado esta vacio entonces el id será por default 1
                    carrera.id = 1;
                }
                lstCarreras.Add(carrera);
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
                // Buscando el indice en la lista
                lstCarreras[lstCarreras.FindIndex(temp => temp.id == id)] = carrera;
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
                lstCarreras.RemoveAt(lstCarreras.FindIndex(aux => aux.id == id));
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
            return lstCarreras;
        }

        // para encontrar un elemento por ID
        public Carrera obtenerPorID(int id)
        {
            try
            {
                var elementos = lstCarreras.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}