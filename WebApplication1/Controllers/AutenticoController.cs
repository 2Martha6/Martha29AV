using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.DTO;
using Majo29AV.Context;
using Microsoft.EntityFrameworkCore;


namespace Martha29AV.Controllers

{
    [ApiController]
    [Route("Login/[controller]")]
    public class AutenticoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AutenticoController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioRequest request)
        {
            var usuario = _context.Usuarios.Include(u => u.Roles)  
                .FirstOrDefault(u =>u.UserName == request.UserName && u.Password == request.Password);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            var token = GenerateJwtToken(usuario);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario.UserName),
            new Claim("PkUsuario", usuario.PkUsuario.ToString()),
            new Claim("FkRol", usuario.FkRol?.ToString() ?? "0")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
