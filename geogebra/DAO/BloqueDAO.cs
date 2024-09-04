using geogebra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad Bloque.
    // Proporciona métodos para interactuar con la tabla "Bloques" en la base de datos.
    public class BloqueDAO
    {
        // Obtiene una lista de todos los bloques desde la base de datos.
        // Devuelve una lista de objetos Bloque.
        public List<Bloque> listaBloques()
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se recuperan y devuelven todos los bloques.
            return contextoBaseDatos.Bloques.ToList();
        }

        // Obtiene un bloque específico desde la base de datos por su identificador.
        // Devuelve un objeto Bloque correspondiente al identificador proporcionado.
        public async Task<Bloque> bloque(string id)
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se busca el bloque por su identificador de forma asíncrona.
            return await contextoBaseDatos.Bloques.FindAsync(id);
        }
    }
}
