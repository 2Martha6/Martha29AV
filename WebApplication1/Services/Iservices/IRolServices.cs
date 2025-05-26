using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Majo29AV.Services.Iservices
{
    public interface IRolServices
    {
        Task<Response<List<Rol>>> GetAllRoles();
        Task<Response<Rol>> GetRolById(int id);
        Task<Response<Rol>> CreateRol(RolRequest rolRequest);
        Task<Response<Rol>> UpdateRol(RolRequest rolRequest, int id);
        Task<Response<Rol>> DeleteRol(int id);
    }
}