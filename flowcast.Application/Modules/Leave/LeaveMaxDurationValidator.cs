using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flowcast.Application.Engine;


namespace flowcast.Application.Modules.Leave
{
    /// <summary>
    /// Validateur qui vérifie que la durée d'une demande de congé ne dépasse pas la limite maximale autorisée.
    /// Cette classe applique un paradigme fonctionnel : ses méthodes sont pures, sans effet de bord ni mutation d'état.
    /// </summary>
    public class LeaveMaxDurationValidator
    {
        private const int MaxAllowedDays = 20;

        public static Task<WorkflowResult> Execute(IReadOnlyDictionary<string, string> parameters)
        {
            return Task.FromResult(Validate(parameters));
        }

        public static WorkflowResult Validate(IReadOnlyDictionary<string, string> p)
        {
            if (!p.TryGetValue("startDate", out var startStr) || !DateTime.TryParse(startStr, out var start))
                return Error("startDate");

            if (!p.TryGetValue("endDate", out var endStr) || !DateTime.TryParse(endStr, out var end))
                return Error("endDate");

            var requested = (end - start).TotalDays + 1;

            if (requested > MaxAllowedDays)
                return new WorkflowResult(false, $"[LeaveMaxDurationValidator] La demande dépasse la limite autorisée de {MaxAllowedDays} jours ({requested} jours demandés).");

            return new WorkflowResult(true, $"[LeaveMaxDurationValidator] Durée conforme ({requested} jours demandés).");
        }

        public static WorkflowResult Error(string field)
            => new(false, $"[LeaveMaxDurationValidator] Paramètre invalide ou manquant : '{field}'");
    }
}
