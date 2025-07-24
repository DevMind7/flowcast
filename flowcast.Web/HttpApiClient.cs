using flowcast.ApiService.DTO.Workflow;
using flowcast.Web.DTO.Workflow;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace flowcast.Web
{
    public class HttpApiClient(HttpClient httpClient)
    {
        public async Task<HttpResponseMessage> CreateWorkflowAsync(CreateWorkflowDTO newWorkflow)
        {
            return await httpClient.PostAsJsonAsync("api/Workflow", newWorkflow);
        }


        public async Task<WorkflowResult> ExecuteWorkflowAsync(int workflowId, Dictionary<string, string> parameters)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/Workflow/execute/{workflowId}", parameters);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    return new WorkflowResult { Success = false, Message = errorMsg };
                }

                // Désérialiser la réponse JSON du serveur
                var workflowExecutionResult = await response.Content.ReadFromJsonAsync<WorkflowExecutionResult>();

                if (workflowExecutionResult == null)
                {
                    return new WorkflowResult { Success = false, Message = "Réponse invalide du serveur" };
                }

                // Mapper WorkflowExecutionResult vers WorkflowResult
                return new WorkflowResult
                {
                    Success = workflowExecutionResult.Success,
                    Message = workflowExecutionResult.Message ?? "",
                    StepResults = workflowExecutionResult.StepResults?.Select(sr => new StepResult
                    {
                        StepName = sr.StepName,
                        RuleKey = sr.RuleKey,
                        Success = sr.Success,
                        Message = sr.Message
                    }).ToList() ?? new List<StepResult>()
                };
            }
            catch (Exception ex)
            {
                return new WorkflowResult { Success = false, Message = $"Erreur de communication : {ex.Message}" };
            }
        }

        public async Task<List<Workflow>> GetAllWorkflowsAsync()
        {
            var response = await httpClient.GetAsync("api/Workflow");
            if (!response.IsSuccessStatusCode)
                return new List<Workflow>();

            var workflows = await response.Content.ReadFromJsonAsync<List<Workflow>>();
            return workflows ?? new List<Workflow>();
        }

        public async Task<CreateWorkflowDTO?> GetWorkflowAsync(int workflowId)
        {
            var response = await httpClient.GetAsync($"api/Workflow/{workflowId}");
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<CreateWorkflowDTO>();
        }

        public async Task<List<ModuleDto>> GetAllModulesAsync()
        {
            var response = await httpClient.GetAsync("api/Workflow/modules");
            if (!response.IsSuccessStatusCode)
                return new List<ModuleDto>();

            var modules = await response.Content.ReadFromJsonAsync<List<ModuleDto>>();
            return modules ?? new List<ModuleDto>();
        }

        public class WorkflowResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public List<StepResult> StepResults { get; set; } = new();

        }

        public class WorkflowExecutionResult
        {
            public bool Success { get; set; }
            public string? Message { get; set; }
            public List<StepResult> StepResults { get; set; } = new();
        }

        public class StepResult
        {
            public string StepName { get; set; } = "";
            public string RuleKey { get; set; } = "";
            public bool Success { get; set; }
            public string Message { get; set; } = "";
        }

        public class Workflow
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public int CreatorId { get; set; }

            public List<WorkflowParameterDefinition> ParameterDefinitions { get; set; } = new();
            public List<WorkflowStep> Steps { get; set; } = new();
        }

        public class WorkflowParameterDefinition
        {
            public string Name { get; set; } = "";
            public string DisplayName { get; set; } = "";
            public ParameterType Type { get; set; } = default;
        }

        public class WorkflowStep
        {
            public string StepName { get; set; } = "";
            public int Order { get; set; }
            public List<Rule> Rules { get; set; } = new();
        }

        public class Rule
        {
            public string Key { get; set; } = "";
            public string Value { get; set; } = "";
        }


        public enum ParameterType
        {
            Text = 0,
            Number = 1,
            Date = 2,
            // ...
        }
    }
}
