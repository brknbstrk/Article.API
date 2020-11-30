namespace Article.API.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public abstract class ArticleCommentsBaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public Guid ArticleId { get; set; }
    }
}
