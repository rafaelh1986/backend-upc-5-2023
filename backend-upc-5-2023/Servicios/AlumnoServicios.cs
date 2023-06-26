// Ignore Spelling: Alumno

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Alumno"/>
    /// </summary>
    public static class AlumnoServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SP_OBTENERALUMNO";

            return DBManager.Instance.GetData<T>(sql);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static T GetById<T>(int id)
        {
            const string sql = "SP_OBTENERCATEGORIABYID";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

            return result.FirstOrDefault();
        }
        

        /// <summary>
        /// Inserts the specified categoría.
        /// </summary>
        /// <param name="alumno">The categoría.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Alumno alumno)
        {
            const string sql = "SP_INSERTARALUMNO";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE", alumno.Nombre, DbType.String);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified categoría.
        /// </summary>
        /// <param name="alumno">The categoría.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Alumno alumno)
        {
            const string sql = "SP_ACTUALIZARALUMNO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", alumno.Id, DbType.Int64);
            parameters.Add("@NOMBRE_COMPLETO", alumno.NombreCompleto, DbType.String);
            parameters.Add("@CURSO", alumno.Curso, DbType.String);
            parameters.Add("@GESTION", alumno.Gestion, DbType.Int64);

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
            const string sql = "SP_ELIMINARALUMNO";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
