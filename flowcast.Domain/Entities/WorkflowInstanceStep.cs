using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class WorkflowInstanceStep
    {
        public int Id { get; set; }

        public int WorkflowStepId { get; set; }
        public WorkflowStep WorkflowStep { get; set; } = default!;

        public int WorkflowInstanceId { get; set; }
        public WorkflowInstance WorkflowInstance { get; set; } = default!;

        public string Status { get; set; } = "Pending";
    }
}
