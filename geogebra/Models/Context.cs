using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace geogebra.Models
{
    // Contexto de base de datos para la aplicación GeoGebra.
    // Hereda de DbContext y proporciona acceso a las entidades del modelo de datos.
    public class Context : DbContext
    {
        // Conjunto de entidades que representan los niveles educativos.
        public DbSet<NivelEducativo> NivelesEducativos { get; set; }

        // Conjunto de entidades que representan los cursos.
        public DbSet<Curso> Cursos { get; set; }

        // Conjunto de entidades que representan las modalidades.
        public DbSet<Modalidad> Modalidades { get; set; }

        // Conjunto de entidades que representan las clases.
        public DbSet<Clase> Clases { get; set; }

        // Conjunto de entidades que representan los bloques.
        public DbSet<Bloque> Bloques { get; set; }

        // Conjunto de entidades que representan los recursos.
        public DbSet<Recurso> Recursos { get; set; }

        // Conjunto de entidades que representan la relación entre recursos, clases y bloques.
        public DbSet<RecursoClaseBloque> RecClaBloq { get; set; }

        // Configura las opciones del contexto, incluyendo la cadena de conexión a la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    UserID = "geogebra",
                    Password = "geogebra",
                    InitialCatalog = "GeoGebra_demo"
                };

                optionsBuilder.UseSqlServer(builder.ConnectionString);
            }
        }

        // Configura el modelo de datos utilizando el API Fluent de Entity Framework.
        // Define las claves primarias compuestas y otras configuraciones de entidad.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecursoClaseBloque>()
                .HasKey(c => new { c.idRecurso, c.idClase, c.idBloque });
        }
    }
}


