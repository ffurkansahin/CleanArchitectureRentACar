using CleanArchitecture.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entites
{
    public sealed class UserRoles : Entity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }

    }
}
