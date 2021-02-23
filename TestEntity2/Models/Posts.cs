using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestEntity2.Models
{
    public partial class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? Publish { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Users Author { get; set; }
        public virtual Categories Category { get; set; }
    }
}
