using flowcast.ApiService.DTO.Workflow;
using flowcast.Application.Engine;
using flowcast.Application.Repository;
using flowcast.Domain.Entities;
using flowcast.Domain.Interfaces;
using flowcast.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace flowcast.ApiService.Controllers
{
    /// <summary>
    /// Contrôleur API pour la gestion des workflows.
    /// Permet la création, la récupération et l'exécution des workflows.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController(WorkflowRepository workflowRepository, WorkflowEngine workflowEngine) : ControllerBase
    {
        private readonly WorkflowRepository _workflowRepository = workflowRepository;
        private readonly WorkflowEngine _workflowEngine = workflowEngine;


        /// <summary>
        /// Crée un nouveau workflow à partir des données fournies.
        /// </summary>
        /// <param name="dto">DTO contenant les informations nécessaires à la création du workflow.</param>
        /// <returns>Retourne le workflow créé avec un code HTTP 201.</returns>
        [HttpPost]
        
        public async Task<ActionResult> CreateWorkflowAsync([FromBody] CreateWorkflowDTO dto)
        {
            var workflow = new Workflow
            {
                Name = dto.Name,
                CreatorId = dto.CreatorId,
                ParameterDefinitions = dto.ParameterDefinitions.Select(p => new WorkflowParameterDefinition
                {
                    Name = p.Name,
                    DisplayName = p.DisplayName,
                    Type = p.Type,
                    
                }).ToList(),
                Steps = dto.Steps.Select(s => new WorkflowStep
                {
                    StepName = s.StepName,
                    Order = s.Order,
                    Rules = s.Rules.Select(r => new Rule
                    {
                        Key = r.Key,
                        Value = r.Value
                    }).ToList()
                }).ToList()
            };

            var createdWorkflow = await _workflowRepository.AddWorkflowAsync(workflow);

            return CreatedAtAction(nameof(GetWorkflow), new { id = createdWorkflow.Id }, createdWorkflow);

        }

        /// <summary>
        /// Récupère tous les workflows avec leurs étapes, règles et paramètres.
        /// </summary>
        /// <returns>Liste complète des workflows.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Workflow>>> GetAllWorkflows()
        {
            var workflows = await _workflowRepository.GetAllWorkflowsDetailedAsync();

            return Ok(workflows);
        }


        /// <summary>
        /// Récupère un workflow par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant unique du workflow.</param>
        /// <returns>Le workflow correspondant ou une réponse 404 si non trouvé.</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetWorkflow(int id)
        {
            var workflow = await _workflowRepository.GetWorkflowByIdAsync(id);
            if (workflow == null)
                return NotFound();
            return Ok(workflow);
        }

        /// <summary>
        /// Exécute un workflow existant avec les paramètres fournis.
        /// </summary>
        /// <param name="workflowId">Identifiant du workflow à exécuter.</param>
        /// <param name="parameters">Dictionnaire de paramètres nécessaires à l'exécution du workflow.</param>
        /// <returns>Résultat de l'exécution ou une réponse d'erreur en cas d'échec.</returns>
        [HttpPost("execute/{workflowId}")]
        public async Task<IActionResult> ExecuteWorkflowAsync(int workflowId, [FromBody] Dictionary<string, string> parameters)
        {
            var result = await _workflowEngine.ExecuteWorkflowAsync(workflowId, parameters);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Récupére tous les modules
        /// </summary>
        /// <returns>Liste complète des modules.</returns>
        [HttpGet("modules")]
        public async Task<ActionResult<List<Workflow>>> GetAllModulesAsync()
        {
            var modules = await _workflowRepository.GetAllModules();

            return Ok(modules);
        }

    }
}
