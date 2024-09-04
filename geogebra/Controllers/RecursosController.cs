using geogebra.Models;
using geogebra.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Controllers
{
    // Controlador API para gestionar operaciones relacionadas con los recursos en la aplicación.
    // Proporciona varios endpoints para recuperar datos de recursos.
    [ApiController]
    [Route("[controller]")]
    public class RecursosController : ControllerBase
    {
        // Instancia del servicio utilizado para acceder a los datos de Recurso.
        private readonly RecursoService recursoService = new RecursoService();

        // Obtiene un recurso específico por su identificador.
        [HttpGet("recurso/{id}")]
        public Task<Recurso> GetRecurso(string id)
        {
            // Llama al servicio para obtener el recurso por su ID.
            var recurso = recursoService.GetRecurso(id);

            // Devuelve la tarea que contiene el recurso.
            return recurso;
        }

        // Obtiene y ordena los recursos de una clase específica, comenzando por un bloque dado.
        // Devuelve un IEnumerable que contiene objetos RecursoDTO.
        [HttpGet("recursosClaseOrdenados/{idC}/{idB}")]
        public IEnumerable<RecursoDTO> GetRecursosOrdenados(string idC, string idB)
        {
            // Llama al servicio para obtener y ordenar los recursos por clase y bloque.
            var recurso = recursoService.GetRecursosByClaseOrdenados(idC, idB);

            // Devuelve los recursos ordenados.
            return recurso;
        }

        // Obtiene los recursos de una clase y bloque específicos.
        // Devuelve un IEnumerable que contiene objetos Recurso.
        [HttpGet("recursosClaseBloque/{idC}/{idB}")]
        public IEnumerable<Recurso> GetRecursos(string idC, string idB)
        {
            // Llama al servicio para obtener los recursos por clase y bloque.
            var recurso = recursoService.GetRecursosByClaseYBloque(idC, idB);

            // Devuelve los recursos.
            return recurso;
        }
    }
}
