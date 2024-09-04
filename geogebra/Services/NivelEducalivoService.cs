using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad NivelEducativo.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class NivelEducativoService
    {
        // Instancia del DAO para acceder a los datos de NivelEducativo.
        private readonly NivelEducativoDAO nivelDao = new NivelEducativoDAO();

        // Obtiene todos los niveles educativos.
        // Devuelve un IEnumerable que contiene objetos NivelEducativo.
        public IEnumerable<NivelEducativo> GetNivelesEducativos()
        {
            // Llama al método del DAO para obtener la lista de niveles educativos.
            List<NivelEducativo> niveles = nivelDao.listaNivelesEducativos();

            // Convierte la lista a un array y lo devuelve como IEnumerable.
            return niveles.ToArray();
        }

        // Obtiene un nivel educativo específico por su identificador.
        // Devuelve un objeto Task que contiene un NivelEducativo.
        public Task<NivelEducativo> GetNivelEducativo(string id)
        {
            // Llama al método del DAO para obtener el nivel educativo por su ID.
            Task<NivelEducativo> nivel = nivelDao.nivelEducativo(id);

            // Devuelve la tarea que contiene el nivel educativo.
            return nivel;
        }
    }
}
