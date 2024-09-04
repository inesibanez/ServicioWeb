using geogebra.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad Clase.
    // Proporciona métodos para interactuar con la tabla "Clases" en la base de datos.
    public class ClaseDAO
    {
        // Obtiene una clase específica desde la base de datos por su identificador.
        // Devuelve un objeto Clase correspondiente al identificador proporcionado,
        // incluyendo las entidades relacionadas de NivelEducativo, Curso y Modalidad.
        public async Task<Clase> clase(string id)
        {
            Context contextoBaseDatos = new Context();
            var clase = contextoBaseDatos.Clases.Where(c => c.id == id)
                                                .Include(b => b.nivelEducativo)
                                                .Include(b => b.curso)
                                                .Include(b => b.modalidad)
                                                .FirstOrDefault();
            return clase;
        }

        // Obtiene una lista de clases desde la base de datos para un nivel educativo específico.
        // Devuelve una lista de objetos Clase, incluyendo las entidades relacionadas de Curso.
        public List<Clase> clasesByNivelEducativo(string id)
        {
            Context contextoBaseDatos = new Context();
            var clases = contextoBaseDatos.Clases.Where(c => c.idNivelEducativo == id)
                                                 .Include(b => b.curso)
                                                 .ToList();
            return clases;
        }

        // Obtiene una lista de clases desde la base de datos para un nivel educativo y curso específicos.
        // Devuelve una lista de objetos Clase, incluyendo las entidades relacionadas de Modalidad.
        public List<Clase> claseByNivelEducativoYCurso(string idNivel, string idCurso)
        {
            Context contextoBaseDatos = new Context();
            var clases = contextoBaseDatos.Clases.Where(c => c.idNivelEducativo == idNivel && c.idCurso == idCurso)
                                                 .Include(b => b.modalidad)
                                                 .ToList();
            return clases;
        }

        // Obtiene una lista de clases desde la base de datos para un nivel educativo, curso y modalidad específicos.
        // Devuelve una lista de objetos Clase.
        public List<Clase> claseByNivelEducativoCursoYModalidad(string idNivel, string idCurso, string idModalidad)
        {
            Context contextoBaseDatos = new Context();
            var clases = contextoBaseDatos.Clases.Where(c => c.idNivelEducativo == idNivel && c.idCurso == idCurso && c.idModalidad == idModalidad)
                                                 .ToList();
            return clases;
        }
    }
}
