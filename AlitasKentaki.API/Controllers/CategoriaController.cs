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
    [Route("api/categoria")]
    public class CategoriaController : Controller
    {
        protected readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenercategorias")]
        public ActionResult ObtenerCategorias()
        {
            var ret = _categoriaRepository.ObtenerCategorias();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
