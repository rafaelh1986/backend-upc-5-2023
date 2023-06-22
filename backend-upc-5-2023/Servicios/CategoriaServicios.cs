// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Categoria"/>
    /// </summary>
    public static class CategoriaServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SP_OBTENERCATEGORIA";

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
        //public static int ValidarCategoria(Categoria categoria)
        //{
        //    const string sql = "SP_EXISTE_CATEGORIA";

        //    var parameters = new DynamicParameters();
        //    parameters.Add("NOMBRE", categoria.Nombre, DbType.String);

            //var result = DBManager.Instance.GetDataConParametros<T>(sql, parameters);

        //    return DBManager.Instance.GetData(sql,parameters);
        //}

        /// <summary>
        /// Inserts the specified categoría.
        /// </summary>
        /// <param name="categoria">The categoría.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Categoria categoria)
        {
            const string sql = "SP_INSERTARCATEGORIA";

            var parameters = new DynamicParameters();
            parameters.Add("@NOMBRE", categoria.Nombre, DbType.String);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified categoría.
        /// </summary>
        /// <param name="categoria">The categoría.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Categoria categoria)
        {
            const string sql = "SP_ACTUALIZARCATEGORIA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", categoria.Id, DbType.Int64);
            parameters.Add("@NOMBRE", categoria.Nombre, DbType.String);

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
            const string sql = "SP_ELIMINARCATEGORIA";

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
