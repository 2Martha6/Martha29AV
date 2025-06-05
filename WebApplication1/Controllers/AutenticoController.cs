using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.DTO;
using Majo29AV.Context;
using Microsoft.EntityFrameworkCore;
using Majo29AV.Services.Iservices;
using Martha29AV.Services.Helper;
using Microsoft.AspNetCore.Identity.Data;


namespace Martha29AV.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticoController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IConfiguration _config;

        public AutenticoController(IUsuarioServices usuarioServices, IConfiguration config)
        {
            _usuarioServices = usuarioServices;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _usuarioServices.ValidarUsuario(request.Correo, request.Password);
            if (usuario == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            var token = JwtHelper.GenerateToken(usuario, _config);
            return Ok(new { token });
        }
    }
}
