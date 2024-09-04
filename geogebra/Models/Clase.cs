using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa una clase en el sistema.
    // Esta clase está mapeada a la tabla "CLASES" en la base de datos.
    [Table("CLASES")]
    public class Clase
    {
        // Identificador único de la clase.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Nombre descriptivo de la clase.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }

        // Identificador del nivel educativo al que pertenece la clase.
        // Mapeado a la columna "ID_NIVEL_EDUCATIVO" en la base de datos.
        [Column("ID_NIVEL_EDUCATIVO")]
        public string idNivelEducativo { get; set; }

        // Identificador del curso al que pertenece la clase.
        // Mapeado a la columna "ID_CURSO" en la base de datos.
        [Column("ID_CURSO")]
        public string idCurso { get; set; }

        // Identificador de la modalidad a la que pertenece la clase.
        // Mapeado a la columna "ID_MODALIDAD" en la base de datos.
        [Column("ID_MODALIDAD")]
        public string idModalidad { get; set; }

        // Referencia al nivel educativo al que pertenece la clase.
        // Esta propiedad establece una relación de clave externa con la entidad "NivelEducativo".
        [ForeignKey("idNivelEducativo")]
        public NivelEducativo nivelEducativo { get; set; }

        // Referencia al curso al que pertenece la clase.
        // Esta propiedad establece una relación de clave externa con la entidad "Curso".
        [ForeignKey("idCurso")]
        public Curso curso { get; set; }

        // Referencia a la modalidad a la que pertenece la clase.
        // Esta propiedad establece una relación de clave externa con la entidad "Modalidad".
        [ForeignKey("idModalidad")]
        public Modalidad modalidad { get; set; }
    }
}

