using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlitasKentaki.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sugerencia")]
    [ApiController]
    public class SugerenciaController : Controller
    {
        protected readonly ISugerenciaRepository _sugerenciaRepository;
        public SugerenciaController(ISugerenciaRepository sugerenciaRepository)
        {
            _sugerenciaRepository = sugerenciaRepository;

        }

        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("agregarsugerencia")]
        public ActionResult AgregarSugerencia(EntitySugerencia entitySugerencia)
        {
            
            var ret = _sugerenciaRepository.AgregarSugerencia(entitySugerencia);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
