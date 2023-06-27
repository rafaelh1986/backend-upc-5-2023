using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Pago"/>
    /// </summary>
    public static class PagoServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<Pago> Get()
        {
            const string sql = "SP_OBTENERPAGO";

            var enummerablePagos = DBManager.Instance.GetData<Pago>(sql);

            foreach (var item in enummerablePagos)
            {
                item.Alumno = AlumnoServicios.GetById<Alumno>(item.IdAlumno);
            }

            return enummerablePagos;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Pago GetById(int id)
        {
            const string sql = "SP_OBTENERPAGOBYID";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<Pago>(sql, parameters);

            Pago pago = result.FirstOrDefault();

            if (pago != null)
            {
                pago.Alumno = AlumnoServicios.GetById<Alumno>(pago.IdAlumno);
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified pago.
        /// </summary>
        /// <param name="pago">The producto.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Pago pago)
        {
            const string sql = "SP_INSERTARPAGO";
            var parameters = new DynamicParameters();
            parameters.Add("@MONTO", pago.Monto, DbType.Int64);
            parameters.Add("@ID_ALUMNO", pago.IdAlumno, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified pago.
        /// </summary>
        /// <param name="pago">The pago.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Pago pago)
        {
            const string sql = "SP_ACTUALIZARPAGO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", pago.Id, DbType.Int64);
            parameters.Add("@MONTO", pago.Monto, DbType.Int64);
            parameters.Add("@ID_ALUMNO", pago.IdAlumno, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Delete(int id)
        {
            const string sql = "SP_ELIMINARPAGO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }

        
    }
}
