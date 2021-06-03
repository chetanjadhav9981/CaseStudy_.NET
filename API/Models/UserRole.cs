using System;
using System.Collections.Generic;

#nullable disable

namespace CakeBaker.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
