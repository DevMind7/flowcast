using flowcast.Application.Services;
using flowcast.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace flowcast.ApiService.Controllers
{

    /// <summary>
    /// Contrôleur API pour la gestion des utilisateurs.
    /// Fournit des endpoints pour récupérer, créer et accéder aux utilisateurs.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class UserController(UserRepository userRepository) : ControllerBase
    {
        private readonly UserRepository _userRepository = userRepository;

        /// <summary>
        /// Récupère la liste complète des utilisateurs.
        /// </summary>
        /// <returns>Liste des utilisateurs.</returns>

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            var users = await _userRepository?.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Récupère un utilisateur par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant unique de l'utilisateur.</param>
        /// <returns>Utilisateur correspondant à l'identifiant ou 404 si non trouvé.</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Crée un nouvel utilisateur.
        /// </summary>
        /// <param name="user">Données de l'utilisateur à créer.</param>
        /// <returns>Réponse 201 avec l'utilisateur créé, ou 500 en cas d'erreur.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return CreatedAtAction(nameof(GetUserByIdAsync), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, stack = ex.StackTrace });
            }
        }
    }
}
