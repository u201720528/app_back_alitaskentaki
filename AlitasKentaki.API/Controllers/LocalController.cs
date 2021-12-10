using DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlitasKentaki.API.Controllers
{
    [Produces("application/json")]
    [Route("api/local")]
    [ApiController]
    public class LocalController : Controller
    {
        protected readonly ILocalRepository _localRepository;
        public LocalController(ILocalRepository localRepository)
        {
            _localRepository = localRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerlocales")]
        public ActionResult ObtenerLocales()
        {
            var ret = _localRepository.ObtenerLocales();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
