using API.Data;
using API.Model;
using API.Validation;
using Dapper;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ProductoRepository : IProducto
    {
        private readonly IConfiguration _config;
        public ProductoRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DatabaseConnection"));
            }
        }
        public async Task<Producto> DeleteProduct(int id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var result = await con.QueryAsync<Producto>("USP_DELETE_PRODUCTO", param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public async Task<Producto> GetProductByProductId(int id)
        {

            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Id", id);
                    var result = await con.QueryAsync<Producto>("USP_PRODUCTO_ID", param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Producto>> GetProducts()
        {
         

            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var result = await con.QueryAsync<Producto>("USP_LIST_PRODUCTO", commandType: CommandType.StoredProcedure);
                    Console.WriteLine("result", result);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Producto> InsertProduct(Producto product)
        {
            try
            { 

          
                    using (IDbConnection con = connection)
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@Nombre", product.Nombre);
                        param.Add("@Precio", product.Precio);
                        param.Add("@Stock", product.Stock);
                        param.Add("@FechaRegistro", product.FechaRegistro);
                        var result = await con.QueryAsync<Producto>("USP_ADD_PODUCTO", param, commandType: CommandType.StoredProcedure);
                        return result.FirstOrDefault();
                    }
              

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Producto> UpdateProduct(Producto product)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    con.Open();
                    var param = new DynamicParameters();
                    param.Add("@Nombre", product.Nombre);
                    param.Add("@Precio", product.Precio);
                    param.Add("@Stock", product.Stock);
                    param.Add("@FechaRegistro", product.FechaRegistro);
                    param.Add("@Id", product.Id);
                    var result = await con.QueryAsync<Producto>("USP_UPDATE_PRODUCTO", param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
