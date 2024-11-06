using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Auto.Helpers;
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

            if (objOriginal.dado_baja == true)
            {
                return BadRequest(new { message = "Comercio ya se encuentra dado de baja" });

            }
            _iindycomService.BajaComercial(legajo, fecha_baja, objOriginal, objAuditoria);
            var indycom = _iindycomService.GetByPk(legajo);
            if (indycom.fecha_baja == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja!" });
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

            if (sucursales.Nro_sucursal == 0)
            {
                return BadRequest(new { message = $"No se encontró la sucursal con número {nro_sucursal} para el legajo {legajo}." });
            }
            return Ok(sucursales);
        }

        [HttpGet]
        public IActionResult GetSucurales(int legajo)
        {
            var sucursales = _iindycomService.GetSucursales(legajo);
            return Ok(sucursales);
        }

        [HttpPost]
        public IActionResult NuevaSucursal(int legajo, Sucursal_Con_Auditoria obj)
        {

            var objOriginal = _iindycomService.GetByPk(legajo);
            if (objOriginal.dado_baja == true)
            {
                return BadRequest(new { message = "No se pudo dar de alta nueva la Sucursal!" });
            }
            _iindycomService.NuevaSucursal(legajo, obj, objOriginal);
            return Ok(new { message = "Sucursal creada exitosamente" });
        }

        [HttpPut]
        public IActionResult ModificarSucursal(int legajo, int nro_sucursal, Sucursal_Con_Auditoria obj)
        {
            var sucursal = _iindycomService.GetSucuralByLegajo(legajo, nro_sucursal);

            if (sucursal.Nro_sucursal == 0)
            {
                return BadRequest(new { message = $"No se encontró la sucursal con número {nro_sucursal} para el legajo {legajo}." });

            }

            var objOriginal = _iindycomService.GetByPk(legajo);
            if (objOriginal.dado_baja == true)
            {
                return BadRequest(new { message = "No se pudo modificar la  Sucursal!" });
            }
            _iindycomService.ModificarSucursal(legajo, nro_sucursal, obj, objOriginal);
            return Ok(new { message = "Sucursal modificada exitosamente" });
        }

        [HttpDelete]
        public IActionResult EliminarSucursal(int legajo, int nro_sucursal, Auditoria obj)
        {
            var sucursal = _iindycomService.GetSucuralByLegajo(legajo, nro_sucursal);

            if (sucursal.Nro_sucursal == 0)
            {
                return BadRequest(new { message = $"No se encontró la sucursal con número {nro_sucursal} para el legajo {legajo}." });

            }

            var objOriginal = _iindycomService.GetByPk(legajo);
            if (objOriginal.dado_baja == true)
            {
                return BadRequest(new { message = "No se pudo eliminar la  Sucursal!" });
            }
            _iindycomService.EliminarSucursal(legajo, nro_sucursal, obj, objOriginal);
            return Ok(new { message = "Sucursal Eliminada exitosamente" });
        }

        [HttpPut]
        public ActionResult BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, Auditoria objAuditoria)
        {
            var sucursal = _iindycomService.GetSucuralByLegajo(legajo, nro_sucursal);

            if (sucursal.Nro_sucursal == 0)
            {
                return BadRequest(new { message = $"No se encontró la sucursal con número {nro_sucursal} para el legajo {legajo}." });
            }
            var objOriginal = _iindycomService.GetByPk(legajo);
            if (sucursal.Dado_baja == true)
            {
                return BadRequest(new { message = "No se pudo dar de Baja logica la Sucursal!" });
            }
            _iindycomService.BajaSucursal(legajo, nro_sucursal, fecha_baja, objOriginal, objAuditoria);
            return Ok(new { message = "Sucursal dada de baja logica exitosamente" });
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
        public IActionResult GetCalle(string? nomcalle)
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
        public IActionResult GetElementosDJSinLiquidar(int legajo)
        {
            try
            {
                // var iyc = _iindycomService.GetByPk(legajo);

                // if (iyc == null)
                // {
                //     return BadRequest(new { message = "No se encontró información para el legajo proporcionado." });
                // }

                var lst = _iindycomService.GetElementosDJSinLiquidar(legajo);

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetElementosDJLiquidados(int legajo)
        {
            try
            {
                var iyc = _iindycomService.GetByPk(legajo);

                if (iyc == null)
                {
                    return BadRequest(new { message = "No se encontró información para el legajo proporcionado." });
                }

                var lst = _iindycomService.GetElementosDJLiquidados(legajo);

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al procesar la solicitud.", error = ex.Message });
            }
        }





        [HttpGet]
        public IActionResult ListaRubrosDJIyC(int nro_transaccion, int legajo)
        {
            try
            {
                var rubrosdjiyc = _iindycomService.ListaRubrosDJIyC(nro_transaccion, legajo);

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

        [HttpGet]
        public IActionResult ImprimirDDJJ(int legajo, int nro_transaccion)
        {
            if (legajo <= 0)
            {
                return BadRequest(new { message = "Legajo no válido." });
            }
            try
            {
                var impresion = _iindycomService.ImprimirDDJJ(legajo, nro_transaccion);
                return Ok(impresion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error en el servidor.", error = ex.Message });
            }

        }


        [HttpPut]
        public IActionResult actualizarDomicilioFiscal(int legajo, DatosDomicilioFiscal datos)
        {

            var iyc = _iindycomService.GetByPk(legajo);

            if (iyc == null)
            {
                return NotFound($"No se encontró el legajo {legajo}.");
            }

            _iindycomService.UpdateDomicilioFiscal(legajo, datos);

            return Ok(iyc);
        }

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
        //  Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value:= Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //  Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value:= Data_IndYCom.IndYComLegajo.AsString;
        //  Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value:=    Autoriza.Memo1.Lines.Text;
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


        [HttpGet]
        public IActionResult mostrarRubro(int legajo)
        {

            var lstRubro = _iindycomService.MostrarRubro(legajo);

            if (lstRubro == null)
            {
                return BadRequest("No posee rubros");
            }

            return Ok(lstRubro);
        }

        [HttpPost]
        public IActionResult nuevoRubro(RubrosIyC_Con_Auditoria obj)
        {

            try
            {
                if (obj == null)
                {
                    return BadRequest(new { message = "Datos de rubros no válidos." });
                }

                _iindycomService.NuevoRubro(obj.rubro, obj.auditoria);

                var nuevoRubro = _iindycomService.GetByPk(obj.rubro.legajo);

                return Ok(nuevoRubro);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error al intentar crear nuevo rubro: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateRubro(RubrosIyC_Con_Auditoria obj)
        {

            try
            {
                if (obj == null)
                {
                    return BadRequest(new { message = "Datos de rubros no válidos." });
                }

                _iindycomService.UpdateRubro(obj.rubro, obj.auditoria);

                var updatedRubro = _iindycomService.GetByPk(obj.rubro.legajo);

                return Ok(updatedRubro);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error al intentar actualizar el rubro: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult deleteRubro(int legajo, int cod_rubro, Auditoria objA)
        {
            try
            {
                var lstRubro = _iindycomService.MostrarRubro(legajo);

                var rubroEncontrado = lstRubro.Find(r => r.cod_rubro == cod_rubro);

                if (rubroEncontrado == null)
                {
                    return BadRequest("No se encontró un rubro con el código especificado.");
                }

                _iindycomService.DeleteRubro(legajo, cod_rubro, objA);

                return Ok("Rubro eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar eliminar el rubro: " + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult busquedaSucursal(int legajo, int? nro_sucursal)
        {
            try
            {
                var sucursal = _iindycomService.BusquedaSucarsal(legajo, nro_sucursal);

                return Ok(sucursal);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocurrió un error al intentar crear nuevo rubro: " + ex.Message);
            }
        }


        // Boton Busqueda de Sucursal
        //        procedure TRubros.btnSucClick(Sender: TObject);
        //        begin

        //            QRubros_x_IYCNro_sucursal.AsVariant:=Busqueda3(qSucursal,'Busqueda de Sucursal ', Data_IndYCom.IndYComLegajo.AsString);
        //        sqlSucursal.Close;
        //    if QRubros_x_IYCNro_sucursal.Value<>0 then
        //    begin
        //       sqlSucursal.sql.Clear;
        //       sqlSucursal.sql.Add('SELECT des_com FROM sucursales_indycom  WHERE legajo= :legajo  and nro_sucursal= :nro_sucursal and dado_baja=0 ');
        //       sqlSucursal.ParamByName('legajo').AsInteger :=  Data_IndYCom.IndYComLegajo.AsInteger;
        //       sqlSucursal.ParamByName('nro_sucursal').AsInteger:= QRubros_x_IYCNro_sucursal.AsInteger;
        //    end
        //    else
        //    begin
        //       sqlSucursal.sql.Clear;
        //        sqlSucursal.sql.Add('SELECT des_com FROM indycom  WHERE legajo= :legajo  ');
        //       sqlSucursal.ParamByName('legajo').AsInteger :=  Data_IndYCom.IndYComLegajo.AsInteger;

        //    end;
        //    sqlSucursal.Open;
        //    lblRazon.Caption:= sqlSucursal.FieldByName('des_com').AsString;

        //end;

        [HttpGet]
        public IActionResult busquedaRubros(string? busqueda)
        {

            var lst = _iindycomService.BusquedaRubros(busqueda);

            return Ok(lst);


        }


        // Boton Busqueda de Rubros
        // SELECT Concepto = CONVERT(CHAR(45), concepto),
        // Código = cod_rubro,
        // Anio
        // FROM RUBROS
        // WHERE activo = 1 AND concepto LIKE :nombre_aproximado
        // ORDER BY concepto

        [HttpGet]
        public IActionResult busquedaMinimo(string? busqueda)
        {
            try
            {
                List<ElementoMinimo> lst = _iindycomService.BusquedaMinimos(busqueda);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar buscar minimo: " + ex.Message);
            }
        }

        //Boton Busqueda de Minimo

        // SELECT Descripción = CONVERT(CHAR(40), des_minimo),
        // Código = cod_minimo
        // FROM MINIMOS_INDYCOM
        // WHERE des_minimo LIKE :nombre_aproximado
        // ORDER BY des_minimo

        //Boton Busqueda Convenio
        // SELECT Nombre = CONVERT(CHAR(40), nom_convenio),
        // Código = cod_convenio  FROM CONVENIOS_IYC
        // WHERE nom_convenio LIKE :nombre_aproximado
        // ORDER BY nom_convenio



        [HttpGet]
        public IActionResult busquedaConvenio(string? busqueda)
        {
            try
            {
                List<ElementoConvenio> lst = _iindycomService.BusquedaConvenios(busqueda);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al intentar buscar convenio: " + ex.Message);
            }
        }



        //Sucursales
        //        procedure TGestIyC.btnNuevoClick(Sender: TObject);
        //        begin
        //   if Data_IndyCom.INDYCOMtransporte.Value=True then
        //   begin
        //       MessageDlg('No es posible crear sucursales para este tipo de comercio', mtError, [mbOK], 0);
        //        exit;
        //   end;

        //   Data_IndyCom.sqlSucIndycom.Close;
        //   Data_IndyCom.dsSucursales.DataSet:= nil;
        //   Data_IndyCom.dsSucursales.DataSet:= Data_IndyCom.SUCURSALES_INDYCOM;
        //   Data_IndyCom.SUCURSALES_INDYCOM.Open;
        //   Data_IndyCom.SUCURSALES_INDYCOM.Append;
        //   tbCentral.TabVisible:=False;
        //   gbSucursal.Enabled := True;
        //   Dom_Ext.Enabled:=True;
        //   bbtnconfirma.Enabled:=True;
        //   bbtnCancelaSuc.Enabled:=True;
        //   btnNuevo.Enabled:=False;
        //   btnModifica.Enabled:=False;
        //   BtnElimina.Enabled:=False;
        //   BtnBaja.Enabled := False;
        //   estado_sucursal:='nuevo';
        //   lvSucursales.Enabled:=False;
        //   Limpia_Controles(gbSucursal);
        //        tbCentral.TabVisible   := False;
        //   deFechaHab.Text:='  /  /    ' ;
        //   deFechaBaja.Text:='  /  /    ' ;
        //   deFechaAltaExp.Text:='  /  /    ' ;
        //   edtNroExp.Text:='';
        //   deFechaInicio.Date:= now;
        //   chkInicio.Checked:=False;
        //   edtNrolocal.Enabled := True;
        //   edtNrolocal.Text := '';
        //   edtDepto.Enabled := true;
        //   edtDepto.Text :='';
        //   //dblZona.Enabled := True;
        //  // Data_IndyCom.SUCURSALES_INDYCOM.FieldByName('legajo').AsInteger:=  Data_IndyCom.INDYCOM.FieldByName('legajo').AsInteger ;
        //   edtNroExp.SetFocus;
        //   lblSuc.Visible:=False;
        //   lblLegajo.Visible:= TRUE;
        //   lblLegajo.Caption:= 'Leg: '+ Data_IndyCom.INDYCOMlegajo.AsString+' - '+Source_Badec.DataSet.fieldByName('nombre').AsString ;

        //end;

        //procedure TGestIyC.bbtnconfirmaClick(Sender: TObject);
        //        begin

        //          tbCentral.TabVisible                 := True;
        //        gbSucursal.Enabled                   := False;
        //  if estado_sucursal='nuevo' then
        //  begin
        //    with Data_IndYCom  do
        //    begin

        //    try
        //      Data_IndYCom.Siimva.StartTransaction;
        //      SUCURSALES_INDYCOMNro_sucursal.Value     := MayorId('SUCURSALES_INDYCOM','nro_sucursal', Data_IndyCom.sqlconsulta,' legajo = '+IntToStr(INDYCOMlegajo.Value ) );
        //        SUCURSALES_INDYCOMLegajo.Value           :=  INDYCOMlegajo.Value;
        //      SUCURSALES_INDYCOMDes_com.Value          :=  edtDescripcion.Text;
        //      SUCURSALES_INDYCOMNom_fantasia.Value     :=  edtNombre.Text;
        //      SUCURSALES_INDYCOMCod_Calle.Value        :=  auxcod_calle;
        //      SUCURSALES_INDYCOMNom_calle.Value        :=  edtCalle.Text;
        //      SUCURSALES_INDYCOMNro_dom.Value          :=  StrToInt(edtNrodom.text);
        //        SUCURSALES_INDYCOMCod_Barrio.Value       :=  auxcod_barrio;
        //      SUCURSALES_INDYCOMNom_barrio.Value       :=  edtBarrio.Text;
        //      SUCURSALES_INDYCOMCiudad.Value           :=  edtCiudad.Text;
        //      SUCURSALES_INDYCOMProvincia.Value        :=  edtProvincia.Text;
        //      SUCURSALES_INDYCOMPais.Value             :=  edtPais.Text;
        //      SUCURSALES_INDYCOMCod_postal.Value       :=  edtCP.Text;
        //      SUCURSALES_INDYCOMNro_res.Value          :=  edtNroRes.Text;
        //      SUCURSALES_INDYCOMFecha_inicio.Value     :=  deFechaInicio.Date;
        //      SUCURSALES_INDYCOMnro_exp_mesa_ent.Value := edtNroExp.Text;
        //      SUCURSALES_INDYCOMFecha_alta.Value       := deFechaAltaExp.Date;
        //      SUCURSALES_INDYCOMcod_zona.Value         := cmbZona.Text;
        //      SUCURSALES_INDYCOMNro_local.Value        := edtNrolocal.Text;
        //      SUCURSALES_INDYCOMpiso_dpto.Value        := edtDepto.text;
        //      SUCURSALES_INDYCOMVto_inscripcion.Value  := SUCURSALES_INDYCOMFecha_alta.Value+90;

        //      if (deFechaBaja.Text<>'  /  /    ') then
        //         SUCURSALES_INDYCOMFecha_Baja.Value    :=  deFechaBaja.Date;
        //      if (deFechaHab.Text<>'  /  /    ') then
        //         SUCURSALES_INDYCOMFecha_hab.Value      :=  deFechaHab.Date;

        //        SUCURSALES_INDYCOMDado_baja.Value      :=  chkInicio.Checked;
        //      SUCURSALES_INDYCOM.Post;

        //      Limpia_Controles(GestIyC.gbSucursal);
        //        sqlSucIndycom.Close;
        //      sqlSucIndycom.ParamByName('legajo').AsInteger       :=  INDYCOM.fieldByName('legajo').AsInteger;
        //      sqlSucIndycom.ParamByName('nro_sucursal').AsInteger :=  1;
        //      sqlSucIndycom.Open;

        //      sqlupdIyc.Close;
        //      sqlupdIyc.ParamByName('legajo').AsInteger       :=  INDYCOM.fieldByName('legajo').AsInteger;
        //      sqlupdIyc.ParamByName('con_sucursal').AsBoolean :=  true;
        //      sqlupdIyc.ExecSQL;


        //      sqlSucursales.Close;
        //      sqlSucursales.ParamByName('legajo').AsInteger:=  INDYCOM.fieldByName('legajo').AsInteger;
        //      sqlSucursales.Open;

        //      Data_IndYCom.Siimva.Commit;
        //      Data_IndYCom.IndYCom.Refresh;
        //      SUCURSALES_INDYCOM.close;
        //      SUCURSALES_INDYCOM.Open;
        //      Carga_Listvw(sqlSucursales, GestIyC.lvSucursales);
        //        CargarDatos;
        //      lblSuc.Visible:=True;
        //      lblLegajo.Visible:= False;
        //    except
        //      Data_IndYCom.Siimva.Rollback;
        //        Application.MessageBox('Datos erróneos. Revise.',
        //        'SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Exit;
        //    end;







        //    end;
        //  end;

        //  if estado_sucursal='modifica' then
        //  begin

        //    try
        //       Data_IndYCom.Siimva.StartTransaction;
        //       {Data_IndYCom.IndYComNom_Calle.Value:=Data_IndYCom.IndYComCalle.Value;
        //       Data_IndYCom.IndYComNom_Barrio.Value:=Data_IndYCom.IndYComBarrio.Value;}
        //    Application.CreateForm(TAutoriza, Autoriza);
        //       Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='MODIFICACION INDYCOM';
        //      if Autoriza.ShowModal<> mrOk then
        //      begin
        //        Autoriza.Free;
        //        Data_IndYCom.Siimva.Rollback;
        //        Exit;
        //      end;
        //      Data_IndyCom.sqlUSuc_IYC.Close;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Nro_sucursal').AsInteger     :=  StrToInt(edtsuc.text);
        //    Data_IndyCom.sqlUSuc_IYC.ParamByName('Legajo').AsInteger           :=  Data_IndyCom.INDYCOM.FieldByName('legajo').asinteger;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Des_com').AsString           :=  edtDescripcion.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Nom_fantasia').AsString      :=  edtNombre.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Cod_Calle').AsInteger        :=  auxcod_calle;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Nom_calle').AsString         :=  edtCalle.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Nro_dom').AsInteger          :=  StrToInt(edtNrodom.text);
        //    Data_IndyCom.sqlUSuc_IYC.ParamByName('Cod_Barrio').AsInteger       :=  auxcod_barrio;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Nom_barrio').AsString        :=  edtBarrio.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Ciudad').AsString            :=  edtCiudad.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Provincia').AsString         :=  edtProvincia.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Pais').AsString              :=  edtPais.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('Cod_postal').AsString        :=  edtCP.Text;


        //      if (deFechaHab.Text='  /  /    ') then
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_hab').value      := null
        //      else
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_hab').AsDateTime := deFechaHab.Date;
        //      //Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_hab').AsDateTime       :=  deFechaHab.Date;
        //      if (deFechaAltaExp.Text='  /  /    ') then
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('vto_inscripcion').value      := null
        //      else
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('vto_inscripcion').AsDateTime :=  deFechaAltaExp.Date +90;
        //      //Data_IndyCom.sqlUSuc_IYC.ParamByName('vto_inscripcion').AsDateTime :=  deFechaAltaExp.Date +90;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('nro_res').AsString           :=  edtNroRes.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('nro_exp_mesa_ent').AsString  :=  edtNroExp.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('nro_local').AsString         := edtNrolocal.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('piso_dpto').AsString         :=  edtDepto.Text;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('cod_zona').AsString          :=  cmbZona.Text;
        //      //
        //      if (deFechaAltaExp.Text='  /  /    ') then
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_alta').value      := null
        //      else
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_alta').AsDateTime :=  deFechaAltaExp.Date;

        //      if (deFechaBaja.Text='  /  /    ') then
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_baja').Value   := null
        //      else
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_baja').AsDateTime   :=  deFechaBaja.Date;

        //      if (deVtoCertif.Text='  /  /    ') then
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('vto_certificado').value      := null
        //      else
        //        Data_IndyCom.sqlUSuc_IYC.ParamByName('vto_certificado').AsDateTime := deVtoCertif.Date;

        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('fecha_inicio').AsDateTime     := deFechaInicio.Date;
        //      Data_IndyCom.sqlUSuc_IYC.ParamByName('dado_baja').AsBoolean         := chkInicio.Checked;
        //      Data_IndyCom.sqlUSuc_IYC.ExecSQL;

        //      Data_IndyCom.sqlupdIyc.Close;
        //      Data_IndyCom.sqlupdIyc.ParamByName('legajo').AsInteger       := Data_IndyCom.INDYCOM.FieldByName('legajo').asinteger;
        //      Data_IndyCom.sqlupdIyc.ParamByName('con_sucursal').AsBoolean := true;
        //      Data_IndyCom.sqlupdIyc.ExecSQL;

        //      Data_IndyCom.Auditor_V2.ParamByName('@usuario').Value:= PriIyC.usuario;
        //      Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value:=
        //      Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //      Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value:=
        //        Data_IndyCom.INDYCOM.FieldByName('legajo').AsString +' - '+ edtsuc.text;
        //      Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value:=
        //        Autoriza.Memo1.Lines.Text;
        //      Data_IndyCom.Auditor_V2.ParamByName('@proceso').Value:= 'MODIFICACION SUCURSAL INDYCOM';
        //      Data_IndyCom.Auditor_V2.ParamByName('@detalle').Value:= 'Modificacion de datos de la sucursal';


        //      Data_IndYCom.sqlSucIndycom.Close;
        //      Data_IndYCom.sqlSucIndycom.ParamByName('legajo').AsInteger       :=  Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger;
        //      Data_IndYCom.sqlSucIndycom.ParamByName('nro_sucursal').AsInteger := StrToInt(edtsuc.Text);
        //    Limpia_Controles(gbSucursal);
        //    Data_IndYCom.sqlSucIndycom.Open;
        //      Data_IndYCom.sqlSucursales.Close;
        //      Data_IndYCom.sqlSucursales.ParamByName('legajo').AsInteger:=  Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger;
        //      Data_IndYCom.sqlSucursales.Open;
        //      Carga_Listvw(Data_IndYCom.sqlSucursales, GestIyC.lvSucursales);
        //    Data_IndYCom.Siimva.Commit;
        //      Data_IndYCom.SUCURSALES_INDYCOM.close;
        //      Data_IndYCom.SUCURSALES_INDYCOM.Open;

        //      CargarDatos;

        //     except
        //      Data_IndYCom.Siimva.Rollback;
        //    Application.MessageBox('Datos erróneos. Revise.',
        //        'SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Exit;
        //    end;


        //  end;
        //  if estado_sucursal='elimina' then
        //  begin
        //     if VerificarsinoTieneRubro(Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger,StrToInt(edtsuc.Text)) then
        //     begin
        //        try
        //            Data_IndYCom.Siimva.StartTransaction;
        //            Application.CreateForm(TAutoriza, Autoriza);
        //            Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='ELIMINACION SUCURSAL INDYCOM';
        //            Data_IndyCom.sqlBorraSucursal.close;
        //            Data_IndyCom.sqlBorraSucursal.ParamByName('legajo').AsInteger        :=  Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger;
        //            Data_IndYCom.sqlBorraSucursal.ParamByName('nro_sucursal').AsInteger  :=  StrToInt(edtsuc.Text);
        //    Data_IndyCom.sqlBorraSucursal.ExecSQL;
        //            Data_IndYCom.SUCURSALES_INDYCOM.close;
        //            Data_IndYCom.SUCURSALES_INDYCOM.Open;
        //            Data_IndYCom.Siimva.Commit;
        //            Data_IndYCom.IndYCom.Refresh;
        //            Data_IndYCom.sqlSucursales.Close;
        //            Data_IndYCom.sqlSucursales.ParamByName('legajo').AsInteger:=  Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger;
        //            Data_IndYCom.sqlSucursales.Open;
        //            Carga_Listvw(Data_IndYCom.sqlSucursales, GestIyC.lvSucursales);
        //    limpiarSucursal;

        //         except
        //          Data_IndYCom.Siimva.Rollback;
        //    Application.MessageBox('Datos erróneos. Revise.',
        //            'SIIMVA-Error',MB_ICONERROR + MB_OK);
        //          Exit;
        //        end;

        //        if SinSucursales(Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger)   then
        //        begin
        //          Data_IndYCom.INDYCOM.Edit;
        //          Data_IndYCom.INDYCOMCon_Sucursal.Value := False;
        //          Data_IndYCom.INDYCOM.Post;
        //        end;
        //     end
        //     else
        //     begin
        //        MessageDlg('Antes de eliminar debe quitar los rubros asociados a esta '+#13+#10+'sucursal', mtError, [mbOK], 0);
        //     end;


        //    end;




        //  bbtnconfirma.Enabled   := False;
        //  bbtnCancelaSuc.Enabled := False;
        //  estado_sucursal:='navega';
        //  btnNuevo.Enabled:=True;
        //  btnModifica.Enabled:=True;
        //  BtnElimina.Enabled:=True;
        //  lvSucursales.Enabled:= true;
        //  tbCentral.TabVisible   := True;
        //  lblLegajo.Caption:= '';
        //  Dom_Ext.Checked        := False ;
        //  BCalle.Enabled:=True;
        //  BtnBaja.Enabled := True;
        //  //dblZona.Enabled := False;
        //end;

        //procedure TGestIyC.BCalleClick(Sender: TObject);
        //    begin
        //try
        //    auxcod_calle:=Busqueda(QCalles,'Búsqueda de Calle');
        //    QCalles.Open;
        //    QCalles.Locate('Código',auxcod_calle,[]);
        //    edtCalle.Text:=QCallesNombre.Value;

        //  except
        //    auxcod_calle:=0;
        //    auxcod_barrio:=0;

        //    //dbeCalle.Text:=' ';
        //    //dbeBarrio.Text:=' ';

        //    QCalles.Close;
        //    Application.MessageBox('Calle incorrecta.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //    Exit;
        //  end;
        //  QCalles.Close;
        //  edtNrodom.SetFocus;
        //end;

        //procedure TGestIyC.BCond_ivaClick(Sender: TObject);
        //    begin
        //    //QTipos_de_iva.Close;
        //    //ProveedoresCod_cond_ante_iva.AsVariant := Busqueda(QTipos_de_iva,'Busqueda de Condición ante IVA');
        //    end;

        //    procedure TGestIyC.dbeNroExit(Sender: TObject);
        //    begin
        //if not Dom_Ext.Checked=True then
        //  begin
        //    QCalles_x_Barrio.ParamByName('cod_calle').Value:=auxcod_calle;
        //    QCalles_x_Barrio.Open;
        //    QCalles_x_Barrio.First;
        //    while not QCalles_x_Barrio.Eof do
        //    begin
        //      if (StrToInt(edtNrodom.Text) >= QCalles_x_BarrioDesde.Value) and
        //        (StrToInt(edtNrodom.Text) <= (QCalles_x_BarrioHasta.Value)) and
        //        (((power(-1, StrToInt(edtNrodom.Text)) > 0) and
        //        (QCalles_x_BarrioPar.Value= True)) or
        //        ((power(-1, StrToInt(edtNrodom.Text)) < 0) and
        //        (QCalles_x_BarrioImPar.Value= True)))  then
        //      begin
        //        break;
        //      end;
        //      QCalles_x_Barrio.Next;
        //    end;

        //    if not QCalles_x_Barrio.Eof then
        //    begin
        //      auxcod_barrio:=QCalles_x_BarrioCod_Barrio.Value;
        //    Barrios.Open;
        //      try
        //        Barrios.FindKey([auxcod_barrio]);
        //        edtBarrio.Text:=BarriosNom_Barrio.Value;
        //      except
        //        Application.MessageBox('No se encuentra Barrio para esta Calle y Nº Domic..','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //    edtBarrio.Text:=' ';
        //        auxcod_barrio:=0;
        //        QCalles_x_Barrio.Close;
        //        Barrios.Close;
        //        edtNrodom.SetFocus;
        //        exit;
        //      end;
        //      Barrios.Close;
        //    end
        //    else
        //    begin
        //      Application.MessageBox('No se encuentra Barrio para esta Calle y Nº Domic..','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //    edtBarrio.Text:=' ';
        //      auxcod_barrio:=0;
        //      QCalles_x_Barrio.Close;
        //      exit;
        //    end;
        //    QCalles_x_Barrio.Close;
        //    edtCiudad.Text:='VILLA ALLENDE';
        //    edtProvincia.Text:='CORDOBA';
        //    edtPais.Text:='ARGENTINA';
        //    edtCp.Text:='5105';
        //  end;
        //end;

        //procedure TGestIyC.DBLookupComboBox2Click(Sender: TObject);
        //    begin
        //    if TIPOS_DE_IVAcod_cond_ante_iva.Value=6 then
        //    begin
        //       dbeCategoria.ReadOnly:=False;

        //    end
        //    else
        //    begin
        //       dbeCategoria.ReadOnly:=True;
        //    dbeCategoria.Clear;
        //    end;
        //end;

        //procedure TGestIyC.Dom_ExtClick(Sender: TObject);
        //    begin
        //if Dom_Ext.Checked=True then
        //  begin
        //    edtCalle.Enabled:=True;
        //    edtBarrio.Enabled:=True;
        //    edtCiudad.Enabled:=True;
        //    edtProvincia.Enabled:=True;
        //    edtPais.Enabled:=True;
        //    edtCP.Enabled:=True;
        //    edtCalle.Enabled:=true;
        //    auxcod_calle:=0;
        //    auxcod_barrio:=0;
        //    edtCiudad.Text:='';
        //    edtProvincia.Text:='';
        //    edtPais.Text:='';
        //    edtCP.Text:='';
        //  end
        //  else
        //  begin
        //    edtCalle.Enabled:=False;
        //    edtBarrio.Enabled:=False;
        //    edtCiudad.Enabled:=False;
        //    edtProvincia.Enabled:=False;
        //    edtPais.Enabled:=False;
        //    edtCP.Enabled:=False;
        //    edtCalle.Enabled:=False;
        //    edtCiudad.Text:='VILLA ALLENDE';
        //    edtProvincia.Text:='CORDOBA';
        //    edtPais.Text:='ARGENTINA';
        //    edtCP.Text:='5105';
        //  end;
        //end;




        //       procedure TGestIyC.BtnBajaClick(Sender: TObject);
        //       begin

        //{ estado_sucursal:='elimina';
        // btnNuevo.Enabled:=False;
        // btnModifica.Enabled:=False;
        // BtnElimina.Enabled:=False;
        // bbtnCancelaSuc.Enabled := True ;
        // bbtnconfirma.Enabled   := True;
        // tbCentral.TabVisible   := False;   }

        // if Data_IndYCom.IndYCom.Eof then
        // begin
        //   Application.MessageBox('Se ha llegado al Final del Archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //   Exit;
        // end;
        // if Data_IndYCom.IndYComFecha_Baja.IsNull=False then
        // begin
        //   Application.MessageBox('Este Comercio/Industria ya está dado de baja.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //   end;
        // Baja.Tipo_baja:=2; // baja de sucursal
        // Baja.ShowModal;
        // if SinSucursales(Data_IndYCom.INDYCOM.fieldByName('legajo').AsInteger)   then
        //   begin
        //     Data_IndYCom.INDYCOM.Edit;
        //     Data_IndYCom.INDYCOMCon_Sucursal.Value := False;
        //     Data_IndYCom.INDYCOM.Post;
        //   end;

        // end;


        // Listar Sucursales
        //        SELECT nro_sucursal,
        //                     Des_com,
        //                     Nom_calle,
        //                     nro_dom,
        //                     nro_local

        // FROM SUCURSALES_INDYCOM
        // where legajo = :legajo
        // order by nro_sucursal


       

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///Gestion de Deudas
        ///
        // SELECT* FROM CTASCTES_INDYCOM WHERE
        //                   legajo=:legajo AND
        //                   tipo_transaccion=1 AND pagado = 0
        //                   AND pago_parcial = 0 AND nro_plan IS NULL AND
        //                   nro_procuracion IS NULL
        //         ORDER BY periodo


        //Categoria de de Deudas Desplegable dbo.CATE_DEUDA_INDYCOM

        //Nueva deuda
        //        procedure TGestFact.NuevoClick(Sender: TObject);
        //        var
        //           permiso: integer;
        //begin
        //  permiso:=Verificar_Permiso_v2(PriIyC.usuario,'NUEVA_DEUDA_IYC');
        //  if permiso=0 then
        //  begin
        //    Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //    Exit
        //  end;
        //        operacion := 'Nuevo';
        //  Panel_Titulo.Caption   := 'Nueva Deuda';
        //  Navegador.Enabled      := False;
        //  Activa_Desactiva_Controles(Panel_Operaciones);
        //        Legajo.Enabled         := False;
        //  Combo_Cate.Enabled     := True;
        //  Periodo.Enabled        := True;
        //  Vencimiento.Enabled    := True;
        //  Monto_Original.Enabled := True;
        //  Debe.Enabled           := True;
        //  Confirma.Enabled       := True;
        //  Cancela.Enabled        := True;
        //  QDeudas_Otras.Append;
        //  QDeudas_OtrasLegajo.Value      := Data_IndYCom.IndYComLegajo.Value;
        //  QDeudas_OtrasVencimiento.Value := Now;
        //  Combo_Cate.SetFocus;
        //end;


        //
        //        procedure TGestFact.ModificaClick(Sender: TObject);
        //        var
        //           permiso: integer;
        //begin
        //  permiso:=Verificar_Permiso_v2(PriIyC.usuario,'MODIFICA_DEUDA_IYC');
        //  if permiso=0 then
        //  begin
        //    Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //    Exit
        //  end;
        //        operacion:='Modifica';
        //  if QDeudas_Otras.Eof then
        //  begin
        //    Application.MessageBox('No hay deudas por facturación o se ha llegado a final de archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Exit;
        //  end;
        //  QDeudas_Otras.Edit;
        //  Panel_Titulo.Caption:='Modifica Deuda';
        //  Activa_Desactiva_Controles(Panel_Operaciones);
        //        Legajo.Enabled:=False;
        //  Navegador.Enabled:=False;
        //  Vencimiento.Enabled:=True;
        //  Monto_Original.Enabled:=True;
        //  Debe.Enabled:=True;
        //  Confirma.Enabled:=True;
        //  Cancela.Enabled:=True;
        //  Vencimiento.SetFocus;
        //end;

        //procedure TGestFact.EliminaClick(Sender: TObject);
        //        var
        //           permiso: integer;
        //begin
        //  permiso:=Verificar_Permiso_v2(PriIyC.usuario,'ELIMINA_DEUDA_IYC');
        //  if permiso=0 then
        //  begin
        //    Application.MessageBox('Acceso Denegado.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //    Exit
        //  end;
        //        operacion:='Elimina';
        //  if QDeudas_Otras.Eof then
        //  begin
        //    Application.MessageBox('No hay deudas por facturación o se ha llegado a final de archivo.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Exit;
        //  end;
        //  Panel_Titulo.Caption:='Elimina Deuda';
        //  Activa_Desactiva_Controles(Panel_Operaciones);
        //        Navegador.Enabled:=False;
        //  Confirma.Enabled:=True;
        //  Cancela.Enabled:=True;
        //  Cancela.SetFocus;
        //end;





        //        procedure TGestFact.confirmaClick(Sender: TObject);
        //        var
        //          auxnro_transaccion: integer;
        //  bandera: boolean;
        //  year: word;
        //  month: word;
        //  day: word;
        //begin
        //  if operacion='Nuevo' then
        //  begin
        //    if QDeudas_OtrasCod_Cate_Deuda.IsNull=True then
        //    begin
        //      Application.MessageBox('No seleccionó Categoría Deuda.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Combo_Cate.SetFocus;
        //      Exit;
        //    end;
        //    if QDeudas_OtrasMonto_Original.Value <=0 then
        //    begin
        //      Application.MessageBox('Monto Original Incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Monto_Original.SetFocus;
        //      Exit;
        //    end;
        //    if QDeudas_OtrasDebe.Value <=0 then
        //    begin
        //      Application.MessageBox('Debe Incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Debe.SetFocus;
        //      Exit;
        //    end;
        //    if QDeudas_OtrasDebe.Value<QDeudas_OtrasMonto_Original.Value then
        //    begin
        //      Application.MessageBox('El Monto Original debe ser menor o igual que lo que se debe.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Monto_Original.SetFocus;
        //      Exit;
        //    end;

        //    if QDeudas_OtrasCod_Cate_Deuda.Value=1 then
        //    begin
        //      if Length(QDeudas_OtrasPeriodo.Value)<>7 then
        //      begin
        //        Application.MessageBox('Periodo Incorrecto...','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //        Periodo.SetFocus;
        //        Exit;
        //      end;
        //      if QDeudas_OtrasPeriodo.IsNull=True then
        //      begin
        //        Application.MessageBox('Periodo Incorrecto.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Periodo.SetFocus;
        //        Exit;
        //      end;
        //      if QDeudas_OtrasVencimiento.IsNull=True then
        //      begin
        //        Application.MessageBox('Fecha Incorrecta.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Vencimiento.SetFocus;
        //        Exit;
        //      end;

        //    end;
        //    Application.CreateForm(TAutoriza, Autoriza);
        //    Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='NUEVA DEUDA INDYCOM';
        //    if Autoriza.ShowModal<> mrOk then
        //    begin
        //      Autoriza.Free;
        //      Exit;
        //    end;
        //    try
        //      Data_IndYCom.Siimva.StartTransaction;
        //      Numeros_Claves.Last;
        //      auxnro_transaccion:=Numeros_ClavesNro_Tran_IYC.Value + 1;
        //      bandera:=False;
        //      while bandera=False do
        //      begin
        //        try
        //          Numeros_Claves.Edit;
        //          Numeros_ClavesNro_Tran_IYC.Value:=auxnro_transaccion;
        //          Numeros_Claves.Post;
        //          bandera:=True;
        //        except
        //          bandera:=False;
        //          auxnro_transaccion:=auxnro_transaccion + 1;
        //        end;
        //      end;
        //      with Data_IndyCom.Auditor_V2 do
        //      begin
        //        ParamByName('@usuario').Value        := PriIyC.usuario;
        //        ParamByName('@autorizacion').Value   := Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //        ParamByName('@identificacion').Value := Data_IndYCom.IndYComLegajo.AsString;
        //        ParamByName('@observaciones').Value  := Autoriza.Memo1.Lines.Text;
        //        ParamByName('@proceso').Value        := 'NUEVA DEUDA INDYCOM';
        //        ParamByName('@detalle').Value        := 'Periodo: ' + QDeudas_OtrasPeriodo.Value +
        //         ' Monto original: ' + FloatToStr(QDeudas_otrasMonto_original.Value) +
        //         ' Deuda: ' + FloatToStr(QDeudas_OtrasDebe.Value);
        //        end;
        //      Data_IndyCom.Auditor_V2.ExecProc;

        //      DecodeDate(date, year, month, day);
        //        Ctasctes_IndYCom.Append;
        //      Ctasctes_IndYComTipo_Transaccion.Value  := 1;
        //      Ctasctes_IndYComNro_Transaccion.Value   := auxnro_transaccion;
        //      Ctasctes_IndYComNro_Pago_Parcial.Value  := 0;
        //      Ctasctes_IndYComLegajo.Value            := QDeudas_OtrasLegajo.Value;
        //      Ctasctes_IndYComFecha_Transaccion.Value := now;
        //      if (QDeudas_OtrasCod_Cate_Deuda.Value=1) or(QDeudas_OtrasPeriodo.IsNull= False) then
        //        Ctasctes_IndYComPeriodo.Value := QDeudas_OtrasPeriodo.Value
        //      else
        //        Ctasctes_IndYComPeriodo.Value :=
        //          LeftString(Cate_Deuda_IndYComDes_Categoria.Value,1) +
        //            Rellena_Izquierda('0',2, IntToStr(day)) +
        //            Rellena_Izquierda('0',2, IntToStr(month)) +
        //            Rellena_Izquierda('0',2, RightString(IntToStr(year),2));

        //      Ctasctes_IndYComMonto_Original.Value      := QDeudas_OtrasMonto_Original.Value;
        //      Ctasctes_IndYComPagado.Value              := False;
        //      Ctasctes_IndYComDebe.Value                := QDeudas_OtrasDebe.Value;
        //      Ctasctes_IndYComHaber.Value               := 0;
        //      Ctasctes_IndYComPago_Parcial.Value        := False;
        //      Ctasctes_IndYComCod_Cate_Deuda.Value      := QDeudas_OtrasCod_Cate_Deuda.Value;
        //      Ctasctes_IndYComVencimiento.Value         := QDeudas_OtrasVencimiento.Value;
        //      Ctasctes_IndYComDeclaracion_Jurada.Value  := True;
        //      Ctasctes_IndYComLiquidacion_Especial.Value:= False;
        //      Ctasctes_IndYCom.Post;

        //      //Grabo primer concepto: Tasa Básica
        //      Detalle_Deuda_IndYCom.Append;
        //      Detalle_Deuda_IndYComNro_Transaccion.Value := Ctasctes_IndYComNro_Transaccion.Value;
        //      Detalle_Deuda_IndYComNro_Item.Value        := 1;
        //      Detalle_Deuda_IndYComFecha_Item.Value      := Ctasctes_IndYComFecha_Transaccion.Value;
        //      Detalle_Deuda_IndYComCod_Concepto_IYC.Value:= 1;
        //      Detalle_Deuda_IndYComSuma_Item.Value       := True;
        //      Detalle_Deuda_IndYComImporte_Item.Value    := Ctasctes_IndYComMonto_Original.Value;
        //      Detalle_Deuda_IndYComActivo_Item.Value     := True;
        //      Detalle_Deuda_IndYComImporte_Actual.Value  := Ctasctes_IndYComMonto_Original.Value;
        //      Detalle_Deuda_IndYCom.Post;
        //      //Grabo segundo concepto si corresponde: Interés
        //      if QDeudas_OtrasMonto_Original.Value<> QDeudas_OtrasDebe.Value then
        //      begin
        //        Detalle_Deuda_IndYCom.Append;
        //        Detalle_Deuda_IndYComNro_Transaccion.Value  := Ctasctes_IndYComNro_Transaccion.Value;
        //        Detalle_Deuda_IndYComNro_Item.Value         := 2;
        //        Detalle_Deuda_IndYComFecha_Item.Value       := Ctasctes_IndYComFecha_Transaccion.Value;
        //        Detalle_Deuda_IndYComCod_Concepto_IYC.Value := 2;
        //        Detalle_Deuda_IndYComSuma_Item.Value        := True;
        //        Detalle_Deuda_IndYComImporte_Item.Value     := Ctasctes_IndYComDebe.Value - Ctasctes_IndYComMonto_Original.Value;
        //        Detalle_Deuda_IndYComActivo_Item.Value      := True;
        //        Detalle_Deuda_IndYComImporte_Actual.Value   := Ctasctes_IndYComDebe.Value - Ctasctes_IndYComMonto_Original.Value;
        //        Detalle_Deuda_IndYCom.Post;
        //      end;
        //      if QDeudas_OtrasCod_Cate_Deuda.Value=1 then
        //      begin
        //        if QDeudas_OtrasPeriodo.Value > Data_IndYCom.IndYComPer_Ult.Value then
        //        begin
        //          Data_IndYCom.IndYCom.Edit;
        //        Data_IndYCom.IndYComPer_Ult.Value:=QDeudas_OtrasPeriodo.Value;
        //          Data_IndYCom.IndYCom.Post;
        //        end;
        //      end;
        //      QDeudas_Otras.Cancel;
        //      Data_IndYCom.Siimva.Commit;
        //      Autoriza.Free;
        //    except
        //      Data_IndYCom.Siimva.Rollback;
        //        Application.MessageBox('Revise los datos.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Autoriza.Free;
        //      Exit;
        //    end;
        //    QDeudas_Otras.Close;
        //    QDeudas_Otras.Open;
        //    QDeudas_Otras.Last;
        //    Combo_Cate.Enabled:=False;
        //  end;

        //  if operacion='Modifica' then
        //  begin
        //    if QDeudas_OtrasMonto_Original.Value <=0 then
        //    begin
        //      Application.MessageBox('Monto Original Incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Monto_Original.SetFocus;
        //      Exit;
        //    end;
        //    if QDeudas_OtrasDebe.Value <=0 then
        //    begin
        //      Application.MessageBox('Debe Incorrecto.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Debe.SetFocus;
        //      Exit;
        //    end;
        //    if QDeudas_OtrasDebe.Value<QDeudas_OtrasMonto_Original.Value then
        //    begin
        //      Application.MessageBox('El Monto Original debe ser menor o igual que lo que se debe.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Monto_Original.SetFocus;
        //      Exit;
        //    end;
        //    Ctasctes_IndYCom.FindKey([1, QDeudas_OtrasNro_Transaccion.Value]);
        //    Application.CreateForm(TAutoriza, Autoriza);
        //    Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='MODIFICACION DEUDA INDYCOM';
        //    if Autoriza.ShowModal<> mrOk then
        //    begin
        //      Autoriza.Free;
        //      Exit;
        //    end;
        //    try
        //      Data_IndYCom.Siimva.StartTransaction;
        //      Data_IndyCom.Auditor_V2.ParamByName('@usuario').Value:=PriIyC.usuario;
        //      Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value:=
        //        Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //      Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value:=
        //        Data_IndYCom.IndYComLegajo.AsString;
        //      Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value:=
        //        Autoriza.Memo1.Lines.Text;
        //      Data_IndyCom.Auditor_V2.ParamByName('@proceso').Value:='MODIFICACION DEUDA INDYCOM';
        //      Data_IndyCom.Auditor_V2.ParamByName('@detalle').Value:=
        //        'Periodo: ' + QDeudas_OtrasPeriodo.Value +
        //        ' Monto original antes: ' + FloatToStr(Ctasctes_indycomMonto_original.Value) +
        //        ' Monto original despues: '+ FloatToStr(QDeudas_OtrasMonto_original.Value) +
        //        ' Deuda Antes: ' + FloatToStr(Ctasctes_IndYComDebe.Value) +
        //        ' Deuda Después: ' + FloatToStr(QDeudas_OtrasDebe.Value);
        //        Data_IndyCom.Auditor_V2.ExecProc;
        //      Ctasctes_IndYCom.Edit;
        //      Ctasctes_IndYComMonto_Original.Value:=
        //        QDeudas_OtrasMonto_Original.Value;
        //      Ctasctes_IndYComDebe.Value:=
        //        QDeudas_OtrasDebe.Value;
        //      Ctasctes_IndYCom.Post;
        //      QDetalle_Deuda_IndYCom.ParamByName('nro_transaccion').Value:=
        //        QDeudas_OtrasNro_Transaccion.Value;
        //      QDetalle_Deuda_IndYCom.Open;
        //      QDetalle_Deuda_IndYCom.First;
        //      while not QDetalle_Deuda_IndYCom.Eof do
        //      begin
        //        Detalle_Deuda_IndYCom.
        //          FindKey([QDetalle_Deuda_IndYComNro_Transaccion.Value,
        //                   QDetalle_Deuda_IndYComNro_Item.Value]);
        //        Detalle_Deuda_IndYCom.Delete;
        //        QDetalle_Deuda_IndYCom.Next;
        //      end;
        //      QDetalle_Deuda_IndYCom.Close;

        //      //Grabo primer concepto: Tasa Básica
        //      Detalle_Deuda_IndYCom.Append;
        //      Detalle_Deuda_IndYComNro_Transaccion.Value:=
        //        Ctasctes_IndYComNro_Transaccion.Value;
        //      Detalle_Deuda_IndYComNro_Item.Value:=1;
        //      Detalle_Deuda_IndYComFecha_Item.Value:=
        //        Ctasctes_IndYComFecha_Transaccion.Value;
        //      Detalle_Deuda_IndYComCod_Concepto_IYC.Value:=1;
        //      Detalle_Deuda_IndYComSuma_Item.Value:=True;
        //      Detalle_Deuda_IndYComImporte_Item.Value:=
        //        Ctasctes_IndYComMonto_Original.Value;
        //      Detalle_Deuda_IndYComActivo_Item.Value:=True;
        //      Detalle_Deuda_IndYComImporte_Actual.Value:=
        //        Ctasctes_IndYComMonto_Original.Value;
        //      Detalle_Deuda_IndYCom.Post;
        //      //Grabo segundo concepto si corresponde: Interés
        //      if QDeudas_OtrasMonto_Original.Value<>
        //        QDeudas_OtrasDebe.Value then
        //      begin
        //        Detalle_Deuda_IndYCom.Append;
        //        Detalle_Deuda_IndYComNro_Transaccion.Value:=
        //          Ctasctes_IndYComNro_Transaccion.Value;
        //        Detalle_Deuda_IndYComNro_Item.Value:=2;
        //        Detalle_Deuda_IndYComFecha_Item.Value:=
        //          Ctasctes_IndYComFecha_Transaccion.Value;
        //        Detalle_Deuda_IndYComCod_Concepto_IYC.Value:=2;
        //        Detalle_Deuda_IndYComSuma_Item.Value:=True;
        //        Detalle_Deuda_IndYComImporte_Item.Value:=
        //          Ctasctes_IndYComDebe.Value -
        //          Ctasctes_IndYComMonto_Original.Value;
        //        Detalle_Deuda_IndYComActivo_Item.Value:=True;
        //        Detalle_Deuda_IndYComImporte_Actual.Value:=
        //          Ctasctes_IndYComDebe.Value -
        //          Ctasctes_IndYComMonto_Original.Value;
        //        Detalle_Deuda_IndYCom.Post;
        //      end;
        //      QDeudas_Otras.Cancel;
        //      Data_IndYCom.Siimva.Commit;
        //      Autoriza.Free;
        //    except
        //      Data_IndYCom.Siimva.Rollback;
        //        Application.MessageBox('Revise los datos.','SIIMVA-Error',MB_ICONERROR + MB_OK);
        //      Autoriza.Free;
        //      Exit;
        //    end;
        //    QDeudas_Otras.Close;
        //    QDeudas_Otras.Open;
        //  end;

        //  if operacion='Elimina' then
        //  begin
        //    Application.CreateForm(TAutoriza, Autoriza);
        //    Autoriza.Autoriza_Procesos.ParamByName('proceso').Value:='ELIMINA DEUDA INDYCOM';
        //    if Autoriza.ShowModal<> mrOk then
        //    begin
        //      Autoriza.Free;
        //      Exit;
        //    end;
        //    try
        //      Data_IndYCom.Siimva.StartTransaction;
        //      Data_IndyCom.Auditor_V2.ParamByName('@usuario').Value:=PriIyC.usuario;
        //      Data_IndyCom.Auditor_V2.ParamByName('@autorizacion').Value:=
        //        Autoriza.ComboBox1.Items[Autoriza.ComboBox1.ItemIndex];
        //      Data_IndyCom.Auditor_V2.ParamByName('@identificacion').Value:=
        //        Data_IndYCom.IndYComLegajo.AsString;
        //      Data_IndyCom.Auditor_V2.ParamByName('@observaciones').Value:=
        //        Autoriza.Memo1.Lines.Text;
        //      Data_IndyCom.Auditor_V2.ParamByName('@proceso').Value:='ELIMINA DEUDA INDYCOM';
        //      Data_IndyCom.Auditor_V2.ParamByName('@detalle').Value:=
        //        'Periodo: ' + QDeudas_OtrasPeriodo.Value +
        //        ' Monto original: ' + FloatToStr(QDeudas_otrasMonto_original.Value) +
        //        ' Deuda: ' + FloatToStr(QDeudas_OtrasDebe.Value);
        //        Data_IndyCom.Auditor_V2.ExecProc;
        //      Ctasctes_IndYCom.FindKey([1, QDeudas_OtrasNro_Transaccion.Value]);
        //      Ctasctes_IndYCom.Delete;
        //      Data_IndYCom.Siimva.Commit;
        //      Autoriza.Free;
        //    except
        //      Application.MessageBox('Revise los datos.','SIIMVA-Error', MB_ICONERROR + MB_OK);
        //        Autoriza.Free;
        //      Exit;
        //    end;
        //    QDeudas_Otras.Close;
        //    QDeudas_Otras.Open;
        //  end;
        //  Combo_Cate.Enabled:=False;
        //  Periodo.Enabled:=False;
        //  Vencimiento.Enabled:=False;
        //  Monto_Original.Enabled:=False;
        //  Debe.Enabled:=False;
        //  Confirma.Enabled:=False;
        //  Cancela.Enabled:=False;
        //  Activa_Desactiva_Controles(Panel_Operaciones);
        //        Navegador.Enabled:=True;
        //  Legajo.Enabled:=False;
        //  Panel_Titulo.Caption:='Esperando Operación...';
        //end;

        //procedure TGestFact.cancelaClick(Sender: TObject);
        //        begin
        //  if (QDeudas_Otras.State=dsEdit) or
        //    (QDeudas_Otras.State= dsInsert) then
        //    QDeudas_Otras.Cancel;
        //        Combo_Cate.Enabled:=False;
        //  Periodo.Enabled:=False;
        //  Vencimiento.Enabled:=False;
        //  Monto_Original.Enabled:=False;
        //  Debe.Enabled:=False;
        //  Confirma.Enabled:=False;
        //  Cancela.Enabled:=False;
        //  Activa_Desactiva_Controles(Panel_Operaciones);
        //        Legajo.Enabled:=False;
        //  Navegador.Enabled:=True;
        //  Panel_Titulo.Caption:='Esperando Operación...';
        //end;





    }
}



