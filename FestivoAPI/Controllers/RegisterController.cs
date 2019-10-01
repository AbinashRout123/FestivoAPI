using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.BusinessLogic;
using API.DataAccessLayer;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models.LoginModels;

namespace FestivoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        Register r = new Register();

        public RegisterController(FestivoDBContext context)
        {


        }
        
        // GET: api/Register
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var u = r.GetData();
                return Ok(u);
            }
            else
            {
                return BadRequest("Not a valid model");
            }
        }

        // GET: api/Register/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                if (r.DataValid(id))
                {
                    var u = r.GetDataById(id);
                    return Ok(u);
                }
                else
                {
                    return BadRequest("Not a valid ID");
                }
            }
            else
            {
                return BadRequest("Not a valid Model");
            }
        }

        // POST: api/Register
        [HttpPost]
        public string Post([FromBody] Users model)
        {

            if (!ModelState.IsValid)
            {
                Success obj = new Success()
                {
                    Succeed = false
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                // return BadRequest("Invalid Data");
            }
            else
            {
                if (r.DataAdd(model) == true)
                {
                    Success obj = new Success()
                    {
                        Succeed = true
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
                // return Ok();
                else
                {
                    Success obj = new Success()
                    {
                        Succeed = false
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
                //  return NotFound();
            }

        }

        // PUT: api/Register/5
        [HttpPut]
        public IActionResult Put([FromBody] Users model)
        {
            if (ModelState.IsValid)
            {
                if (r.updateData(model.UserId, model) == true)
                {
                    return Ok( new { message = "Data Updated" });
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
            }
            else
            {
                return BadRequest("Model is not valid");
            }
        }

        [HttpPut("{id}", Name ="GetData")]
        public Users GetData(int id)
        {
            var user = r.GetDataById(id);
            return user;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (r.deleteData(id))
                {
                    return Ok("Record deleted");
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
            }
            else
            {
                return BadRequest("Invalid Model");
            }
        }
    }
}
