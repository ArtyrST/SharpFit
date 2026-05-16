using AlaBackEnd.DAL.Repositories;
using DAL.data;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>
        
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        :base (context)
        {
            _context = context;
        }
        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);
                
        }
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
