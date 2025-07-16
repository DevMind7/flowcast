using flowcast.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Interfaces
{
    public interface IWorkflowInstanceStepRepository
    {
        Task<List<WorkflowInstanceStep>> GetByInstanceIdAsync(int instanceId);
        Task AddAsync(WorkflowInstanceStep step);
        Task UpdateStatusAsync(int stepId, string status);
    }
}
