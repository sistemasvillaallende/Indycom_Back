using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Services;
namespace Web_Api_IyC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BadecController : Controller
    {
        private IBadecServices _badecService;
        public BadecController(IBadecServices badecService)
        {
            _badecService = badecService;
        }
      
        //[HttpPost]
        //public IActionResult insert(Entities.BADEC obj)
        //{
        //    _badecService.insert(obj);
        //    var badec = _badecService.read2();

        //    return Ok(badec);
        //}
        //[HttpPost]
        //public IActionResult update(Entities.BADEC obj)
        //{
        //    _badecService.update(obj);
        //    var badec = _badecService.read2();

        //    return Ok(badec);
        //}
        //[HttpPost]
        //public IActionResult update2(Entities.BADEC obj)
        //{
        //    _badecService.update2(obj);
        //    var badec = _badecService.read2();

        //    return Ok(badec);
        //}

        //[HttpPost]
        //public IActionResult delete(Entities.BADEC obj)
        //{
        //    _badecService.delete(obj.nro_bad);
        //    var badec = _badecService.read2();

        //    return Ok(badec);
        //}
        //[HttpGet]
        //public IActionResult read()
        //{
        //    var badec = _badecService.read();

        //    return Ok(badec);
        //}
        //[HttpGet]
        //public IActionResult read2()
        //{
        //    var badec = _badecService.read2();

        //    return Ok(badec);
        //}
        //[HttpGet]
        //public IActionResult getByPk(int nro_bad)
        //{
        //    var badec = _badecService.getByPk(nro_bad);

        //    return Ok(badec);
        //}

        //[HttpGet]
        //public IActionResult getByPk2(int nro_bad)
        //{
        //    var badec = _badecService.getByPk2(nro_bad);

        //    return Ok(badec);
        //}

        //[HttpGet]
        //public IActionResult GetByNombre(string nombre)
        //{
        //    var badec = _badecService.GetByNombre(nombre);

        //    return Ok(badec);
        //}


    }
}
