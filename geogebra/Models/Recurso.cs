using System.ComponentModel.DataAnnotations.Schema;

namespace geogebra.Models
{
    // Representa un recurso en el sistema.
    // Esta clase está mapeada a la tabla "RECURSOS" en la base de datos.
    [Table("RECURSOS")]
    public class Recurso
    {
        // Identificador único del recurso.
        // Mapeado a la columna "ID" en la base de datos.
        [Column("ID")]
        public string id { get; set; }

        // Identificador de búsqueda para el recurso.
        // Mapeado a la columna "ID_BUSQUEDA" en la base de datos.
        [Column("ID_BUSQUEDA")]
        public string idBusqueda { get; set; }

        // Nombre descriptivo del recurso.
        // Mapeado a la columna "NOMBRE" en la base de datos.
        [Column("NOMBRE")]
        public string nombre { get; set; }

        // Enlace al recurso (por ejemplo, URL del recurso en línea).
        // Mapeado a la columna "ENLACE" en la base de datos.
        [Column("ENLACE")]
        public string enlace { get; set; }

        // Instrucciones adicionales sobre cómo utilizar el recurso.
        // Mapeado a la columna "INSTRUCCIONES" en la base de datos.
        // Este campo es opcional.
        [Column("INSTRUCCIONES")]
        public string? instrucciones { get; set; }

        // Enlace a una imagen relacionada con el recurso.
        // Mapeado a la columna "ENLACE_IMAGEN" en la base de datos.
        // Este campo es opcional.
        [Column("ENLACE_IMAGEN")]
        public string? enlaceImagen { get; set; }

        // Enlace a un video relacionado con el recurso.
        // Mapeado a la columna "ENLACE_VIDEO" en la base de datos.
        // Este campo es opcional.
        [Column("ENLACE_VIDEO")]
        public string? enlaceVideo { get; set; }

        // Nombre del autor del recurso.
        // Mapeado a la columna "AUTOR" en la base de datos.
        // Este campo es opcional.
        [Column("AUTOR")]
        public string? autor { get; set; }

        // Orden en el que el recurso debe ser mostrado o procesado.
        // Mapeado a la columna "ORDEN" en la base de datos.
        [Column("ORDEN")]
        public int orden { get; set; }

        // Identificador de un recurso adaptado asociado, si existe.
        // Mapeado a la columna "RECURSO_ADAPTADO" en la base de datos.
        // Este campo es opcional.
        [Column("RECURSO_ADAPTADO")]
        public string? recursoAdaptado { get; set; }
    }
}

