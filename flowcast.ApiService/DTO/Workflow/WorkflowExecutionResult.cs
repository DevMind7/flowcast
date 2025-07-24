namespace flowcast.ApiService.DTO.Workflow
{
    public class WorkflowExecutionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<StepResult> StepResults { get; set; }
    }

    public class StepResult
    {
        public string StepName { get; set; }
        public string RuleKey { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
