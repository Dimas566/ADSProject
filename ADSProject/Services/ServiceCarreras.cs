using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceCarreras
    {
        // Instancia para acceder a todos los metodos de la DAL
        public CarreraDAL carreraDal = new CarreraDAL();

        // Para insertar carrera
        public int insertar(Carrera carrera)
        {
            try
            {
                return carreraDal.insertarCarrera(carrera);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para modificar una carrera
        public int modificar(int id, Carrera carrera)
        {
            try
            {
                return carreraDal.modificarCarrera(id, carrera);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para eliminar

        public bool eliminar(int id)
        {
            try
            {
                return carreraDal.eliminarCarrera(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para obtener todos las carreras.
        public List<Carrera> obtenerTodos()
        {
            return carreraDal.obtenerTodos();
        }

        // Para obtener por ID.
        public Carrera obtenerPorID(int id)
        {
            try
            {
                return carreraDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}