namespace flowcast.ApiService.DTO.Workflow
{
    public class ExecuteWorkflow
    {
        public int WorkflowId { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new();
    }
}
