﻿using Domain.DTO;
using Domain.Entities;
using Majo29AV.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Controllers
{
    [ApiController]
    [Route("USUARIO/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetAll();

            return Ok(response);

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var response = await _usuarioServices.GetbyId(id);

            return Ok(response);

        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioRequest request)
        {
            var response = await _usuarioServices.Create(request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuarioServices.Delete(id);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UsuarioRequest request, int id)
        {
            var response = await _usuarioServices.Update(request, id);

            return Ok(response);
        }



    }
}
