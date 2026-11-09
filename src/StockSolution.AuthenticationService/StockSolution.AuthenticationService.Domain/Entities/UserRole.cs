using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.AuthenticationService.Domain.Entities
{
    public class UserRole
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
