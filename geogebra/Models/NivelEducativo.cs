using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa un nivel educativo en el sistema.
    // Esta clase está mapeada a la tabla "NIVELES_EDUCATIVOS" en la base de datos.
    [Table("NIVELES_EDUCATIVOS")]
    public class NivelEducativo
    {
        // Identificador único del nivel educativo.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Nombre descriptivo del nivel educativo.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }
    }
}