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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _users;
        private readonly ILogger _logger;

        public UserRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _users = context.Set<User>();
        }

        public virtual async Task<bool> AddAsync(User entity)
        {
            try
            {
                await _users.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user");
                throw;
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                User entity = await _users.FindAsync(id);
                if (entity != null)
                {
                    _context.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Error deleting user not found with ID: {Id}", id);
                    return false;
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user with ID: {Id}", id);
                throw;

            }
        }

        public virtual async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _users.ToListAsync<User>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all user");
                throw;
            }
        }

        public virtual async Task<User> GetByIdAsync(int id)
        {
            try
            {
                User user = await _users.FindAsync(id);
                if(user != null)
                {
                    return user;
                }
                else
                {
                    _logger.LogWarning("User ID does not exists ID: {Id}",id);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with ID: {Id}", id);
                throw;
            }
        }

        public virtual async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                User originalUser = await _users.FindAsync(entity.Id);
                if (originalUser != null)
                {
                    originalUser.FirstName = entity.FirstName;
                    originalUser.LastName = entity.LastName;
                    _context.Update(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Error updating user not found with ID: {Id}", entity.Id);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with ID: {Id}", entity.Id);
                throw;
            }
        }
    }
}
