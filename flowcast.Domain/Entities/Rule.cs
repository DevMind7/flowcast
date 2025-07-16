using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class Rule
    {
        public int Id { get; init; }
        public string Key { get; set; } = null!; // ex: "minJours"
        public string Value { get; set; } = null!; // ex: "2"

        public int WorkflowStepId { get; set; }
        public WorkflowStep WorkflowStep { get; set; } = default!;

    }
}
