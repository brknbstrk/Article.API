using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Article.Infrastructure
{
    [Table("ArticlesComments")]
    public class ArticlesComments : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public Guid ArticleId { get; set; }
        public Articles Article { get; set; }
    }
}
