using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Services;

namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Resolucion_habilitacionController : Controller
    {

        private IResolucion_habilitacionService _Resolucion_habilitacionServices;
        public Resolucion_habilitacionController(IResolucion_habilitacionService resolucion_HabilitacionServices)
        {
            _Resolucion_habilitacionServices = resolucion_HabilitacionServices;
        }


        [HttpPost]
        public IActionResult ConfirmarResolucionComercio(Resolucion_habilitacion_DTO obj)
        {
            try
            {
                if (obj is null )
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Los datos de la resolucion son requeridos.",
                        errorCode = "INVALID_DATA"
                    });
                }

                _Resolucion_habilitacionServices.Insert(obj);
                Resolucion_habilitacion_imprimir resolucion = _Resolucion_habilitacionServices.GetResolucion(obj.Legajo);
                
                return Ok(new
                {
                    success = true,
                    resolucion,
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
        public ActionResult HistorialResoluciones(int legajo)
        {
            var hist = _Resolucion_habilitacionServices.GetAllResolucion(legajo);
            if (hist == null)
            {
                return NotFound(new { message = "No se encontraron datos!" });
            }
            return Ok(hist);
        }

    }
}
