using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_BL.Listados;

namespace Web_API_UI.Controllers
{
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        /// <summary>
        /// Hace una llamada GET al listado de personas de la API para obtener todas las personas
        /// </summary>
        /// <returns>IEnumerable personas</returns>
        public IEnumerable<clsPersona> Get()
        {
            clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
            return listadoBL.getListadoPersonas();
        }

        // GET: api/Personas/5
        /// <summary>
        /// Hace una llamada GET a un elemento persona de la API para obtener una persona según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona persona</returns>
        public clsPersona Get(int id)
        {
            clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
            return listadoBL.getPersonaPorID(id);
        }

        // POST: api/Personas
        /// <summary>
        /// Hace una llamada POST a la API para publicar una nueva persona
        /// </summary>
        /// <param name="persona"></param>
        public void Post([FromBody]clsPersona persona)
        {
            clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
            listadoBL.InsertPersonasBL(persona);
        }

        // PUT: api/Personas/5
        /// <summary>
        /// Hace una llamada PUT a la API para actualizar una persona según su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="persona"></param>
        public void Put(int id, [FromBody]clsPersona persona)
        {
            clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
            persona.idPersona = id;
            listadoBL.UpdatePersonasBL(persona);
        }

        // DELETE: api/Personas/5
        /// <summary>
        /// Hace una llamada DELETE a la API para eliminar una persona según su id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
            listadoBL.DeletePersonasBL(id);
        }
    }
}
