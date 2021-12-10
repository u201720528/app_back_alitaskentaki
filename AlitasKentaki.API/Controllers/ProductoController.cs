using DBContext;
using DBEntity;
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
        protected readonly IProductoRepository _productoRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerproductosporcategoria")]
        public ActionResult ObtenerProductosPorCategoria(int idCategoria)
        {
            var ret = _productoRepository.ObtenerProductosPorCategoria(idCategoria);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerproductoporid")]
        public ActionResult ObtenerProductoPorId(int idProducto)
        {
            var ret = _productoRepository.ObtenerProductoPorId(idProducto);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }


        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtenerproductos")]
        public ActionResult ObtenerProductos()
        {
            var ret = _productoRepository.ObtenerProductos();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }


        [HttpPost]
        [Route("insert")]
        public ActionResult Crear(EntityProducto data)
        {
            var ret = _productoRepository.Crear(data);
            return Json(ret);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult Actualizar(int codigo, EntityProducto data)
        {

            var ret = _productoRepository.Actualizar(data);
            return Json(ret);
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult Desactivar(int codigo, int usuariomodifica)
        {
            var ret = _productoRepository.Desactivar(codigo, usuariomodifica);
            return Json(ret);
        }



    }
}
