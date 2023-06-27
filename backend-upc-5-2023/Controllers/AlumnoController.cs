// Ignore Spelling: Alumno

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Alumno"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlumnoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AlumnoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = AlumnoServicios.Get<Alumno>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the alumno by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAlumnoById")]
        public IActionResult GetAlumnoById([FromQuery] int id)
        {
            try
            {
                var result = AlumnoServicios.GetById<Alumno>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds the specified alumno.
        /// </summary>
        /// <param name="alumno">The alumno.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAlumno")]
        public IActionResult Insert(Alumno alumno)
        {
            try
            {
                var result = AlumnoServicios.Insert(alumno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified alumno.
        /// </summary>
        /// <param name="alumno">The alumno.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateAlumno")]
        public IActionResult Update(Alumno alumno)
        {
            try
            {
                var result = AlumnoServicios.Update(alumno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteAlumno")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = AlumnoServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion Methods
    }
}
