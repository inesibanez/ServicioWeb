using geogebra.Models;
using geogebra.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace geogebra.Services
{
    // Servicio para gestionar operaciones relacionadas con la entidad Recurso.
    // Esta clase actúa como intermediaria entre los controladores y la capa de acceso a datos (DAO).
    public class RecursoService
    {
        // Instancia del DAO para acceder a los datos de Recurso.
        private readonly RecursoDAO recursoDao = new RecursoDAO();

        // Obtiene un recurso específico por su identificador.
        // Devuelve un objeto Task que contiene un Recurso.
        public Task<Recurso> GetRecurso(string id)
        {
            // Llama al método del DAO para obtener el recurso por su ID.
            Task<Recurso> recurso = recursoDao.recurso(id);

            // Devuelve la tarea que contiene el recurso.
            return recurso;
        }

        // Obtiene un recurso específico utilizando un identificador de búsqueda.
        // Devuelve un objeto Task que contiene un RecursoDTO.
        public Task<RecursoDTO> GetRecursoBuscado(string id)
        {
            // Llama al método del DAO para obtener el recurso por su identificador de búsqueda.
            Task<RecursoDTO> recurso = recursoDao.recursoBusqueda(id);

            // Devuelve la tarea que contiene el recurso en formato DTO.
            return recurso;
        }

        // Obtiene los recursos ordenados por bloque para una clase específica.
        // Devuelve un IEnumerable que contiene objetos RecursoDTO.
        public IEnumerable<RecursoDTO> GetRecursosByClaseOrdenados(string idClase, string idBloque)
        {
            // Llama al método del DAO para obtener las relaciones RecursoClaseBloque ordenadas por bloque.
            IEnumerable<RecursoClaseBloque> recClaBlo = recursoDao.recursosByClaseOrdenados(idClase);

            // Lista para almacenar los recursos DTO.
            var recursos = new List<RecursoDTO>();

            // Conjunto para bloques pendientes.
            var bloquesPendientes = new HashSet<string>();
            bool aniadirRecursos = false;

            // Primera iteración para encontrar recursos a partir del bloque indicado.
            foreach (var recBlo in recClaBlo)
            {
                if (recBlo.idBloque == idBloque && !aniadirRecursos)
                {
                    aniadirRecursos = true;
                }
                if (aniadirRecursos)
                {
                    recursos.Add(RecursoDTO.transformaEnDTO(recBlo.recurso, recBlo.idBloque, recBlo.idClase));
                }
                else
                {
                    bloquesPendientes.Add(recBlo.idBloque);
                }
            }

            // Segunda iteración para añadir los recursos pendientes.
            foreach (var recBlo in recClaBlo)
            {
                if (bloquesPendientes.Contains(recBlo.idBloque))
                {
                    recursos.Add(RecursoDTO.transformaEnDTO(recBlo.recurso, recBlo.idBloque, recBlo.idClase));
                }
            }

            // Ordena los recursos del bloque por su orden.
            int aux;
            RecursoDTO recursoAUX;
            for (int i = 1; i < recursos.Count; i++)
            {
                if (recursos[i].idBloque == idBloque)
                {
                    aux = i - 1;
                    if (recursos[i].orden < recursos[aux].orden)
                    {
                        while (aux >= 0)
                        {
                            if (recursos[aux + 1].orden < recursos[aux].orden && recursos[aux].idBloque == idBloque)
                            {
                                recursoAUX = recursos[aux];
                                recursos[aux] = recursos[aux + 1];
                                recursos[aux + 1] = recursoAUX;
                            }
                            else
                            {
                                break;
                            }
                            aux--;
                        }
                    }
                }
                else
                {
                    idBloque = recursos[i].idBloque;
                }
            }

            // Devuelve los recursos ordenados.
            return recursos;
        }

        // Obtiene los recursos asociados a una clase y bloque específicos.
        // Devuelve un IEnumerable que contiene objetos Recurso, ordenados por el campo orden.
        public IEnumerable<Recurso> GetRecursosByClaseYBloque(string idClase, string idBloque)
        {
            // Llama al método del DAO para obtener los recursos por clase y bloque y los ordena por el campo 'orden'.
            IEnumerable<Recurso> recursos = recursoDao.recursosByClaseYBloque(idClase, idBloque)
                                                      .OrderBy(r => r.orden);

            // Devuelve los recursos ordenados.
            return recursos;
        }
    }
}
