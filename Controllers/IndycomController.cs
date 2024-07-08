﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Entities.IYC;
using Web_Api_IyC.Helpers;
using Web_Api_IyC.Services;


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
    }
}
