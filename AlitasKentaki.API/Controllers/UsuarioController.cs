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
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        protected readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerusuarioporcodigo")]
        public ActionResult obtenerUsuarioPorCodigo(int idusuario)
        {
            var ret = _usuarioRepository.obtenerUsuarioPorCodigo(idusuario);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
