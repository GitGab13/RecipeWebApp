using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserCredentialRepository
    {
        Task<IEnumerable<UserCredential>> GetAllAsync();

        Task<UserCredential> GetByIDAsync(int id);

        Task<bool> AddAsync(UserCredential entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(UserCredential entity);

        Task<UserCredential> GetByUsernamePasswordAsync(string username, string password);

    }
}
