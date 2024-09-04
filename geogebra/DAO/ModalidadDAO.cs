using geogebra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad Modalidad.
    // Proporciona métodos para interactuar con la tabla "Modalidades" en la base de datos.
    public class ModalidadDAO
    {
        // Obtiene una lista de todas las modalidades desde la base de datos.
        // Devuelve una lista de objetos Modalidad.
        public List<Modalidad> listaModalidades()
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se recuperan y devuelven todas las modalidades.
            return contextoBaseDatos.Modalidades.ToList();
        }

        // Obtiene una modalidad específica desde la base de datos por su identificador.
        // Devuelve un objeto Modalidad correspondiente al identificador proporcionado.
        public async Task<Modalidad> modalidad(string id)
        {
            // Se crea una instancia del contexto de base de datos.
            Context contextoBaseDatos = new Context();
            // Se busca la modalidad por su identificador de forma asíncrona.
            return await contextoBaseDatos.Modalidades.FindAsync(id);
        }
    }
}
