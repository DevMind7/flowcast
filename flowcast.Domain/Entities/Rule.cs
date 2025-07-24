using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class Rule
    {
        public int Id { get; init; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;

        public int WorkflowStepId { get; set; }

        [JsonIgnore]
        public WorkflowStep WorkflowStep { get; set; } = default!;

    }
}
