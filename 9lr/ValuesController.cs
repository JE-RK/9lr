using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using integtest.Interfaces;

namespace _9lr
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ITriangleValidateService triangleValidateService;
        public ValuesController(ITriangleValidateService triangleValidateService)
        {
            this.triangleValidateService = triangleValidateService;
        }

        [HttpGet ("all")]
        public object GetAllValid()
        {
            return triangleValidateService.IsAllValid();
        }

        [HttpGet("one")]
        public object GetIsValid([FromQuery(Name = "id")] int id)
        {
            try
            {
                return new JsonResult(triangleValidateService.IsValid(id));
            }
            catch (KeyNotFoundException)
            {
                return "404";
            }
        }
    }
}
