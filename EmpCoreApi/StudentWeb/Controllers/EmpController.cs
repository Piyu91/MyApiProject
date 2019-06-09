using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCore.BusinessLayer;
using StudentCore.DataModel;

namespace StudentWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Emp")]
    public class EmpController : ControllerBase
    {
        private readonly IBusiness _business;
        public EmpController(IBusiness business)
        {
            _business = business;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok( _business.GetAllEmployee());
        }

        [HttpGet ("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_business.GetEmpById(id));
        }

        [HttpPost]
        public IActionResult Post(Emp emp)
        {
            _business.EmployeePost(emp);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , Emp emp)
        {
            _business.EmployeePut(id,emp);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _business.EmployeeDelete(id);
            return NoContent();
        }
    }
}