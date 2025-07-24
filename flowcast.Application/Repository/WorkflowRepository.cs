using flowcast.Domain.Entities;
using flowcast.Domain.Interfaces;
using flowcast.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Application.Repository
{
    // Repository pour gérer les opérations CRUD liées aux workflows,
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly FlowcastDbContext _context;

        public WorkflowRepository(FlowcastDbContext context)
        {
            _context = context;
        }

        // Ajoute un nouveau workflow à la base de données et sauvegarde immédiatement.
        public async Task<Workflow> AddWorkflowAsync(Workflow workflow)
        {
            if (workflow == null)
                throw new ArgumentNullException(nameof(workflow), "Le workflow ne peut pas être null.");

            try
            {
                await _context.Workflows.AddAsync(workflow);
                await _context.SaveChangesAsync();
                return workflow;
            }
            catch (DbUpdateException dbEx)
            {
                // Erreur typique : contrainte FK, unicité, etc.
                var message = $"Erreur lors de l'insertion du workflow '{workflow.Name}': {dbEx.Message}";
                Console.WriteLine(message);
                throw new ApplicationException(message, dbEx);
            }
            catch (ValidationException valEx)
            {
                var message = $"Erreur de validation lors de l'insertion du workflow '{workflow.Name}': {valEx.Message}";
                Console.WriteLine(message);
                throw new ApplicationException(message, valEx);
            }
            catch (Exception ex)
            {
                // Catch global pour toute autre erreur imprévue
                var message = $"Erreur inattendue lors de l'insertion du workflow '{workflow.Name}': {ex.Message}";
                Console.WriteLine(message);
                throw new ApplicationException(message, ex);
            }
        }


        // Récupère tous les workflows avec leurs définitions de paramètres, étapes, et règles associées.
        public async Task<List<Workflow>> GetAllWorkflowsAsync()
        {
            return await _context.Workflows
                .Include(w => w.ParameterDefinitions)
                .Include(w => w.Steps)
                    .ThenInclude(s => s.Rules)
                .ToListAsync();
        }

        // Récupère un workflow spécifique par son Id, incluant ses paramètres, étapes et règles.
        public async Task<Workflow?> GetWorkflowByIdAsync(int id)
        {
            return await _context.Workflows
                .Include(w => w.ParameterDefinitions)
                .Include(w => w.Steps)
                    .ThenInclude(s => s.Rules)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<Workflow>> GetAllWorkflowsDetailedAsync()
        {
            return await _context.Workflows
                .Include(w => w.ParameterDefinitions)
                .Include(w => w.Steps)
                    .ThenInclude(s => s.Rules)
                .ToListAsync();
        }

        // Récupère le solde de congés (LeaveBalance) d'un utilisateur donné.
        public async Task<int> GetLeaveBalanceAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => (int)u.LeaveBalance)
                .FirstOrDefaultAsync();
        }

        // Récupère la liste de tous les modules
        public async Task<List<Module>> GetAllModules()
        {
            return await _context.Modules.ToListAsync();
        }
    }
}
