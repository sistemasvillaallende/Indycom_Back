using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Services;

namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Ctasctes_indycomController : Controller
    {
        private ICtasctes_indycomServices _Ctasctes_indycomServices;
        private IIndycomServices _iindycomService;
        public Ctasctes_indycomController(ICtasctes_indycomServices Ctasctes_indycomServices, IIndycomServices iindycomService)
        {
            _Ctasctes_indycomServices = Ctasctes_indycomServices;
            _iindycomService = iindycomService;
        }
     
        [HttpGet]
        public IActionResult IniciarCtacte(int legajo)
        {
            var lista = _Ctasctes_indycomServices.IniciarCtacte(legajo);
            if (lista.Count == 0)
            {
                return BadRequest(new { message = "No Hay Periodo para iniciar la Ctacte de este Legajo" });
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Confirma_iniciar_ctacte(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_indycomServices.Confirma_iniciar_ctacte(obj.legajo, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Inicializacion de la Cuenta Cte!" });
            }
            return Ok(obj.lstCtastes);
        }

        [HttpGet]
        public IActionResult Listar_periodos_a_cancelar(int legajo)
        {
            var Ctasctes = _Ctasctes_indycomServices.Listar_periodos_a_cancelar(legajo);
            if (Ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Ctasctes);
        }

        [HttpPost]
        public IActionResult Confirma_cancelacion_ctasctes(int tipo_transaccion, CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_indycomServices.Confirma_cancelacion_ctasctes(tipo_transaccion, obj.legajo, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Cancelacion Operativa!" });

            }
            return Ok(obj.lstCtastes);
        }

        [HttpGet]
        public ActionResult<List<Ctasctes_indycom>> Listar_Periodos_cancelados(int legajo)
        {
            var Ctasctes = _Ctasctes_indycomServices.Listar_Periodos_cancelados(legajo);
            if (Ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Ctasctes);
        }

        [HttpPost]
        public IActionResult Confirma_elimina_cancelacion(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtastes.Count > 0)
            {
                _Ctasctes_indycomServices.Confirma_elimina_cancelacion(obj.legajo, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Cancelar porque no hay Datos!" });
            }
            return Ok(obj.lstCtastes);
        }
        [HttpGet]
        public IActionResult Listar_periodos_a_reliquidar(int legajo)
        {
            var ctasctes = _Ctasctes_indycomServices.Listar_periodos_a_reliquidar(legajo);
            if (ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se Encontraron Periodos para Reliquidar para el Legajo " + legajo });
            }
            return Ok(ctasctes);
        }

        [HttpPost]
        public IActionResult Reliquidar_periodos(int legajo, List<Ctasctes_indycom> lst)
        {
            var ctasctes = _Ctasctes_indycomServices.Reliquidar_periodos(legajo, lst);
            if (ctasctes.Count == 0)
            {
                return BadRequest(new { message = "No se pudo Reliquidar, llamar a la Oficina de Sistemas!" });
            }
            return Ok(ctasctes);

        }
        [HttpPost]
        public IActionResult Confirma_reliquidacion(CtasCtes_Con_Auditoria obj)
        {
            if (obj.lstCtastes.Count > 0)
            {
                var indycom = _iindycomService.GetByPk(obj.legajo);
                int tipo_liquidacion = indycom.tipo_liquidacion;
                _Ctasctes_indycomServices.Confirma_reliquidacion(obj.legajo, tipo_liquidacion, obj.lstCtastes, obj.auditoria);
            }
            else
            {
                return BadRequest(new { message = "No se pudo Confirmar la Reliquidacion de los Periodos de este Legajo !" });
            }
            return Ok(obj.lstCtastes);

        }



        public ActionResult<List<Ctasctes_indycom>> ListarCtacte(string dominio, int tipo_consulta, int cate_deuda_desde, int cate_deuda_hasta)
        {
            var Ctasctes = _Ctasctes_indycomServices.ListarCtacte(dominio, tipo_consulta, cate_deuda_desde, cate_deuda_hasta);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult<List<Ctasctes_indycom>> DetalleDeuda(int nro_transaccion)
        {
            var Ctasctes = _Ctasctes_indycomServices.DetalleDeuda(nro_transaccion);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetalleProcuracion(int nro_proc)
        {
            var Ctasctes = _Ctasctes_indycomServices.DetalleProcuracion(nro_proc);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult DetallePlan(int nro_plan)
        {
            var Ctasctes = _Ctasctes_indycomServices.DetPlanPago(nro_plan);

            return Ok(Ctasctes);
        }
        [HttpGet]
        public ActionResult<string> Datos_transaccion(int tipo_transaccion, int nro_transaccion)
        {
            var Transaccion = _Ctasctes_indycomServices.Datos_transaccion(tipo_transaccion, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult DetallePago(int nro_cedulon, int nro_transaccion)
        {
            var Transaccion = _Ctasctes_indycomServices.DetallePago(nro_cedulon, nro_transaccion);
            if (Transaccion == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(Transaccion);
        }
        [HttpGet]
        public ActionResult getListDeudaAuto(string dominio)
        {
            var lstDeuda = _Ctasctes_indycomServices.getListDeudaAuto(dominio);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpGet]
        public ActionResult getListDeudaAutoNoVencida(string dominio)
        {
            var lstDeuda = _Ctasctes_indycomServices.getListDeudaAutoNoVencida(dominio);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
        [HttpGet]
        public ActionResult getListDeudaAutoProcurada(string dominio)
        {
            var lstDeuda = _Ctasctes_indycomServices.getListDeudaAutoProcurada(dominio);
            if (lstDeuda == null)
            {
                return BadRequest(new { message = "No se encontraron datos!" });
            }
            return Ok(lstDeuda);
        }
    }
}
