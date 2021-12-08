using AlitasKentaki.API.Security;
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
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        protected readonly IUserRepository _UserRepository;
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntityLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.data != null)
            {
                var responseLogin = ret.data as EntityLoginResponse;
                var usercod = responseLogin.idusuario.ToString();
                var userdoc = responseLogin.documentoidentidad;

                var token = JsonConvert.DeserializeObject<AccessToken>(
                    await new Authentication().GenerateToken(userdoc, usercod)
                    ).access_token;

                responseLogin.token = token;
                ret.data = responseLogin;
            }
            return Json(ret);
        }
    }
}
