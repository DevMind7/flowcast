namespace flowcast.ApiService.DTO.Workflow
{
    public class CreateWorkflowDTO
    {
        public string Name { get; set; } = default!;
        public int CreatorId { get; set; }
        public List<CreateParameterDto> ParameterDefinitions { get; set; } = [];
        public List<CreateStepDto> Steps { get; set; } = [];
    }
}
