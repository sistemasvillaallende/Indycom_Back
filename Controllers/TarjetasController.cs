using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities.TARJETAS;
using Web_Api_IyC.Services;

namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarjetasController : Controller
    {

        private ITarjetasServices _TarjetasServices;
        public TarjetasController(ITarjetasServices TarjetasServices)
        {
            _TarjetasServices = TarjetasServices;
        }
        [HttpGet]
        public ActionResult getTarjetasWeb()
        {
            var lst = _TarjetasServices.getTarjetasWeb();
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult getTarjetasDesktop()
        {
            var lst = _TarjetasServices.getTarjetasDesktop();
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult getTarjetasByPk(int pk)
        {
            var lst = _TarjetasServices.getTarjetasByPk(pk);
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult getTarjetasByCodPayPerTic(int pk)
        {
            var lst = _TarjetasServices.getTarjetasByCodPayPerTic(pk);
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult readPlanes()
        {
            var lst = _TarjetasServices.readPlanes();
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult getPlanBySubsistema(int subsistema, decimal deuda, int cod_tarjeta)
        {
            var lst = _TarjetasServices.getBySubsistema(subsistema, deuda, cod_tarjeta);
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
        [HttpGet]
        public ActionResult getPlanByPk(int cod_plan)
        {
            var lst = _TarjetasServices.getPlanByPk(cod_plan);
            if (lst == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }
    }
}
