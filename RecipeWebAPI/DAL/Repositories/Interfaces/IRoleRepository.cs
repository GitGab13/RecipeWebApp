using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();

        Task<Role> GetByIDAsync(int id);

        Task<bool> AddAsync(Role entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(Role entity);

    }
}
