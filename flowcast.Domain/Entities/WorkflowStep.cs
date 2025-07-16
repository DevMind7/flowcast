using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class WorkflowStep
    {
        public int Id { get; init; }
        public string StepName { get; set; } = default!;
        public int Order { get; set; }

        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; } = default!;

        public List<Rule> Rules { get; set; } = default!;
    }
}
