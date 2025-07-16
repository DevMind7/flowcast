using flowcast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Interfaces
{
    public interface IWorkflowInstanceRepository
    {
        Task<WorkflowInstance?> GetByIdAsync(int id);
        Task AddAsync(WorkflowInstance instance);
    }
}
