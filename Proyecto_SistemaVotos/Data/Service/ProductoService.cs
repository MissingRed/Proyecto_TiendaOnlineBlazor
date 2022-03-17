using Dapper;
using Microsoft.Data.SqlClient;
using Proyecto_TiendaOnline.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_TiendaOnline.Data.Service
{
    public class ProductoService : IProductoService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ProductoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        //METODO DE INSERTAR producto
        public async Task<bool> ProductoInsert(Producto producto)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdProducto", producto.IdProducto, DbType.String);
                parameters.Add("Nombre", producto.Nombre, DbType.String);
                parameters.Add("Marca", producto.Marca, DbType.String);
                parameters.Add("FechaRegistro", producto.FechaRegistro, DbType.DateTime);
                parameters.Add("Activo", producto.Activo, DbType.String);
              

                const string query = @"INSERT INTO PRODUTOSVENTA (IdProducto,Nombre,Marca,FechaRegistro,Activo) VALUES (@IdProducto,@Nombre,@Marca,@FechaRegistro,@Activo)";
                await conn.ExecuteAsync(query, new { producto.IdProducto, producto.Nombre, producto.Marca, producto.FechaRegistro, producto.Activo }, commandType: CommandType.Text);
            }
            return true;
        }


        //METODO DE ACTUALIZAR producto
        public async Task<bool> ProductoUpdate(Producto producto)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdProducto", producto.IdProducto, DbType.String);
                parameters.Add("Nombre", producto.Nombre, DbType.String);
                parameters.Add("Marca", producto.Marca, DbType.String);
                parameters.Add("FechaRegistro", producto.FechaRegistro, DbType.DateTime);
                parameters.Add("Activo", producto.Activo, DbType.String);
             

                const string query = @"UPDATE PRODUTOSVENTA
                SET IdProducto     = @IdProducto,
                    Nombre    = @Nombre,
                    Marca          = @Marca,
                    FechaRegistro  = @FechaRegistro,
                    Activo         = @Activo,
                  
                WHERE IdProducto   = @IdProducto";
                await conn.ExecuteAsync(query, new { producto.IdProducto, producto.Nombre, producto.Marca, producto.FechaRegistro, producto.Activo}, commandType: CommandType.Text);
            }
            return true;
        }


        //METODO DE ELIMINAR producto
        public async Task<bool> ProductoDelete(Producto producto)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdProducto", producto.IdProducto, DbType.String);

                const string query = @"DELETE FROM PRODUTOSVENTA WHERE IdProducto = @IdProducto";
                await conn.ExecuteAsync(query, new { producto.IdProducto }, commandType: CommandType.Text);
            }
            return true;
        }

        //METODO DE LISTAR TODAS LOS producto
        public async Task<IEnumerable<Producto>> TodasProductos()
        {
            IEnumerable<Producto> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT IdProducto, Nombre, Marca, FechaRegistro, Activo FROM PRODUTOSVENTA";
                productos = await conn.QueryAsync<Producto>(query, commandType: CommandType.Text);
            }

            return productos;
        }

        //METODO DE OBTENER UN producto
        public async Task<Producto> ObtenerProducto(int id)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var query = @"SELECT IdProducto, Nombre, Marca, FechaRegistro, Activo
                            FROM PRODUTOSVENTA
                            WHERE IdProducto = @IdProducto";
                return await conn.QueryFirstOrDefaultAsync<Producto>(query.ToString(), new { IdProducto = id }, commandType: CommandType.Text);
            }
        }


        //METODO PARA OBTENER LA LISTA DE productos
        public async Task<List<Producto>> ListaProductos()
        {
            List<Producto> productos;

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT IdProducto FROM PRODUTOSVENTA";
                productos = (List<Producto>)await conn.QueryAsync<Producto>(query, commandType: CommandType.Text);
            }
            return productos;
        }

    }
}

