using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccessLayer;
using API.Models;
using API.Models.LoginModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.BusinessLogic.ProductLayer;

namespace FestivoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Product product = new Product();
        FestivoDBContext context = new FestivoDBContext();
        Success success = new Success();

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            return await context.products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet("getproductsbycategoryid/{categoryId}")]
        public IActionResult GetProductByCategoryId(int categoryId)
        {

            var res = product.GetProductsByCategoryId(categoryId);
            return Ok(res);

        }

        [HttpPost]
        public string PostProducts([FromBody] Products model)
        {
            if (!ModelState.IsValid)
            {
                Success obj = new Success()
                {
                    Succeed = false
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            }
            else
            {
                product.AddProduct(model);
                Success obj = new Success()
                {
                    Succeed = true
                };

                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Products model)
        {
            if (ModelState.IsValid)
            {
                if (product.UpdateData(id, model) == true)
                {
                    Success obj = new Success()
                    {
                        Succeed = true
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
                else
                {
                    Success obj = new Success()
                    {
                        Succeed = false
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
            }
            else
            {
                Success obj = new Success()
                {
                    Succeed = false
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (product.DeleteData(id))
                {
                    Success obj = new Success()
                    {
                        Succeed = true
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
                else
                {
                    Success obj = new Success()
                    {
                        Succeed = false
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
            }
            else
            {
                Success obj = new Success()
                {
                    Succeed = false
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
        }
    }
}
