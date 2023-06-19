﻿// Ignore Spelling: Carrito

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="HProducto"/>
    /// </summary>
    public static class HProductoServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<T> Get<T>()
        {
            const string sql = "SelectH_Producto";

            return DBManager.Instance.GetData<T>(sql);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static HProducto GetById(int id)
        {
            const string sql = "SelectH_Producto";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<HProducto>(sql, parameters);

            HProducto hProducto = result.FirstOrDefault();

            if (hProducto != null)
            {
                hProducto.Producto = ProductoServicios.GetById(hProducto.IdProducto);
                hProducto.CarritoCompra = CarritoCompraServicios.GetById(hProducto.IdCarritoCompra);
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Gets the by identifier carrito compra.
        /// </summary>
        /// <param name="idCarritoCompra">The identifier carrito compra.</param>
        /// <returns></returns>
        public static IEnumerable<HProducto> GetByIdCarritoCompra(int idCarritoCompra)
        {
            const string sql = "SelectByIdCarritoCompra";

            var parameters = new DynamicParameters();
            parameters.Add("idCarritoCompra", idCarritoCompra, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<HProducto>(sql, parameters);

            return result;
        }

        /// <summary>
        /// Inserts the specified h producto.
        /// </summary>
        /// <param name="hProducto">The h producto.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(HProducto hProducto)
        {
            const string sql = "InsertH_Producto";

            var parameters = new DynamicParameters();
            parameters.Add("Cantidad", hProducto.Cantidad, DbType.Int64);
            parameters.Add("IdProducto", hProducto.IdProducto, DbType.Int64);
            parameters.Add("IdCarritoCompra", hProducto.IdCarritoCompra, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }
    }
}
