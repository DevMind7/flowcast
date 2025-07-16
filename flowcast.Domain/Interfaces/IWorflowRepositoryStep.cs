using flowcast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Interfaces
{
    public interface IWorflowRepositorystep
    {
        Task<List<WorkflowStep>> GetByWorkflowIdAsync(int workflowId);
        Task AddAsync(WorkflowStep step);
    }
}
