﻿using DataLibrary.BusinessLogic;
using DataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_CRUD_Project.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var data = EmployeeProcessor.LoadAllEmployees();

            return APIHelper.JsonSerializeToStringList<EmployeeModel>(data);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var data = EmployeeProcessor.GetEmployeeById(id);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}