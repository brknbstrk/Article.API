using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Article.Infrastructure
{
    public class Articles : IEntity<Guid>
    {
        public Articles()
        {
            Comments = new HashSet<ArticlesComments>();
        }
        public Guid Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurName { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Summary { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public IEnumerable<ArticlesComments> Comments { get; set; }

    }
}
