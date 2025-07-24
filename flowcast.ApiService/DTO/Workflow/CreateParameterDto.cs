using flowcast.Domain.Entities;

namespace flowcast.ApiService.DTO.Workflow
{
    public class CreateParameterDto
    {
        public string Name { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public ParameterType Type { get; set; }
    }
}
