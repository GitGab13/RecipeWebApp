using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<bool> AddAsync(User entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(User entity);

    }
}
