using geogebra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad NivelEducativo.
    // Proporciona métodos para interactuar con la tabla "NivelesEducativos" en la base de datos.
    public class NivelEducativoDAO
    {
        // Obtiene una lista de todos los niveles educativos desde la base de datos.
        // Devuelve una lista de objetos NivelEducativo.
        public List<NivelEducativo> listaNivelesEducativos()
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se recuperan y devuelven todos los niveles educativos.
            return contextoBaseDatos.NivelesEducativos.ToList(); 
        }

        // Obtiene un nivel educativo específico desde la base de datos por su identificador.
        // Devuelve un objeto NivelEducativo correspondiente al identificador proporcionado.
        public async Task<NivelEducativo> nivelEducativo(string id)
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se busca el nivel educativo por su identificador de forma asíncrona.
            return await contextoBaseDatos.NivelesEducativos.FindAsync(id);
        }
    }
}
