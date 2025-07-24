using flowcast.Domain.Entities;
using flowcast.Domain.Interfaces;
using flowcast.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Application.Services
{
    public class UserRepository(FlowcastDbContext context) : IUserRepository
    {

        private readonly FlowcastDbContext _context = context;

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
