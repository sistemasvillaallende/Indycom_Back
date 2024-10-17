using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Entities.IYC;
using Web_Api_IyC.Helpers;
using Web_Api_IyC.Services;
using static System.Net.Mime.MediaTypeNames;


namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IndycomController : Controller
    {
        private IIndycomServices _iindycomService;
        public IndycomController(IIndycomServices indycomService)
        {
            _iindycomService = indycomService;
        }

        [HttpPost]
        public IActionResult Update(INDYCOM obj)
        {
            var objOriginal = _iindycomService.GetByPk(obj.legajo);
            _iindycomService.Update(obj, objOriginal);
            return Ok(objOriginal);
        }

        [HttpPost]
        public IActionResult Delete(Entities.INDYCOM obj)
        {
            _iindycomService.Delete(obj.legajo);
            var indycom = _iindycomService.Read();

            return Ok(indycom);
        }
        [HttpGet]
        public IActionResult Read()
        {
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }

        [HttpGet]
        public IActionResult GetByPk(int legajo)
        {
            var indycom = _iindycomService.GetByPk(legajo);

            return Ok(indycom);
        }

        [HttpGet]
        public IActionResult saludo()
        {
            var msg = "hola putoooo";
            return Ok(msg);
        }

        [HttpGet]
        public IActionResult Tipos_liq_iyc()
        {
            var tipos = _iindycomService.Tipos_liq_iyc();
            if (tipos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(tipos);
        }

        [HttpGet]
        public IActionResult Tipos_per_iyc()
        {
            var tipos = _iindycomService.Tipos_per_iyc();
            if (tipos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(tipos);
        }
        [HttpGet]
        public IActionResult Tipos_iva()
        {
            var tipos = _iindycomService.Tipos_iva();
            if (tipos == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(tipos);
        }
        [HttpGet]
        public IActionResult Tipos_entidad()
        {
            var entidad = _iindycomService.Tipos_entidad();
            if (entidad == null)
            {
                return BadRequest(new { message = "No se encontraron datos" });
            }
            return Ok(entidad);
        }
        [HttpGet]
        public IActionResult Zonasiyc()
        {
            var zonas = _iindycomService.Zonasiyc();
            if (zonas == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(zonas);
        }

        [HttpGet]
        public IActionResult Situacion_judicial()
        {
            var SituacionJudicial = _iindycomService.Situacion_judicial();
            if (SituacionJudicial == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(SituacionJudicial);
        }
        [HttpPost]
        public IActionResult InsertDatosGeneral(Entities.INDYCOM obj)
        {
            _iindycomService.InsertDatosGeneral(obj);
            var indycom = _iindycomService.GetByPk(obj.legajo);
            if (indycom == null)
            {
                return Ok(new { message = "Error, no se pudo dar de Alta el Comercio." });
            }
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult UpdateDatosGenerales(INDYCOM obj)
        {
            //obj.objAuditoria.usuario = usuario;
            var indycom = _iindycomService.GetByPk(obj.legajo);
            if (indycom.legajo > 0)
            {
                _iindycomService.UpdateDatosGenerales(obj, indycom);
            }
            else
            {
                return BadRequest(new { message = "No se encontraron el Legajo del Comercio..." });
            }
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult UpdateDatosDomPostal(INDYCOM obj)
        {
            //obj.objAuditoria.usuario = usuario;
            var objOriginal = _iindycomService.GetByPk(obj.legajo);
            _iindycomService.UpdateDatosDomPostal(obj, objOriginal);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult SaveDatosAfip(INDYCOM obj)
        {
            //obj.objAuditoria.usuario = usuario;
            var objOriginal = _iindycomService.GetByPk(obj.legajo);
            _iindycomService.SaveDatosAfip(obj, objOriginal);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult SaveDatosLiquidacion(INDYCOM obj)
        {
            //obj.objAuditoria.usuario = usuario;
            var objOriginal = _iindycomService.GetByPk(obj.legajo);
            _iindycomService.SaveDatosLiquidacion(obj, objOriginal);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        //
        [HttpGet]
        public ActionResult<PaginadorGenerico<Entities.INDYCOM>> GetIndycomPaginado(
           string buscarPor = "0", string strParametro = "0", int pagina = 1, int registros_por_pagina = 10)
        {
            List<Entities.INDYCOM> _Indycom;
            PaginadorGenerico<Entities.INDYCOM> _PaginadorIndycom;
            ///////////////////////////
            // SISTEMA DE PAGINACIÓN //
            ///////////////////////////
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Vehiculos
            _TotalRegistros = _iindycomService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Legajo,
            //Titular
            //Cuit
            //Nom_fantasia
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Indycom = _iindycomService.GetIndycomPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Indycom = _iindycomService.GetIndycomPaginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorIndycom = new PaginadorGenerico<Entities.INDYCOM>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Indycom
            };
            if (_PaginadorIndycom == null)
            {
                return BadRequest(new { message = "No se encontraron los datos" });
            }
            return _PaginadorIndycom;
        }

        [HttpGet]
        private ActionResult<PaginadorGenerico<Entities.INDYCOM>> PaginacionConParamRequestForm()
        {
            string buscarPor = Convert.ToString(Request.Form["buscarPor"]);
            string strParametro = Convert.ToString(Request.Form["strParametro"]);
            int pagina = Convert.ToInt32(Request.Form["pagina"]);
            int registros_por_pagina = Convert.ToInt32(Request.Form["registros_por_pagina"]);
            if (buscarPor.Length == 0) { buscarPor = "0"; }
            if (strParametro.Length == 0) { strParametro = "0"; }
            if (pagina == 0) { pagina = 1; }
            if (registros_por_pagina == 0) { registros_por_pagina = 10; }
            /////////////////////////////////////////////////////////////////////////////////////////
            List<Entities.INDYCOM> _Indycom;
            PaginadorGenerico<Entities.INDYCOM> _PaginadorIndycom;
            ///////////////////////////
            // SISTEMA DE PAGINACIÓN //
            ///////////////////////////
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Vehiculos
            _TotalRegistros = _iindycomService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Legajo,
            //Titular
            //Cuit
            //Nom_fantasia
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Indycom = _iindycomService.GetIndycomPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Indycom = _iindycomService.GetIndycomPaginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
                                                                            pagina * registros_por_pagina);
            //Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorIndycom = new PaginadorGenerico<Entities.INDYCOM>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaPor = buscarPor,
                Parametro = strParametro,
                //OrdenActual = orden,
                //TipoOrdenActual = tipo_orden,
                Resultado = _Indycom
            };
            if (_PaginadorIndycom == null)
            {
                return BadRequest(new { message = "No se encontraron los datos" });
            }
            return _PaginadorIndycom;
        }

        [HttpGet]
        public IActionResult GetConvenios(string nom_convenio)
        {
            var convenios = _iindycomService.GetConvenios(nom_convenio);
            if (convenios.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos" });
            }
            return Ok(convenios);

        }
        [HttpGet]
        public IActionResult GetMinimos_indycom(string minimo)
        {
            var minimos = _iindycomService.GetMinimos_indycom(minimo);
            if (minimos.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron datos" });
            }
            return Ok(minimos);
        }

        [HttpPost]
        public ActionResult BajaComercial(int legajo, string fecha_baja, Auditoria objAuditoria)
        {
            var objOriginal = _iindycomService.GetByPk(legajo);
            _iindycomService.BajaComercial(legajo, fecha_baja, objOriginal, objAuditoria);
            var indycom = _iindycomService.GetByPk(legajo);
            if (indycom.fecha_baja == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja!" });
            }
            return Ok(indycom);
        }

        [HttpPost]
        public ActionResult BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, Auditoria objAuditoria)
        {
            var objOriginal = _iindycomService.GetByPk(legajo);
            _iindycomService.BajaSucursal(legajo, nro_sucursal, fecha_baja, objOriginal, objAuditoria);
            var indycom = _iindycomService.GetByPk(legajo);
            if (indycom.fecha_baja == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja la Sucursal!" });
            }
            return Ok(indycom);
        }

        [HttpGet]
        public IActionResult GetBasesImponibles(int legajo, string periodo_desde, string periodo_hasta)
        {
            var bases = _iindycomService.GetBasesImponibles(legajo, periodo_desde, periodo_hasta);

            if (bases.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Bases Imponibles para este Legajo...!" });
            }
            return Ok(bases);
        }

        [HttpGet]
        public IActionResult GetRubros_x_iyc(int legajo)
        {
            var rubros = _iindycomService.GetRubros_x_iyc(legajo);

            if (rubros.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Rubros para este Legajo...!" });
            }
            return Ok(rubros);
        }

        [HttpGet]
        public IActionResult GetSucuralByLegajo(int legajo, int nro_sucursal)
        {
            var sucursales = _iindycomService.GetSucuralByLegajo(legajo, nro_sucursal);
            string des_com = string.Empty;

            if (sucursales.Nro_sucursal > 0)
            {
                des_com = sucursales.Des_com;
            }
            else
            {
                des_com = _iindycomService.GetByPk(legajo).des_com;
            }
            return Ok(des_com);
        }

        [HttpGet]
        public IActionResult BuscarRubroxDescripcion(string descripcion)
        {
            var rubros = _iindycomService.BuscarRubroxDescripcion(descripcion);
            if (rubros.Count == 0)
            {
                return BadRequest(new { message = "No se encontraron Rubros para esta Descripción...!" });
            }
            return Ok(rubros);
        }

        //[HttpPost]
        //public IActionResult InformeCtaCteCompleto(int legajo, string per, Auditoria objA)
        //{
        //    var reporte = _iindycomService.InformeCtaCteCompleto(legajo, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Legajo " + legajo });
        //    }
        //    return Ok(reporte);
        //}

        //[HttpPost]
        //public IActionResult InformeCtaCteSolodeuda(int legajo, int categoria_deuda, int categoria_deuda2, string per, Auditoria objA)
        //{
        //    var reporte = _iindycomService.InformeCtaCteSoloDeuda(legajo, categoria_deuda, categoria_deuda2, per, objA);
        //    if (reporte.Count == 0)
        //    {
        //        return BadRequest(new { message = @"Información, no se encontraron Datos para este Legajo " + legajo });
        //    }
        //    return Ok(reporte);
        //}

        [HttpGet]
        public ActionResult<List<Combo>> ListarCategoriasIyc()
        {
            var categorias = _iindycomService.ListarCategoriasIyc();
            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Resumendeuda(int legajo, int tipo_consulta, string periodo, int cate_deuda_desde, int cate_deuda_hasta, Auditoria objA)
        {
            var resumen = _iindycomService.Resumendeuda(legajo, tipo_consulta, periodo, cate_deuda_hasta, cate_deuda_hasta, objA);
            if (resumen.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Datos para este legajo " + legajo });
            }
            return Ok(resumen);
        }

        [HttpGet]
        public IActionResult GetCalle(string nomcalle)
        {
            var calles = _iindycomService.GetCalle(nomcalle);
            if (calles.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Calles " });
            }
            return Ok(calles);
        }

        [HttpGet]
        public IActionResult ConsultaIyc_x_calles(string calledesde, string callehasta)
        {
            var consulta = _iindycomService.ConsultaIyc_x_calles(calledesde, callehasta);
            if (consulta.Count == 0)
            {
                return BadRequest(new { message = @"Información,La Consulta no Contiene Datos...! " });
            }
            return Ok(consulta);
        }

        [HttpGet]
        public IActionResult GetBadecByNombre(string nombre)
        {
            var badec = _iindycomService.GetBadecByNombre(nombre);
            if (badec.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Contribuyentes " });
            }
            return Ok(badec);
        }

        [HttpGet]
        public IActionResult GetBadecByCuit(string cuit)
        {
            var badec = _iindycomService.GetBadecByCuit(cuit);
            if (badec.Count == 0)
            {
                return BadRequest(new { message = @"Información, no se encontraron Contribuyentes " });
            }
            return Ok(badec);
        }

        /* METODOS para la DECJUR*/
        //[HttpGet]
        //public IActionResult GetPeriodosDJSinLiquidar(int legajo)
        //{
        //    var iyc = _iindycomService.GetByPk(legajo);
        //    if (iyc.tipo_liquidacion == 2)
        //    {
        //        var decjur = _iindycomService.GetPeriodosDJSinLiquidar(legajo);
        //        if (decjur.Count == 0)
        //        {
        //            return BadRequest(new { message = @"El Comercio no debe Declaracion/es Jurada/s." });
        //        }
        //        else
        //        {
        //            return Ok(decjur);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = @"El Comercio no Presenta Declaracion Jurada." });
        //    }
        //}

        [HttpGet]
        public IActionResult GetPeriodosDJSinLiquidar(int legajo)
        {
            try
            {
                var iyc = _iindycomService.GetByPk(legajo);

                if (iyc == null)
                {
                    return BadRequest(new { message = "No se encontró información para el legajo proporcionado." });
                }

                if (iyc.tipo_liquidacion == 2)
                {
                    var decjur = _iindycomService.GetPeriodosDJSinLiquidar(legajo);

                    if (decjur == null || decjur.Count == 0)
                    {
                        return BadRequest(new { message = "El Comercio no debe Declaracion/es Jurada/s." });
                    }

                    return Ok(decjur);
                }
                else
                {
                    return BadRequest(new { message = "El Comercio no Presenta Declaracion Jurada." });
                }
            }
            catch (Exception ex)
            {
                // Manejo de la excepción y respuesta con código de estado 500
                return StatusCode(500, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ListaRubrosDJIyC(int nro_transaccion)
        {
            try
            {
                var rubrosdjiyc = _iindycomService.ListaRubrosDJIyC(nro_transaccion);

                if (rubrosdjiyc == null || !rubrosdjiyc.Any())
                {
                    return NotFound(new { message = "No se encontraron rubros para el número de transacción proporcionado." });
                }

                return Ok(rubrosdjiyc);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Número de transacción inválido.", error = ex.Message });
            }
            catch (Exception ex)
            {
                // Puedes loguear el error aquí si tienes un sistema de logging
                return StatusCode(500, new { message = "Se ha producido un error al obtener la lista de rubros.", error = ex.Message });
            }
        }
        //[HttpGet]
        //public IActionResult GetRubrosDJIyC(int nro_transaccion, int legajo)
        //{
        //    try
        //    {
        //        var rubros = _iindycomService.GetRubros_dec_jur_iyc(nro_transaccion, legajo);

        //        if (rubros == null || rubros.Count == 0)
        //        {
        //            return BadRequest(new { message = "La Declaración Jurada para este Período ha sido completada." });
        //        }

        //        return Ok(rubros);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de la excepción, puedes registrar el error si es necesario
        //        return StatusCode(500, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
        //    }

        //}

        [HttpPost]
        public IActionResult UpdateRubrosDJIyC(RubrosDJIyC_Con_Auditoria obj)
        {
            try
            {
                if (obj.legajo == 0 || obj.lst.Count == 0)
                {
                    return BadRequest(new { message = "No se pudo Actualizar porque la lista vino vacía!" });
                }

                foreach (var item in obj.lst)
                {
                    // Aquí usamos '&&' para asegurar que ambos valores sean no válidos para lanzar error
                    if (item.cantidad <= 0 && item.importe <= 0)
                    {
                        return BadRequest(new { message = "Debe ingresar cantidad o importe...!" });
                    }
                }

                // Llamada al servicio para realizar la actualización
                _iindycomService.UpdateRubrosDJIyC(obj.legajo, obj.lst, obj.auditoria);

                // Devuelve un mensaje más informativo
                return Ok(new { message = "Los rubros fueron actualizados exitosamente." });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, devolver un error de servidor
                return StatusCode(500, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult LiquidarDJIyC(DJIyC_Con_Auditoria obj)
        {
            try
            {
                // Validación del objeto 'obj'
                if (obj == null || obj.objDDJJ.nro_transaccion <= 0)
                {
                    return BadRequest(new { message = "Datos de la Declaración Jurada no válidos." });
                }

                if (_iindycomService.VerificarMontosIngresados(obj.legajo, obj.objDDJJ.nro_transaccion))
                {
                    return BadRequest(new { message = "Hay rubros a los cuales no se le han cargado los montos...!" });
                }
                // Llamada al servicio para realizar la Liquidacion
                _iindycomService.Liquidar_decjur(obj.legajo, obj.objDDJJ, obj.auditoria);
                // Devuelve un mensaje más informativo
                return Ok(new { message = "La Liquidacion de la DDJJ fue con exito." });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, devolver un error de servidor
                return StatusCode(500, new { message = "Ocurrió un error al procesar la Liquidacion.", error = ex.Message });
            }
        }

        //[HttpPost]
        //public IActionResult EliminaDDJJIyC(int legajo, int nro_transaccion, string periodo, Auditoria objA)
        //{
        //    try
        //    {
        //        var iyc = _iindycomService.GetByPk(legajo);
        //        if (iyc == null || iyc.tipo_liquidacion != 2)
        //        {
        //            return BadRequest(new { message = "El Comercio no Presenta Declaracion Jurada.!" });
        //        }
        //        var ddjjiyc = _iindycomService.GetDecJur_completadas(legajo, periodo);
        //        if (ddjjiyc.legajo <= 0)
        //        {
        //            return BadRequest(new { message = "No existe Declaración Jurada para este Periodo...!" });
        //        }

        //        if (_iindycomService.VerificaDecJurPagada(nro_transaccion))
        //        {
        //            return BadRequest(new { message = "El Periodo que quiere eliminar esta pagado...!" });
        //        }
        //        _iindycomService.EliminaDDJJIyC(ddjjiyc, objA);
        //        // Devuelve un mensaje más informativo
        //        return Ok(new { message = "La Liquidacion de la DDJJ fue con exito." });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones, devolver un error de servidor
        //        return StatusCode(500, new { message = "Ocurrió un error al procesar la Liquidacion.", error = ex.Message });
        //    }
        //}


        [HttpPost]
        public IActionResult EliminaDJIyC(int legajo, int nro_transaccion, string periodo, Auditoria objA)
        {
            try
            {
                // Validar los parámetros de entrada
                if (legajo <= 0 || nro_transaccion <= 0 || string.IsNullOrEmpty(periodo))
                {
                    return BadRequest(new { message = "Datos inválidos. Verifique los parámetros de entrada." });
                }

                // Obtener información del comercio
                var iyc = _iindycomService.GetByPk(legajo);
                if (iyc == null || iyc.tipo_liquidacion != 2)
                {
                    return BadRequest(new { message = "El Comercio no presenta Declaración Jurada." });
                }

                // Verificar si existe la declaración jurada completa
                var djiyc = _iindycomService.GetDecJur_completadas(legajo, periodo);
                if (djiyc == null || djiyc.legajo <= 0)
                {
                    return BadRequest(new { message = "No existe Declaración Jurada para este Periodo." });
                }

                // Verificar si la declaración está pagada
                if (_iindycomService.VerificaDecJurPagada(nro_transaccion))
                {
                    return BadRequest(new { message = "El Periodo que quiere eliminar está pagado." });
                }

                // Eliminar la declaración jurada
                _iindycomService.EliminaDJIyC(djiyc, objA);

                // Devuelve un mensaje de éxito más adecuado
                return Ok(new { message = "La Declaración Jurada fue eliminada exitosamente." });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return StatusCode(500, new { message = "Ocurrió un error al procesar la eliminación de la Declaración Jurada.", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetPeriodoDJLiquidado(int legajo, string periodo)
        {
            if (legajo <= 0)
            {
                return BadRequest(new { message = "Legajo no válido." });
            }

            if (string.IsNullOrWhiteSpace(periodo))
            {
                return BadRequest(new { message = "El periodo no puede estar vacío." });
            }

            try
            {
                var djiyc = _iindycomService.GetPeriodoDJLiquidado(legajo, periodo);
                if (djiyc == null)
                {
                    return NotFound(new { message = "No se encontró DJ para este comercio." });
                }
                if (djiyc.completa == false)
                {
                    return NotFound(new { message = string.Format("La DJ del Periodo {0} no esta Presentada.", periodo) });
                }
                return Ok(djiyc);
            }
            catch (Exception ex)
            {
                // Puedes registrar la excepción o devolver más información
                return StatusCode(500, new { message = "Ocurrió un error en el servidor.", error = ex.Message });
            }
        }
        /*FIN DDJJ*/

        //BAJA COMERCIO

        //if Data_IndYCom.IndYCom.Eof then
        //begin
        //Application.MessageBox('Se ha llegado al Final del Archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //Exit;
        //end;
        //if Data_IndYCom.IndYComFecha_Baja.IsNull=False then
        //begin
        //Application.MessageBox('Este Comercio/Industria ya está dado de baja.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //end;
        //Baja.Tipo_baja:=1;// baja de casa central
        //Baja.ShowModal;


        //        procedure TBaja.ConfirmaClick(Sender: TObject);
        //        var
        //          fecha_baja: TDateTime;
        //  fecha_acta: TDateTime;
        //  fecha_expediente: TDateTime;
        //  nro_sucursal:integer;
        //begin
        //  try
        //    fecha_baja:=StrToDate(EFecha_Baja.Text);
        //        except
        //          Application.MessageBox('Fecha baja incorrecta.',
        //            'SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Efecha_baja.SetFocus;
        //    Exit;
        //  end;
        //  try
        //    fecha_acta:=StrToDate(EFecha_Acta.Text);
        //        except
        //          Application.MessageBox('Fecha acta incorrecta.', 'SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Efecha_acta.SetFocus;
        //    Exit;
        //  end;
        //  try
        //    fecha_expediente:=StrToDate(EFecha_Expediente.Text);
        //        except
        //          Application.MessageBox('Fecha expediente incorrecta.', 'SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Efecha_expediente.SetFocus;
        //    Exit;
        //  end;
        //  Data_IndYCom.Siimva.StartTransaction;
        //  Application.CreateForm(TAutoriza, Autoriza);
        //  Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='BAJA IYC';
        //  if Autoriza.ShowModal<> mrOk then
        //  begin
        //    Data_IndYCom.Siimva.Rollback;
        //    Autoriza.Free;
        //    Exit;
        //  end;
        //  Data_IndyCom.Auditor_V2.ParamByName('@usuario').Value        := PriIyC.usuario;
        //  Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value   := Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //  Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value := Data_IndYCom.IndYComLegajo.AsString;
        //  Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value  := Autoriza.Memo1.Lines.Text;
        //  Data_IndyCom.Auditor_V2.ParamByName('@proceso').Value        := 'BAJA IYC';
        //  Data_IndyCom.Auditor_V2.ParamByName('@detalle').Value        := ENro_Res.Text + ' ..';
        //  Data_IndyCom.Auditor_V2.ExecProc;
        //  //Data_IndyCom.SIIMVA.Commit;
        //  Autoriza.Free;
        //  if Tipo_baja=1  then
        //  begin
        //      Data_IndYCom.IndYCom.Edit;
        //      Data_IndYCom.IndYComDado_Baja.Value:=True;
        //      Data_IndYCom.IndYComFecha_Baja.Value:=fecha_baja;
        //      Data_IndYCom.IndYCom.Post;
        //  end;
        //  if Tipo_baja=2 then
        //  begin
        //    nro_sucursal:= GestIyC.nro_sucursal;
        //    try
        //      //Data_IndYCom.Siimva.StartTransaction;
        //      Application.CreateForm(TAutoriza, Autoriza);
        //      Autoriza.Autoriza_Procesos.ParamByName('proceso').Value       := 'MODIFICACION INDYCOM';
        //      Data_IndyCom.sqlUpdSuc.close;
        //      Data_IndyCom.sqlUpdSuc.ParamByName('legajo').AsInteger        :=  Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger;
        //      Data_IndYCom.sqlUpdSuc.ParamByName('nro_sucursal').AsInteger  :=  nro_sucursal ;
        //      Data_IndYCom.sqlUpdSuc.ParamByName('fecha_baja').AsDateTime   :=  Now;
        //      Data_IndYCom.sqlUpdSuc.ParamByName('dado_baja').AsBoolean     :=  True;
        //      Data_IndyCom.sqlUpdSuc.ExecSQL;
        //      // Data_IndYCom.SUCURSALES_INDYCOM.close;
        //      //  Data_IndYCom.SUCURSALES_INDYCOM.Open;
        //      //Data_IndYCom.Siimva.Commit;
        //      Data_IndYCom.IndYCom.Refresh;
        //    except
        //      Data_IndYCom.Siimva.Rollback;
        //        Application.MessageBox('Datos erróneos. Revise.', 'SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Exit;
        //    end;
        //  end;
        //  Data_IndYCom.Siimva.Commit;

        //  if PrinterSetupDialog1.Execute=True then
        //  begin

        //    if Tipo_baja=1  then
        //    begin
        //        RBaja.QIndYCom.ParamByName('legajo').Value    := Data_IndYCom.IndYComLegajo.Value;
        //        RBaja.QIndYCom.Open;
        //        RBaja.QRLFecha_Expediente.Caption:=DateToStr(fecha_expediente);
        //        RBaja.QRLNombre.Caption:=GestIyC.BadecNombre.Value;
        //        RBaja.QRLLegajo2.Caption:=Data_IndYCom.IndYComLegajo.AsString;
        //        RBaja.QRLDes_Com.Caption:=Data_IndYCom.IndYComDes_Com.AsString;
        //        RBaja.QRLFecha_Acta.Caption:=DateToStr(fecha_acta);
        //        RBaja.QRLDes_Com2.Caption:=Data_IndYCom.IndYComDes_Com.AsString;
        //        RBaja.QRLNombre2.Caption:=GestIyC.BadecNombre.Value;
        //        RBaja.QRLLegajo.Caption:=Data_IndYCom.IndYComLegajo.AsString;
        //        RBaja.QRLNro_Res.Caption:=ENro_Res.Text;
        //        RBaja.QRLFecha_Baja.Caption:=EFecha_Baja.Text;
        //        RBaja.RepRes_Baja.Print;
        //        RBaja.QIndYCom.Close;
        //    end;

        //    if Tipo_baja=2  then
        //    begin
        //        RBajaSuc:= TRBajaSuc.Create(self);
        //        RBajaSuc.QSucIndYCom.Close;
        //        RBajaSuc.QSucIndYCom.ParamByName('legajo').Value       := Data_IndYCom.INDYCOMLegajo.Value;
        //        RBajaSuc.QSucIndYCom.ParamByName('nro_sucursal').Value := nro_sucursal;
        //        RBajaSuc.QSucIndYCom.Open;
        //        RBajaSuc.QRLFecha_Expediente.Caption:=DateToStr(fecha_expediente);
        //        RBajaSuc.QRLNombre.Caption:=GestIyC.BadecNombre.Value;
        //        RBajaSuc.QRLLegajo2.Caption:=RBajaSuc.QSucIndYComLegajo.AsString;
        //        RBajaSuc.QRLDes_Com.Caption:=RBajaSuc.QSucIndYComDes_Com.AsString;
        //        RBajaSuc.QRLFecha_Acta.Caption:=DateToStr(fecha_acta);
        //        RBajaSuc.QRLDes_Com2.Caption:=RBajaSuc.QSucIndYComDes_Com.AsString;
        //        RBajaSuc.QRLNombre2.Caption:=GestIyC.BadecNombre.Value;
        //        RBajaSuc.QRLLegajo.Caption:=RBajaSuc.QSucIndYComLegajo.AsString;
        //        RBajaSuc.QRLNro_Res.Caption:=  RBajaSuc.QSucIndYComNro_res.Value;
        //        RBajaSuc.QRLFecha_Baja.Caption:=EFecha_Baja.Text;
        //        RBajaSuc.qrlCalle.Caption := RBajaSuc.QSucIndYComNom_calle.Value + ' '+ RBajaSuc.QSucIndYComNro_dom.AsString ;
        //        RBajaSuc.RepRes_Baja.Preview;
        //        RBajaSuc.QSucIndYCom.Close;
        //        FreeAndNil(RBajaSuc);
        //        end;

        //  end;
        //end;


        //DATOS DEL CONTACTO DEL COMERCIO

//        procedure TDomPost.confirmaClick(Sender: TObject);
//        begin



//  if (Data_IndYCom.IndYComNom_Calle_Dom_Esp.Value=' ') or
//   (Data_IndYCom.IndYComNro_Dom_Esp.IsNull= True) then
//  begin
//    Application.MessageBox('Datos Incorrecto. Verifique.','SIIMVA-Error',MB_ICONERROR + MB_OK);
//    Exit;
//  end;
//  if Length(Data_IndYCom.IndYComemail_envio_cedulon.Value)>0 then
//    begin
//     if not EsEMail(Data_IndYCom.IndYComemail_envio_cedulon.Value) then
//     begin
//        Application.MessageBox('Ingrese correctamente el Email...','SIIMVA-Error',MB_ICONERROR + MB_OK);
//        Exit;
//     end;
//    end;

//  Data_IndYCom.Siimva.StartTransaction;
//  Data_IndYCom.IndYComFecha_Cambio_Domicilio.Value:=Now;
//  Data_IndYCom.IndYCom.Post;
//  Application.CreateForm(TAutoriza, Autoriza);
//  Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='RECALCULO DEUDA IYC';
//  if Autoriza.ShowModal<> mrOk then
//  begin
//    Autoriza.Free;
//    Data_IndYCom.Siimva.Rollback;
//    Exit;
//  end;
//  Data_IndyCom.Auditor_V2.ParamByName('@usuario').Value:=PriIyC.usuario;
//  Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value:=
//    Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
//  Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value:=
//    Data_IndYCom.IndYComLegajo.AsString;
//  Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value:=
//    Autoriza.Memo1.Lines.Text;
//  Data_IndyCom.Auditor_V2.ParamByName('@proceso').Value:='CAMBIO DOMIC. POSTAL INDYCOM';
//  Data_IndyCom.Auditor_V2.ParamByName('@detalle').Value:='Domic. Ant.: ' +
//    'Calle: ' + LeftString(auxnom_calle,25) +
//    ' Nro.: ' + LeftString(auxnro_dom,5) +
//    ' Piso/Dpto: ' + LeftString(auxpiso_dpto,15) +
//    ' Local: '+ LeftString(auxlocal,5) +
//    ' Barrio: ' + LeftString(auxnom_barrio,25);
//        Data_IndyCom.Auditor_V2.ExecProc;
//  Autoriza.Free;
//  Data_IndYCom.Siimva.Commit;
//end;



    }
}



