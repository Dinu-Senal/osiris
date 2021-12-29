using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Osiris.Data.Services
{
    public class UserService
    {
        #region Property
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constructor
        public UserService(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }
        #endregion

        #region Get All Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _applicationDbContext.User.ToListAsync();
        }
        #endregion

        #region Add User
        public async Task<bool> AddUserAsync(User user)
        {
            await _applicationDbContext.User.AddAsync(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get User by Id
        public async Task<User> GetUserAsync(String Id)
        {
            User user = await _applicationDbContext.User.FirstOrDefaultAsync(data => data.UserId.ToString() == Id);
            return user;
        }
        #endregion

        #region Update User
        public async Task<bool> UpdateUserAsync(User user)
        {
            _applicationDbContext.User.Update(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete User
        public async Task<bool> DeleteUserAsync(User user)
        {
            _applicationDbContext.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
