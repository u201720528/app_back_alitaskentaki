using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlitasKentaki.API.Controllers
{
    [Produces("application/json")]
    [Route("api/adminpedido")]
    [ApiController]
    public class AdminPedidoController : Controller
    {
        protected readonly IAdminPedidoRepository _adminPedidoRepository;

        public AdminPedidoController(IAdminPedidoRepository adminPedidoRepository)
        {
            _adminPedidoRepository = adminPedidoRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obteneradminpedidos")]
        public ActionResult obtenerAdminPedidos()
        {
            var ret = _adminPedidoRepository.ObtenerAdminPedidos();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obteneradminpedidoporusuarioypedido")]
        public ActionResult ObtenerAdminPedidoPorUsuarioYPedido(int idusuario, int idpedido)
        {
            var ret = _adminPedidoRepository.ObtenerAdminPedidoPorUsuarioYPedido(idusuario, idpedido);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

    }
}
