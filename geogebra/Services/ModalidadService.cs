using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad Modalidad.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class ModalidadService
    {
        // Instancia del DAO para acceder a los datos de Modalidad.
        private readonly ModalidadDAO modalidadDao = new ModalidadDAO();

        // Instancia del DAO para acceder a los datos de Clase.
        private readonly ClaseDAO claseDAO = new ClaseDAO();

        // Obtiene todas las modalidades.
        // Devuelve un IEnumerable que contiene objetos Modalidad.
        public IEnumerable<Modalidad> GetModalidades()
        {
            // Llama al método del DAO para obtener la lista de modalidades.
            List<Modalidad> modalidades = modalidadDao.listaModalidades();

            // Convierte la lista a un array y lo devuelve como IEnumerable.
            return modalidades.ToArray();
        }

        // Obtiene una modalidad específica por su identificador.
        // Devuelve un objeto Task que contiene una Modalidad.
        public Task<Modalidad> GetModalidad(string id)
        {
            // Llama al método del DAO para obtener la modalidad por su ID.
            Task<Modalidad> modalidad = modalidadDao.modalidad(id);

            // Devuelve la tarea que contiene la modalidad.
            return modalidad;
        }

        // Obtiene todas las modalidades asociadas a un nivel educativo y curso específicos.
        // Devuelve un IEnumerable que contiene objetos Modalidad.
        public IEnumerable<Modalidad> GetModalidadesByNivelEducativoYCurso(string idNivelEducativo, string idCurso)
        {
            // Llama al método del DAO para obtener las clases asociadas al nivel educativo y curso.
            List<Clase> clases = claseDAO.claseByNivelEducativoYCurso(idNivelEducativo, idCurso);

            // Crea un conjunto para almacenar las modalidades únicas.
            HashSet<Modalidad> modalidades = new HashSet<Modalidad>();

            // Itera sobre las clases y añade las modalidades al conjunto.
            foreach (Clase c in clases)
            {
                modalidades.Add(c.modalidad);
            }

            // Convierte el conjunto a un array y lo devuelve como IEnumerable.
            return modalidades.ToArray();
        }
    }
}
