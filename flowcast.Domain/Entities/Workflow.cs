using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class Workflow
    {
        public int Id { get; init; }
        public string Name { get; set; } = default!;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = default!;
        public List<WorkflowStep> Steps { get; set; } = default!;

    }
}
