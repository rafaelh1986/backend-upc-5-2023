using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Producto"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public PagoController(IConfiguration configuration)
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
        /// <exception cref="SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = PagoServicios.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the producto by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPagoById")]
        public IActionResult GetPagoById(int id)
        {
            try
            {
                var result = PagoServicios.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Inserts the specified pago.
        /// </summary>
        /// <param name="pago">The pago.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPago")]
        public IActionResult Insert(Pago pago)
        {
            try
            {
                var result = PagoServicios.Insert(pago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified pago.
        /// </summary>
        /// <param name="pago">The pago.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePago")]
        public IActionResult Update(Pago pago)
        {
            try
            {
                var result = PagoServicios.Update(pago);
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
        [Route("DeletePago")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = PagoServicios.Delete(id);
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
