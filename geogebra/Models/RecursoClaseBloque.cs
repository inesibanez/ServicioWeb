using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa la relación entre un recurso, una clase y un bloque en el sistema.
    // Esta clase está mapeada a la tabla "RECURSOS_CLASES_BLOQUES" en la base de datos.
    [Table("RECURSOS_CLASES_BLOQUES")]
    public class RecursoClaseBloque
    {
        // Identificador del recurso en la relación.
        // Mapeado a la columna "ID_RECURSO" en la base de datos.
        [Column("ID_RECURSO")]
        public string idRecurso { get; set; }

        // Identificador de la clase en la relación.
        // Mapeado a la columna "ID_CLASE" en la base de datos.
        [Column("ID_CLASE")]
        public string idClase { get; set; }

        // Identificador del bloque en la relación.
        // Mapeado a la columna "ID_BLOQUE" en la base de datos.
        [Column("ID_BLOQUE")]
        public string idBloque { get; set; }

        // Referencia al recurso asociado en la relación.
        // Establece una relación de clave externa con la entidad "Recurso".
        [ForeignKey("idRecurso")]
        public virtual Recurso recurso { get; set; }

        // Referencia a la clase asociada en la relación.
        // Establece una relación de clave externa con la entidad "Clase".
        [ForeignKey("idClase")]
        public Clase clase { get; set; }

        // Referencia al bloque asociado en la relación.
        // Establece una relación de clave externa con la entidad "Bloque".
        [ForeignKey("idBloque")]
        public Bloque bloque { get; set; }
    }
}
