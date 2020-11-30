namespace Article.API.Model
{
    using System.ComponentModel.DataAnnotations;
    public abstract class ArticleBaseViewModel
    {
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurName { get; set; }
        [Required]
        [StringLength(255)]
        public string Summary { get; set; }
        [Required]
        [StringLength(120)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }

    }
}
