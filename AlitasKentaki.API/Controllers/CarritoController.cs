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
    [Route("api/carrito")]
    public class CarritoController : Controller
    {
        protected readonly ICarritoRepository _carritoRepository;
        public CarritoController(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenercarritoporusuario")]
        public ActionResult ObtenerProductosPorCategoria(int idUsuario)
        {
            var ret = _carritoRepository.ObtenerCarritoPorUsuario(idUsuario);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenermontocarritoporusuario")]
        public ActionResult ObtenerMontoCarritoPorUsuario(int idUsuario)
        {
            var ret = _carritoRepository.ObtenerMontoCarritoPorUsuario(idUsuario);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
