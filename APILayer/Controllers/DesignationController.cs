using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public DesignationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        [Route("designation")]
        public IActionResult Designation([FromBody] Designation designation)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _dataContext.designations.Add(designation);
            _dataContext.SaveChanges();
            return Ok();
        }
    }
}
