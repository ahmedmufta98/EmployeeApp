using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Interfaces;
using EmployeeApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_employeeRepository.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_employeeRepository.GetById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody]Employee employee)
        {
            _employeeRepository.Insert(employee);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Employee employee)
        {
            _employeeRepository.Update(id,employee);
            return Ok();
        }
    }
}
