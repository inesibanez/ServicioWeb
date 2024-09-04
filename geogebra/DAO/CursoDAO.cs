using geogebra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad Curso.
    // Proporciona métodos para interactuar con la tabla "Cursos" en la base de datos.
    public class CursoDAO
    {
        // Obtiene una lista de todos los cursos desde la base de datos.
        // Devuelve una lista de objetos Curso.
        public List<Curso> listaCursos()
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se recuperan y devuelven todos los cursos.
            return contextoBaseDatos.Cursos.ToList();
        }

        // Obtiene un curso específico desde la base de datos por su identificador.
        // Devuelve un objeto Curso correspondiente al identificador proporcionado.
        public async Task<Curso> curso(string id)
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se busca el curso por su identificador de forma asíncrona.
            return await contextoBaseDatos.Cursos.FindAsync(id);
        }
    }
}
