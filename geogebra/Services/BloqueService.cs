using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad Bloque.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class BloqueService
    {
        // Instancia del DAO para acceder a los datos de Bloque.
        private readonly BloqueDAO bloqueDao = new BloqueDAO();

        // Obtiene todos los bloques.
        // Devuelve un IEnumerable que contiene objetos Bloque.
        // El bloque con ID "AD" (Recursos Adaptados) se coloca al final de la lista.
        public IEnumerable<Bloque> GetBloques()
        {
            // Llama al método del DAO para obtener la lista de bloques.
            List<Bloque> bloques = bloqueDao.listaBloques();

            // Variable para almacenar el bloque de recursos adaptados.
            Bloque adaptados = null;

            // Itera sobre los bloques y encuentra el bloque con ID "AD".
            foreach (Bloque bloque in bloques)
            {
                if (bloque.id == "AD")
                {
                    adaptados = bloque;
                    break; // Una vez encontrado, se puede salir del bucle.
                }
            }

            // Si se encontró el bloque de adaptados, se mueve al final de la lista.
            if (adaptados != null)
            {
                bloques.Remove(adaptados);
                bloques.Add(adaptados);
            }

            // Convierte la lista a un array y lo devuelve como IEnumerable.
            return bloques.ToArray();
        }

        // Obtiene un bloque específico por su identificador.
        // Devuelve un objeto Task que contiene un Bloque.
        public Task<Bloque> GetBloque(string id)
        {
            // Llama al método del DAO para obtener el bloque por su ID.
            Task<Bloque> bloque = bloqueDao.bloque(id);

            // Devuelve la tarea que contiene el bloque.
            return bloque;
        }
    }
}
