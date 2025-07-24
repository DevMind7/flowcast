using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Interfaces
{
    public interface IRuleRepository
    {
        Task<List<Rule>> GetByStepIdAsync(int stepId);
        Task AddAsync(Rule rule);
    }
}
