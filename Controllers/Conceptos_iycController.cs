using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Services;


namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Conceptos_iycController : Controller
    {
        private IConceptos_iycService _Conceptos_iycService;
        private IDescadic_x_iycService _Descadic_x_iycService;
        public Conceptos_iycController(
            IConceptos_iycService Conceptos_iycService,
            IDescadic_x_iycService descadic_x_iycService
    )
        {
            _Conceptos_iycService = Conceptos_iycService;
            _Descadic_x_iycService = descadic_x_iycService;
        }
        [HttpGet]
        public ActionResult<List<Conceptos_iyc>> readConceptos()
        {
            var conceptos = _Conceptos_iycService.read();

            return Ok(conceptos);
        }
        [HttpGet]
        public ActionResult<List<Descadic_x_iyc>> getConceptos_x_iyc(
            int legajo)
        {
            var conceptos = _Descadic_x_iycService.getConceptos_x_iyc(legajo);

            return Ok(conceptos);
        }
        [HttpPost]
        public IActionResult UpdateConcepto(Descadic_x_iyc obj, string usuario)
        {
            if (obj.objAuditoria != null)
            {
                obj.objAuditoria.usuario = usuario;
            }

            _Descadic_x_iycService.update(obj);
            var IndYCom = _Descadic_x_iycService.getByPk(obj.legajo,
                obj.cod_concepto_iyc);
            if (IndYCom.legajo == 0)
            {
                return Ok(new { message = "Error no se pudo modificar el concepto." });
            }
            return Ok(IndYCom);
        }
        [HttpPost]
        public IActionResult AddConcepto(Descadic_x_iyc obj, string usuario)
        {
            if (obj.objAuditoria != null)
            {
                obj.objAuditoria.usuario = usuario;
            }
            _Descadic_x_iycService.insert(obj);
            var IndYCom = _Descadic_x_iycService.getByPk(obj.legajo,
                obj.cod_concepto_iyc);
            if (IndYCom.legajo == 0)
            {
                return Ok(new { message = "Error no se pudo agregar el concepto." });
            }
            return Ok(IndYCom);
        }
        [HttpPost]
        public IActionResult DeleteConcepto(int legajo, int cod_concepto_iyc, 
            string usuario)
        {

            var IndYCom = _Descadic_x_iycService.getByPk(legajo,
                cod_concepto_iyc);

            if (IndYCom != null && IndYCom.legajo != 0)
            {
                _Descadic_x_iycService.delete(legajo, cod_concepto_iyc, usuario);
                return Ok(IndYCom);
            }

            return Ok(new { message = "Error no se pudo eliminar el concepto." });
        }
    }
}

