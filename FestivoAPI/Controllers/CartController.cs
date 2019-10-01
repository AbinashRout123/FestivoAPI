using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.BusinessLogic.ProductLayer;
using API.DataAccessLayer;
using API.Models;
using API.Models.LoginModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        FestivoDBContext db = new FestivoDBContext();
        ShoppingCart cart = new ShoppingCart();


        [HttpPost("getCart")]

        public IEnumerable<CartItem> Get([FromBody] CartItem model)
        {
            var result = cart.GetCartValue(model);
            return result;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cart
        [HttpPost("addToCart")]
        public string Post([FromBody] CartItem model)
        {
            if (cart.AddCart(model))
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
        
        [HttpPost("removeFromCart")]
        public string PostC([FromBody] CartItem model)
        {
            if (cart.RemoveCart(model))
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
        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // DELETE: api/ApiWithActions/5
        [HttpPost("clearCart")]
        public void clear([FromBody] CartItem model)
        {
            cart.ClearCart(model);
        }



        [HttpPost("getTotal")]
        public int Total([FromBody] CartItem model)
        {
            return cart.CartTotal(model);
        }
    }
}
