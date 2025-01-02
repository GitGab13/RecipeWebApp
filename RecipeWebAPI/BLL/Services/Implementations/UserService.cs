using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(User entity)
        {
            var isSuccess = await _unitOfWork.Users.AddAsync(entity);
            if (isSuccess)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isSuccess = await _unitOfWork.Users.DeleteAsync(id);
            if (isSuccess)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            var isSuccess = await _unitOfWork.Users.UpdateAsync(entity);
            if (isSuccess)
            {
                await _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
