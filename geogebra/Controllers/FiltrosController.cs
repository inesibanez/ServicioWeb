using geogebra.Models;
using geogebra.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Controllers
{
    // Controlador API para gestionar operaciones de filtrado en la aplicación.
    // Proporciona varios endpoints para recuperar datos relacionados con niveles educativos, cursos, modalidades, clases, bloques y recursos.
    [ApiController]
    [Route("[controller]")]
    public class FiltrosController : Controller
    {
        // Instancias de los servicios utilizados para acceder a los datos.
        private readonly NivelEducalivoService nivelEducalivoService = new NivelEducalivoService();
        private readonly CursoService cursoService = new CursoService();
        private readonly ModalidadService modalidadService = new ModalidadService();
        private readonly ClaseService claseService = new ClaseService();
        private readonly BloqueService bloqueService = new BloqueService();
        private readonly RecursoService recursoService = new RecursoService();

        // Obtiene todos los niveles educativos.
        [HttpGet("nivelesEducativos")]
        public IEnumerable<NivelEducativo> GetNivelesEducativos()
        {
            return nivelEducalivoService.GetNivelesEducativos();
        }

        // Obtiene un nivel educativo específico por su identificador.
        [HttpGet("nivelEducativo/{id}")]
        public Task<NivelEducativo> GetNivelEducativo(string id)
        {
            var nivel = nivelEducalivoService.GetNivelEducativo(id);
            return nivel;
        }

        // Obtiene todos los cursos.
        [HttpGet("cursos")]
        public IEnumerable<Curso> GetCursos()
        {
            return cursoService.GetCursos();
        }

        // Obtiene un curso específico por su identificador.
        [HttpGet("curso/{id}")]
        public Task<Curso> GetCurso(string id)
        {
            var curso = cursoService.GetCurso(id);
            return curso;
        }

        // Obtiene los cursos asociados a un nivel educativo específico.
        [HttpGet("cursosNivelEducativo/{id}")]
        public IEnumerable<Curso> GetCursoPorNivelEducativo(string id)
        {
            var cursos = cursoService.GetCursosByNivelEducativo(id);
            return cursos;
        }

        // Obtiene todas las modalidades.
        [HttpGet("modalidades")]
        public IEnumerable<Modalidad> GetModalidades()
        {
            return modalidadService.GetModalidades();
        }

        // Obtiene una modalidad específica por su identificador.
        [HttpGet("modalidad/{id}")]
        public Task<Modalidad> GetModalidad(string id)
        {
            var modalidad = modalidadService.GetModalidad(id);
            return modalidad;
        }

        // Obtiene las modalidades asociadas a un nivel educativo y curso específicos.
        [HttpGet("modalidadNivelEducativoCurso/{idN}/{idC}")]
        public IEnumerable<Modalidad> GetModalidadPorNivelEducativoYCurso(string idN, string idC)
        {
            var modalidades = modalidadService.GetModalidadesByNivelEducativoYCurso(idN, idC);
            return modalidades;
        }

        // Obtiene una clase específica por su identificador.
        [HttpGet("clase/{id}")]
        public Task<Clase> GetClase(string id)
        {
            var clase = claseService.GetClase(id);
            return clase;
        }

        // Obtiene las clases asociadas a un nivel educativo, curso y modalidad específicos.
        [HttpGet("claseNivelEducativoCursoModalidad/{idN}/{idC}/{idM}")]
        public IEnumerable<Clase> GetClasePorNivelEducativoYCursoYModalidad(string idN, string idC, string idM)
        {
            var clase = claseService.GetClasesByNivelEducativoYCursoYModalidad(idN, idC, idM);
            return clase;
        }

        // Obtiene todos los bloques.
        [HttpGet("bloques")]
        public IEnumerable<Bloque> GetBloques()
        {
            var bloques = bloqueService.GetBloques();
            return bloques;
        }

        // Obtiene un bloque específico por su identificador.
        [HttpGet("bloque/{id}")]
        public Task<Bloque> GetBloque(string id)
        {
            var bloque = bloqueService.GetBloque(id);
            return bloque;
        }

        // Obtiene un recurso específico por su identificador.
        // Esta llamada es vulnerable porque el identificador es ingresado por el usuario.
        // El FRONT no debería permitir identificadores de longitud mayor a 5.
        [HttpGet("recurso/{id}")]
        public Task<RecursoDTO> GetRecurso(string id)
        {
            var recurso = recursoService.GetRecursoBuscado(id);
            return recurso;
        }
    }
}
