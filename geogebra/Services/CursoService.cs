using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad Curso.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class CursoService
    {
        // Instancia del DAO para acceder a los datos de Curso.
        private readonly CursoDAO cursoDao = new CursoDAO();

        // Instancia del DAO para acceder a los datos de Clase.
        private readonly ClaseDAO claseDAO = new ClaseDAO();

        // Obtiene todos los cursos.
        // Devuelve un IEnumerable que contiene objetos Curso.
        public IEnumerable<Curso> GetCursos()
        {
            // Llama al método del DAO para obtener la lista de cursos.
            List<Curso> cursos = cursoDao.listaCursos();

            // Convierte la lista a un array y lo devuelve como IEnumerable.
            return cursos.ToArray();
        }

        // Obtiene un curso específico por su identificador.
        // Devuelve un objeto Task que contiene un Curso.
        public Task<Curso> GetCurso(string id)
        {
            // Llama al método del DAO para obtener el curso por su ID.
            Task<Curso> curso = cursoDao.curso(id);

            // Devuelve la tarea que contiene el curso.
            return curso;
        }

        // Obtiene todos los cursos asociados a un nivel educativo específico.
        // Devuelve un IEnumerable que contiene objetos Curso.
        public IEnumerable<Curso> GetCursosByNivelEducativo(string idNivelEducativo)
        {
            // Llama al método del DAO para obtener las clases asociadas al nivel educativo.
            List<Clase> clases = claseDAO.clasesByNivelEducativo(idNivelEducativo);

            // Crea un conjunto para almacenar los cursos únicos.
            HashSet<Curso> cursos = new HashSet<Curso>();

            // Itera sobre las clases y añade los cursos al conjunto.
            foreach (Clase c in clases) 
            {
                cursos.Add(c.curso);
            }

            // Convierte el conjunto a un array y lo devuelve como IEnumerable.
            return cursos.ToArray();
        }
    }
}
