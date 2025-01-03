using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Role> _roles;
        private readonly ILogger _logger;

        public RoleRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _roles = context.Set<Role>();
        }

        public virtual async Task<bool> AddAsync(Role entity)
        {
            try
            {
                await _roles.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding role");
                throw;
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Role entity = await _roles.FindAsync(id);
                if (entity != null)
                {
                    _context.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Error deleting role not found with ID: {Id}", id);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting role with ID: {Id}", id);
                throw;
            }
            
        }

        public virtual async Task<IEnumerable<Role>> GetAllAsync()
        {
            try
            {
                return await _roles.ToListAsync<Role>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all role");
                throw;
            }
        }

        public virtual async Task<Role> GetByIDAsync(int id)
        {
            try {
                Role entity = await _roles.FindAsync(id);
                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    _logger.LogWarning("Role does not exist with ID: {Id}", id);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting role with ID: {Id}", id);
                throw;
            }
        }

        public virtual async Task<bool> UpdateAsync(Role entity)
        {
            try
            {
                Role originalRole = await _roles.FindAsync(entity.RoleID);
                if (originalRole != null)
                {
                    originalRole.RoleName = entity.RoleName;
                    originalRole.RoleDescription = entity.RoleDescription;
                    _context.Update(originalRole);

                    return true;
                }
                else
                {
                    _logger.LogWarning("Error updating role not found with ID: {Id}", entity.RoleID);
                    return false;            
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating role with ID: {Id}", entity.RoleID);
                throw;
            }
        }
    }
}
