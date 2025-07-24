using flowcast.Application.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Application.Modules.Leave
{

    /// <summary>
    /// Validateur qui vérifie la validité des paramètres d'une demande de congé.
    /// Applique un paradigme fonctionnel sans effets de bord ni mutation d'état.
    public static class LeaveValidatorParameters
    {
        public static Task<WorkflowResult> Execute(IReadOnlyDictionary<string, string> parameters)
        {
            return Task.FromResult(Validate(parameters));
        }

        private static WorkflowResult Validate(IReadOnlyDictionary<string, string> p)
        {
            // Parsing des paramètres
            if (!p.TryGetValue("startDate", out var startStr) || !DateTime.TryParse(startStr, out var start))
                return Error("startDate");

            if (!p.TryGetValue("endDate", out var endStr) || !DateTime.TryParse(endStr, out var end))
                return Error("endDate");

            if (end < start)
                return new WorkflowResult(false, "[LeaveValidator] Erreur : La date de fin doit être après la date de début");

            if (!p.TryGetValue("availableDays", out var balanceStr) || !int.TryParse(balanceStr, out var balance))
                return Error("availableDays");

            var requested = (end - start).TotalDays + 1;

            if (requested > balance)
                return new WorkflowResult(false, $"[LeaveValidator] Solde insuffisant : {requested} jour(s) demandé(s), seulement {balance} disponible(s).");

            return new WorkflowResult(true, $"[LeaveValidator] Demande valide : {requested} jour(s), solde suffisant.");
        }

        private static WorkflowResult Error(string field)
            => new(false, $"[LeaveValidator] Paramètre manquant ou invalide : '{field}'");
    }
}
