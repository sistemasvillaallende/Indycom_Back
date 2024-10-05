using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using Web_Api_IyC.Services;

namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Descadic_x_iycController : Controller
    {
        private IDescadic_x_iycService _Descadic_x_iycService;
        public Descadic_x_iycController(IDescadic_x_iycService Descadic_x_iycService)
        {
            _Descadic_x_iycService = Descadic_x_iycService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int legajo, int cod_concepto_iyc)
        {
            var Descadic_x_iyc = _Descadic_x_iycService.getByPk(legajo, cod_concepto_iyc);
            if (Descadic_x_iyc == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Descadic_x_iyc);
        }
    }
}

