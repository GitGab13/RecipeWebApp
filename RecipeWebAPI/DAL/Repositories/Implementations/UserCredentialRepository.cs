using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class UserCredentialRepository : IUserCredentialRepository
    {
        public Task<bool> AddAsync(UserCredential entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCredential>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserCredential> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserCredential> GetByUsernamePasswordAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UserCredential entity)
        {
            throw new NotImplementedException();
        }
    }
}
