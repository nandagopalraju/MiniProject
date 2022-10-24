
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly GetData _dataBaseHandler;
        public EmployeeController(GetData dataBaseHandler)
        {
            _dataBaseHandler = dataBaseHandler;
        }
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return _dataBaseHandler.Get();
        }
        [HttpGet]
        [Route("get/{username}")]
        public ActionResult<Employee> Get(string username)
        {
            return _dataBaseHandler.Get(username);
        }
        [HttpDelete]
        [Route("delete/{username}")]

        public ActionResult Delete(string username)
        {
            _dataBaseHandler.delete(username);
            return Ok();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Employee employeeDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _dataBaseHandler.create(employeeDetail);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Employee employeeDetail)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _dataBaseHandler.Edit(employeeDetail);
            return Ok();
        }

    }
}