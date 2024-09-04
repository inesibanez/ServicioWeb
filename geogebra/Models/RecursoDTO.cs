namespace geogebra.Models
{
    // Data Transfer Object (DTO) para la entidad Recurso.
    // Este DTO se utiliza para transferir los datos de un Recurso de manera simplificada entre capas de la aplicación.
    public class RecursoDTO
    {
        // Identificador único del recurso.
        public string id { get; set; }

        // Identificador de búsqueda para el recurso.
        public string idBusqueda { get; set; }

        // Identificador de la clase a la que pertenece el recurso.
        public string idClase { get; set; }

        // Identificador del bloque al que pertenece el recurso.
        public string idBloque { get; set; }

        // Nombre descriptivo del recurso.
        public string nombre { get; set; }

        // Enlace al recurso (por ejemplo, URL del recurso en línea).
        public string enlace { get; set; }

        // Instrucciones adicionales sobre cómo utilizar el recurso.
        public string instrucciones { get; set; }

        // Enlace a una imagen relacionada con el recurso.
        public string enlaceImagen { get; set; }

        // Enlace a un video relacionado con el recurso.
        public string enlaceVideo { get; set; }

        // Nombre del autor del recurso.
        public string autor { get; set; }

        // Orden en el que el recurso debe ser mostrado o procesado.
        public int orden { get; set; }

        // Identificador de un recurso adaptado asociado, si existe.
        public string recursoAdaptado { get; set; }

        // Transforma un objeto Recurso en un objeto RecursoDTO.
        // Incluye los identificadores de clase y bloque correspondientes.
        public static RecursoDTO transformaEnDTO(Recurso recurso, string idBloque, string idClase)
        {
            RecursoDTO dto = new RecursoDTO
            {
                id = recurso.id,
                idBusqueda = recurso.idBusqueda,
                idClase = idClase,
                idBloque = idBloque,
                nombre = recurso.nombre,
                enlace = recurso.enlace,
                instrucciones = recurso.instrucciones,
                enlaceImagen = recurso.enlaceImagen,
                enlaceVideo = recurso.enlaceVideo,
                autor = recurso.autor,
                orden = recurso.orden,
                recursoAdaptado = recurso.recursoAdaptado
            };
            return dto;
        }
    }
}
