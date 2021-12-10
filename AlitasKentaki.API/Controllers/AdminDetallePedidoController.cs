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
    [Route("api/admindetallepedido")]
    [ApiController]
    public class AdminDetallePedidoController : Controller
    {
        protected readonly IAdminDetallePedidoRepository _adminDetallePedidoRepository;

        public AdminDetallePedidoController(IAdminDetallePedidoRepository adminDetallePedidoRepository)
        {
            _adminDetallePedidoRepository = adminDetallePedidoRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerpedidoporusuariopedido")]
        public ActionResult obtenerDetallePedidoPorPedido(int idpedido)
        {
            var ret = _adminDetallePedidoRepository.obtenerDetallePedidoPorPedido(idpedido);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);

        }
    }
}
