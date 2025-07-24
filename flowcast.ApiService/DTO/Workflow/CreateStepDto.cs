namespace flowcast.ApiService.DTO.Workflow
{
    public class CreateStepDto
    {
        public string StepName { get; set; } = default!;
        public int Order { get; set; }
        public List<CreateRuleDto> Rules { get; set; } = [];
    }
}
