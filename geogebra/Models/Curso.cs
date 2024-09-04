using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa un curso en el sistema.
    // Esta clase está mapeada a la tabla "CURSOS" en la base de datos.
    [Table("CURSOS")]
    public class Curso
    {
        // Identificador único del curso.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Nombre descriptivo del curso.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }
    }
}
