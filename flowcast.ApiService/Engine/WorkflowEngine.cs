using flowcast.ApiService.DTO.Workflow;
using flowcast.Application.Modules.Leave;
using flowcast.Application.Repository;
using flowcast.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Application.Engine
{
    /// <summary>
    /// Moteur d'exécution des workflows.
    /// Responsable de la gestion et de l'exécution des étapes et règles associées aux workflows.
    /// </summary>
    public class WorkflowEngine
    {
        private readonly IReadOnlyDictionary<string, Func<IReadOnlyDictionary<string, string>, Task<WorkflowResult>>> _modules;
        private readonly WorkflowRepository _workflowRepository;

        /// <summary>
        /// Initialise une nouvelle instance du moteur de workflow avec le dépôt de workflows.
        /// </summary>
        /// <param name="workflowRepository">Référentiel d'accès aux workflows.</param>
        public WorkflowEngine(WorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;

            // Mapping logique entre nom du module et la fonction à exécuter
            _modules = new Dictionary<string, Func<IReadOnlyDictionary<string, string>, Task<WorkflowResult>>>
            {
                ["LeaveValidatorParameters"] = LeaveValidatorParameters.Execute,
                ["LeaveMaxDurationValidator"] = LeaveMaxDurationValidator.Execute

            };
        }

        /// <summary>
        /// Lance une validation spécifique des congés sur une période donnée pour un employé.
        /// </summary>
        /// <param name="employeeId">Identifiant de l'employé.</param>
        /// <param name="startDate">Date de début du congé.</param>
        /// <param name="endDate">Date de fin du congé.</param>
        /// <returns>Résultat de la validation du workflow.</returns>
        public async Task<WorkflowResult> RunLeaveValidationAsync(int employeeId, string startDate, string endDate)
        {
            // Appel à un service pour obtenir le solde actuel (depuis BDD ou autre)
            int availableDays = await _workflowRepository.GetLeaveBalanceAsync(employeeId);

            var parameters = new Dictionary<string, string>
            {
                ["startDate"] = startDate,
                ["endDate"] = endDate,
                ["availableDays"] = availableDays.ToString()
            };

            var executor = _modules["LeaveBalance"];
            return await executor(parameters);
        }

        /// <summary>
        /// Exécute un workflow donné avec des paramètres spécifiés.
        /// Parcourt chaque étape et règle, exécute les modules associés et collecte les résultats.
        /// </summary>
        /// <param name="workflowId">Identifiant du workflow à exécuter.</param>
        /// <param name="parameters">Paramètres nécessaires à l'exécution du workflow.</param>
        /// <returns>Résultat global de l'exécution du workflow avec détails des étapes.</returns>
        public async Task<WorkflowExecutionResult> ExecuteWorkflowAsync(int workflowId, Dictionary<string, string> parameters)
        {
            var workflow = await _workflowRepository.GetWorkflowByIdAsync(workflowId);
            if (workflow == null)
                return new WorkflowExecutionResult
                {
                    Success = false,
                    Message = "Workflow introuvable.",
                    StepResults = new List<StepResult>()
                };

            var stepResults = new List<StepResult>();

            foreach (var step in workflow.Steps.OrderBy(s => s.Order))
            {
                foreach (var rule in step.Rules)
                {
                    if (_modules.TryGetValue(rule.Key, out var module))
                    {
                        var result = await module(parameters);
                        stepResults.Add(new StepResult
                        {
                            StepName = step.StepName,
                            RuleKey = rule.Key,
                            Success = result.Success,
                            Message = result.Message
                        });
                        // En cas d'échec, retourne immédiatement le résultat avec erreur
                        if (!result.Success)
                        {
                            return new WorkflowExecutionResult
                            {
                                Success = false,
                                Message = $"Échec à l’étape {step.StepName} sur la règle {rule.Key}",
                                StepResults = stepResults
                            };
                        }
                    }
                    else
                    {
                        // Module non trouvé dans le mapping
                        return new WorkflowExecutionResult
                        {
                            Success = false,
                            Message = $"Module inconnu : {rule.Key}",
                            StepResults = stepResults
                        };
                    }
                }
            }
            // Tous les modules exécutés avec succès
            return new WorkflowExecutionResult
            {
                Success = true,
                Message = "Workflow exécuté avec succès.",
                StepResults = stepResults
            };
        }


    }
}
