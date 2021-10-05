using API.Model;
using API.Repository;
using API.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _IProducto;
        public ProductoController(IProducto IProducto)
        {
            _IProducto = IProducto;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Producto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<Producto>> GetProducts()
        {
            return await _IProducto.GetProducts();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        [ProducesResponseType(200, Type = typeof(Producto))]
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Not found
        [ProducesResponseType(500)]
        public async Task<ActionResult<Producto>> GetProducts(int id)
        {
            var obj = await _IProducto.GetProductByProductId(id);
            if(obj == null) return NotFound();
            return obj;
        }

        [HttpPost]
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Producto>> InsertProduct([FromBody] Producto product)
        {
            Console.WriteLine("sddsdsd",product);
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            var validator = new ProductoValidator();

            ValidationResult result = validator.Validate(product);

            if (result.IsValid)
            {
                await _IProducto.InsertProduct(product);
                return CreatedAtRoute("GetProducts", new { id = product.Id }, product);
            }
            return Ok(result);
            
        }

        [HttpPut]
        [ProducesResponseType(400)] //Bad Request
        [ProducesResponseType(404)] //Bad Request
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Producto>> UpdateProduct([FromBody] Producto product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            var obj = await _IProducto.GetProductByProductId(product.Id);
            if (obj == null) return NotFound();

            var validator = new ProductoValidator();

            ValidationResult result = validator.Validate(product);

            if (result.IsValid)
            {
                await _IProducto.UpdateProduct(product);
                return CreatedAtRoute("GetProducts", new { id = product.Id }, product);
            }
            return Ok(result);

            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)] //Bad Request
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Producto>> DeleteProduct(int id)
        {
            var obj = await _IProducto.GetProductByProductId(id);
            if (obj == null) return NotFound();
            await _IProducto.DeleteProduct(id);
            return CreatedAtRoute("GetProducts", new { id = obj.Id }, obj);
        }
    }
}
