using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;
using Web_Api_IyC.Entities.HELPERS;
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
        public IActionResult Insert(Entities.INDYCOM obj)
        {
            _iindycomService.Insert(obj);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult Update(Entities.INDYCOM obj)
        {
            _iindycomService.Update(obj);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
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
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult UpdateDatosDomPostal(Entities.INDYCOM obj)
        {
            _iindycomService.UpdateDatosDomPostal(obj);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult SaveDatosAfip(Entities.INDYCOM obj)
        {
            _iindycomService.SaveDatosAfip(obj);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        [HttpPost]
        public IActionResult SaveDatosLiquidacion(Entities.INDYCOM obj)
        {
            _iindycomService.SaveDatosLiquidacion(obj);
            var indycom = _iindycomService.Read();
            return Ok(indycom);
        }
        //
        [HttpGet]
        public async Task<ActionResult<PaginadorGenerico<Entities.INDYCOM>>> GetIndycomPaginado(
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
            _TotalRegistros = await _iindycomService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Dominio,
            //Titular
            //Cuit
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Indycom = await _iindycomService.GetIndycomPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Indycom = await _iindycomService.GetIndycomPaginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
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
        private async Task<ActionResult<PaginadorGenerico<Entities.INDYCOM>>> PaginacionConParamRequestForm()
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
            _TotalRegistros = await _iindycomService.Count();
            // Número total de páginas de la tabla Vehiculo
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);
            //Filtramos el resultado por el 'texto de búqueda'
            //Los Tipos de Busqueda son
            //Dominio,
            //Titular
            //Cuit
            if (!string.IsNullOrEmpty(buscarPor) && buscarPor != "0" && strParametro != "0")
            {
                _Indycom = await _iindycomService.GetIndycomPaginado(buscarPor, strParametro, 0, _TotalRegistros);
            }
            else
                _Indycom = await _iindycomService.GetIndycomPaginado(buscarPor, strParametro, (pagina * registros_por_pagina) - registros_por_pagina + 1,
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
        public ActionResult BajaComercial(int legajo, string fecha_baja, Auditoria obj)
        {
            _iindycomService.BajaComercial(legajo, fecha_baja, obj);
            var indycom = _iindycomService.GetByPk(legajo);
            if (indycom.fecha_baja == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja!" });
            }
            return Ok(indycom);
        }

        [HttpPost]
        public ActionResult BajaSucursal(int legajo, int nro_sucursal, string fecha_baja, Auditoria obj)
        {
            _iindycomService.BajaSucursal(legajo, nro_sucursal, fecha_baja, obj);
            var indycom = _iindycomService.GetByPk(legajo);
            if (indycom.fecha_baja == null)
            {
                return BadRequest(new { message = "No se pudo dar de Baja la Sucursal!" });
            }
            return Ok(indycom);
        }

    }
}
