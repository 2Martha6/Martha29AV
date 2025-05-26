using Domain.DTO;
using Domain.Entities;
using Majo29AV.Context;
using Majo29AV.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace Majo29AV.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Rol>>> GetAllRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return new Response<List<Rol>>(roles, "Lista de roles obtenida exitosamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los roles: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> GetRolById(int id)
        {
            try
            {
                var rol = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);
                return new Response<Rol>(rol, "Rol encontrado correctamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el rol: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> CreateRol(RolRequest request)
        {
            try
            {
                var newRol = new Rol
                {
                    Nombre = request.Nombre
                };

                _context.Roles.Add(newRol);
                await _context.SaveChangesAsync();

                return new Response<Rol>(newRol, "Rol creado exitosamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el rol: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> DeleteRol(int id)
        {
            try
            {
                var rolToDelete = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);

                if (rolToDelete == null)
                    throw new Exception("Rol no encontrado.");

                _context.Roles.Remove(rolToDelete);
                await _context.SaveChangesAsync();

                return new Response<Rol>(rolToDelete, "Rol eliminado correctamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol: " + ex.Message);
            }
        }

        public async Task<Response<Rol>> UpdateRol(RolRequest request, int id)
        {
            try
            {
                var rolToUpdate = await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);

                if (rolToUpdate == null)
                    throw new Exception("Rol no encontrado.");

                rolToUpdate.Nombre = request.Nombre;

                await _context.SaveChangesAsync();

                return new Response<Rol>(rolToUpdate, "Rol actualizado correctamente.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el rol: " + ex.Message);
            }
        }
    }
}