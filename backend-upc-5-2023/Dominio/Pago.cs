// Ignore Spelling: Alumno

namespace backend_upc_5_2023.Dominio
{
    /// <summary>
    /// Dominio de la tabla Pago
    /// </summary>
    public class Pago
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Fecha.
        /// </summary>
        /// <value>
        /// The fecha.
        /// </value>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Gets or sets the identifier monto.
        /// </summary>
        /// <value>
        /// The identifier monto.
        /// </value>
        public int Monto { get; set; }

        /// <summary>
        /// Gets or sets the identifier idalumno.
        /// </summary>
        /// <value>
        /// The identifier idalumno.
        /// </value>
        public int IdAlumno { get; set; }

        /// <summary>
        /// Gets or sets the Alumno.
        /// </summary>
        /// <value>
        /// The Alumno.
        /// </value>
        public Alumno? Alumno { get; set; }
    }
}
