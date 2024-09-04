using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa un bloque en el sistema.
    // Esta clase está mapeada a la tabla "BLOQUES" en la base de datos.
    [Table("BLOQUES")]
    public class Bloque
    {
        // Identificador único del bloque.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Nombre descriptivo del bloque.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }
    }
}
