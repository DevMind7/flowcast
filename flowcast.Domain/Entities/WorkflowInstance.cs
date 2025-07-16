using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class WorkflowInstance
    {
        public int Id { get; set; }

        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; } = default!;

        public int RequestedByUserId { get; set; }
        public User RequestedByUser { get; set; } = default!;

        public List<WorkflowInstanceStep> Steps { get; set; } = new();

    }
}
