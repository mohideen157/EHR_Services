using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CoreWebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BLImplementation;
using EntitiesProject.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApi.Controller
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        [ActionName("GetDetails")]
        public string Get()

        {
            LoginEntity value = new LoginEntity();
            value.Username = "value1";
            value.Password = "value2";
            var json = JsonConvert.SerializeObject(value);
            return json;
        }

        // POST api/<controller>
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public string Post([FromBody]LoginEntity value)
        {
            LoginBLImp LoginIns = new LoginBLImp();
            return LoginIns.Login(value);
        }
    }

    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        // POST api/<controller>
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public string Post([FromBody]RegisterEntity value)
        {
            RegisterBLImp RegisterIns = new RegisterBLImp();
            return RegisterIns.Register(value);
        }
    }
}