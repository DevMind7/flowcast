using flowcast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Interfaces
{
    public interface IWorkflowRepository
    {
        Task<Workflow?> GetByIdAsync(int id);
        Task<List<Workflow>> GetAllAsync();
        Task AddAsync(Workflow workflow);
    }
}
