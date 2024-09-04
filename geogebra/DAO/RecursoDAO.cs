using geogebra.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geogebra.DAO
{
    // Clase de acceso a datos (DAO) para la entidad Recurso.
    // Proporciona métodos para interactuar con la tabla "Recursos" en la base de datos.
    public class RecursoDAO
    {
        // Obtiene un recurso específico desde la base de datos por su identificador.
        // Devuelve un objeto Recurso correspondiente al identificador proporcionado.
        public async Task<Recurso> recurso(string id)
        {
            Context contextoBaseDatos = new Context();
            return await contextoBaseDatos.Recursos.FindAsync(id);
        }

        // Obtiene un recurso desde la base de datos por su identificador de búsqueda.
        // Transforma el recurso en un objeto RecursoDTO, que incluye el id del bloque y de la clase asociados.
        public async Task<RecursoDTO> recursoBusqueda(string id)
        {
            Context contextoBaseDatos = new Context();
            var recurso = contextoBaseDatos.Recursos.Where(r => r.idBusqueda == id).FirstOrDefault();
            var recClaBlo = contextoBaseDatos.RecClaBloq.Where(r => r.idRecurso == recurso.id).FirstOrDefault();
            var rec = RecursoDTO.transformaEnDTO(recurso, recClaBlo.idBloque, recClaBlo.idClase);

            return rec;
        }

        // Obtiene una lista de relaciones RecursoClaseBloque desde la base de datos para una clase específica.
        // Los resultados están ordenados por el identificador del bloque.
        // Devuelve una lista de objetos RecursoClaseBloque que incluye la entidad relacionada Recurso.
        public List<RecursoClaseBloque> recursosByClaseOrdenados(string idClase)
        {
            Context contextoBaseDatos = new Context();
            var recClaBlo = contextoBaseDatos.RecClaBloq.Where(r => r.idClase == idClase)
                                                        .Include(r => r.recurso)
                                                        .OrderBy(r => r.idBloque)
                                                        .ToList();
            return recClaBlo;
        }

        // Obtiene una lista de recursos desde la base de datos para una clase y bloque específicos.
        // Devuelve una lista de objetos Recurso asociados a la clase y bloque proporcionados.
        public List<Recurso> recursosByClaseYBloque(string idClase, string idBloque)
        {
            Context contextoBaseDatos = new Context();
            var recClaBlo = contextoBaseDatos.RecClaBloq.Where(x => x.idClase == idClase && x.idBloque == idBloque)
                                                        .Include(x => x.recurso)
                                                        .ToList();
            var recursos = new List<Recurso>();
            foreach (var recCla in recClaBlo)
            {
                recursos.Add(recCla.recurso);
            }
            return recursos;
        }
    }
}
