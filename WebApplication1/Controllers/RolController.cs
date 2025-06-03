using Domain.DTO;
using Domain.Entities;
using Majo29AV.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("ROL/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolService;

        public RolController(IRolServices rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var rolesResponse = await _rolService.GetAllRoles();
            return Ok(rolesResponse);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetRolById(int id)
        {
            var rolResponse = await _rolService.GetRolById(id);
            return Ok(rolResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRol(RolRequest rolRequest)
        {
            var createResponse = await _rolService.CreateRol(rolRequest);
            return Ok(createResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var deleteResponse = await _rolService.DeleteRol(id);
            return Ok(deleteResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRol(RolRequest rolRequest, int id)
        {
            var updateResponse = await _rolService.UpdateRol(rolRequest, id);
            return Ok(updateResponse);
        }
    }
}
