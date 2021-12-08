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
    [Route("api/carrito")]
    [ApiController]
    public class CarritoController : Controller
    {
        protected readonly ICarritoRepository _carritoRepository;
        public CarritoController(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;

        }

        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("obtenercarritoporusuario")]
        public ActionResult ObtenerCarritoPorUsuario()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var usercod = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            var ret = _carritoRepository.ObtenerCarritoPorUsuario(int.Parse(usercod));

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("obtenermontocarritoporusuario")]
        public ActionResult ObtenerMontoCarritoPorUsuario()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var usercod = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdoc = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            var ret = _carritoRepository.ObtenerMontoCarritoPorUsuario(int.Parse(usercod));

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
        [Produces("application/json")]
        [Authorize]
        [HttpGet]
        [Route("agregarproducto")]
        public ActionResult AgregarProductoCarrito(EntityProductoCarrito entityProductoCarrito)
        {
            var ret = _carritoRepository.AgregarProductoCarrito(entityProductoCarrito);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
