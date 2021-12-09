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
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : Controller
    {
        protected readonly IProductoRepository _categoriaRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
            _categoriaRepository = productoRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerproductosporcategoria")]
        public ActionResult ObtenerProductosPorCategoria(int idCategoria)
        {
            var ret = _categoriaRepository.ObtenerProductosPorCategoria(idCategoria);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}
