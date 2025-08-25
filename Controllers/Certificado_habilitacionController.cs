using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Services;

namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Certificado_habilitacionController : Controller
    {

        private ICertificado_habilitacionService _Certificado_habilitacionServices;
        public Certificado_habilitacionController(ICertificado_habilitacionService certificado_HabilitacionServices)
        {
            _Certificado_habilitacionServices = certificado_HabilitacionServices;
        }


        [HttpGet]
        public ActionResult read()
        {
            var lst = _Certificado_habilitacionServices.read();
            if (lst == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }

        [HttpGet]
        public ActionResult GetByLegajo(int legajo)
        {
            var cer = _Certificado_habilitacionServices.GetByLegajo(legajo);
            if (cer == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(cer);
        }

        [HttpGet]
        public ActionResult GetPrincipalByLegajo(int legajo)
        {
            var lst = _Certificado_habilitacionServices.GetPrincipalByLegajo(legajo);
            if (lst == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }

        [HttpGet]
        public ActionResult GetSucursalByLegajo(int legajo)
        {
            var lst = _Certificado_habilitacionServices.GetSucursalByLegajo(legajo);
            if (lst == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }



        [HttpPost]
        public IActionResult InsertHabilitacionComercio(Certificado_habilitacion_Con_Auditoria obj)
        {
            try
            {
                if (obj == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Los datos del certificado son requeridos.",
                        errorCode = "INVALID_DATA"
                    });
                }

                if (obj.vecimiento < DateTime.Now)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "La fecha de vencimiento debe ser mayor al dia de hoy",
                        errorCode = "INVALID_DATE"
                    });
                }

                _Certificado_habilitacionServices.Insert(obj);

                return Ok(new
                {
                    success = true,
                    message = "Certificado de habilitación creado exitosamente.",
                });

            }
            catch (Exception ex)
            {

                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error interno. Intente nuevamente más tarde.",
                    errorCode = "INTERNAL_ERROR",
                    details = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? ex.Message : null
                });
            }
        }


        [HttpGet]
        public ActionResult   GetCertificadoPrincipal(int legajo)
        {
            var lst = _Certificado_habilitacionServices.GetCertificadoPrincipal(legajo);
            if (lst == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }


        [HttpGet]
        public ActionResult   GetCertificadoSucursal(int legajo)
        {
            var lst = _Certificado_habilitacionServices.GetCertificadoSucursal(legajo);
            if (lst == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(lst);
        }

    }
}
