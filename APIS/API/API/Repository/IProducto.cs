using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IProducto
    {
        Task<Producto> InsertProduct(Producto product);

        Task<IEnumerable<Producto>> GetProducts();

        Task<Producto> GetProductByProductId(int id); 

        Task<Producto> UpdateProduct(Producto producto); 

        Task<Producto> DeleteProduct(int id); 
    }
}
