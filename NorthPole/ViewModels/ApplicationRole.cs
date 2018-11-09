using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantaAPI.ViewModels
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, string description, DateTime dateCreated) : base(roleName)
        {
            this.Description = description;
            this.DateCreated = dateCreated;
        }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
