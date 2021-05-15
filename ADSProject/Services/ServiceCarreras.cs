using ADSProject.DAL;
using ADSProject.Models;
using ADSProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceCarreras
    {
        // Instancia para acceder a todos los metodos de la DAL
       // public CarreraDAL carreraDal = new CarreraDAL();

        // Para insertar carrera
        public int insertar(Carrera carrera)
        {
            try
            {
                // Inicializar el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    // crear instancia de la DAL
                    // y se le pasa el contexto de la BD
                    CarreraDAL dal = new CarreraDAL(context);
                    // Llamada al método para obtener todos los registros
                    return dal.insertarCarrera(carrera);
                }
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
                // Inicializar el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    // crear instancia de la DAL
                    // y se le pasa el contexto de la BD
                    CarreraDAL dal = new CarreraDAL(context);
                    // Llamada al método para obtener todos los registros
                    return dal.modificarCarrera(id,carrera);
                }
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
                // Inicializar el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    // crear instancia de la DAL
                    // y se le pasa el contexto de la BD
                    CarreraDAL dal = new CarreraDAL(context);
                    // Llamada al método para obtener todos los registros
                    return dal.eliminarCarrera(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para obtener todos las carreras.
        public List<Carrera> obtenerTodos()
        {
            try
            {
                // Inicializar el contexto que nos permitirá conectarnos con la BD
                using( MyDbContext context = new MyDbContext() )
                {
                    // crear instancia de la DAL
                    // y se le pasa el contexto de la BD
                    CarreraDAL dal = new CarreraDAL(context);
                    // Llamada al método para obtener todos los registros
                    return dal.obtenerTodos();
                }
            }catch( Exception )
            {
                throw;
            }
        }

        // Para obtener por ID.
        public Carrera obtenerPorID(int id)
        {
            try
            {
                // Inicializar el contexto que nos permitirá conectarnos con la BD
                using (MyDbContext context = new MyDbContext())
                {
                    // crear instancia de la DAL
                    // y se le pasa el contexto de la BD
                    CarreraDAL dal = new CarreraDAL(context);
                    // Llamada al método para obtener todos los registros
                    return dal.obtenerPorID(id);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}