using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class Workflow
    {
        public int Id { get; init; }
        public string Name { get; set; } = default!;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = default!;
        public List<WorkflowParameterDefinition> ParameterDefinitions { get; set; } = [];
        public List<WorkflowStep> Steps { get; set; } = default!;
    }

    public class WorkflowParameterDefinition
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!; 
        public string DisplayName { get; set; } = default!; 

        public ParameterType Type { get; set; }

        public int WorkflowId { get; set; }
        [JsonIgnore]
        public Workflow Workflow { get; set; } = default!;
    }

    public enum ParameterType
    {
        String,
        Int,
        Date,
        Bool,
        Enum
    }
}
