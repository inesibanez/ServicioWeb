using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa una modalidad en el sistema.
    // Esta clase está mapeada a la tabla "MODALIDADES" en la base de datos.
    [Table("MODALIDADES")]
    public class Modalidad
    {
        // Identificador único de la modalidad.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Nombre descriptivo de la modalidad.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }
    }
}
