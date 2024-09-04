using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad Clase.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class ClaseService
    {
        // Instancia del DAO para acceder a los datos de Clase.
        private readonly ClaseDAO claseDAO = new ClaseDAO();

        // Obtiene una clase específica por su identificador.
        // Devuelve un objeto Task que contiene una Clase.
        public Task<Clase> GetClase(string id)
        {
            // Llama al método del DAO para obtener la clase por su ID.
            Task<Clase> clase = claseDAO.clase(id);

            // Devuelve la tarea que contiene la clase.
            return clase;
        }

        // Obtiene todas las clases asociadas a un nivel educativo, curso y modalidad específicos.
        // Devuelve un IEnumerable que contiene objetos Clase.
        public IEnumerable<Clase> GetClasesByNivelEducativoYCursoYModalidad(string idNivelEducativo, string idCurso, string idModalidad)
        {
            // Llama al método del DAO para obtener las clases por nivel educativo, curso y modalidad.
            List<Clase> clases = claseDAO.claseByNivelEducativoCursoYModalidad(idNivelEducativo, idCurso, idModalidad);

            // Convierte la lista a un array y lo devuelve como IEnumerable.
            return clases.ToArray();
        }
    }
}
