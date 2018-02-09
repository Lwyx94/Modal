using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API_DAL.Listados;

namespace Web_API_BL.Listados
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Obtiene un listado de todas las personas de la BD
        /// </summary>
        /// <returns>List<clsPersona> listadoPersonas</returns>
        public List<clsPersona> getListadoPersonas()
        {
            List<clsPersona> listado = new List<clsPersona>();
            clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();
            listado = listadoDAL.getListadoPersonas();

            return listado;
        }

        /// <summary>
        /// Obtiene una persona segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona persona</returns>
        public clsPersona getPersonaPorID(int id)
        {
            clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();

            return listadoDAL.getPersonaPorID(id);
        }

        /// <summary>
        /// Actualiza en la BD la persona que recibe por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int resultado</returns>
        public int UpdatePersonasBL(clsPersona persona)
        {
            clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();
            int resultado;

            resultado = listadoDAL.updatePersonasDAL(persona);

            return resultado;
        }

        /// <summary>
        /// Elimina una persona de la BD según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int resultado</returns>
        public int DeletePersonasBL(int id)
        {
            clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();
            int resultado;

            resultado = listadoDAL.deletePersonasDAL(id);

            return resultado;
        }

        /// <summary>
        /// Inserta una persona en la BD
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int resultado</returns>
        public int InsertPersonasBL(clsPersona persona)
        {
            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();
            int resultado;
            resultado = listadoPersonasDAL.insertPersonasDAL(persona);
            return resultado;
        }
    }
}
