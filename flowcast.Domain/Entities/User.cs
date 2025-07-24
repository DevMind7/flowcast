using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; } = default!;
        public string FirsName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
        public int LeaveBalance { get; set; } 
        public List<Workflow> WorkflowsCreated { get; set; } = new();

    }
}
