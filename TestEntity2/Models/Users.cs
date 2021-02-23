using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestEntity2.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ImageProfil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        [NotMapped]
        public virtual string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
