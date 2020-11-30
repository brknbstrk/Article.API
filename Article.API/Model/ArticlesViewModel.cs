namespace Article.API.Model
{
    using Article.Infrastructure;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ArticlesCreateViewModel : ArticleBaseViewModel
    {
        public Articles ToCreateModel()
        {
            return new Articles
            {
                Id = Guid.NewGuid(),
                AuthorName = this.AuthorName,
                AuthorSurName = this.AuthorSurName,
                Content = this.Content,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                IsActive = this.IsActive,
                Order = this.Order,
                Summary = this.Summary,
                Title = this.Title
            };
        }
    }
    public class ArticleEditViewModel : ArticleBaseViewModel
    {
        [Required]
        public Guid Id { get; set; }

        public Articles ToEditModel()
        {
            return new Articles
            {
                Id = this.Id,
                AuthorName = this.AuthorName,
                AuthorSurName = this.AuthorSurName,
                Content = this.Content,
                EditDate = DateTime.Now,
                IsActive = this.IsActive,
                Order = this.Order,
                Summary = this.Summary,
                Title = this.Title
            };
        }
    }
    public class ArticleListViewModel : ArticleBaseViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public ArticleListViewModel(Articles model)
        {
            Id = model.Id;
            AuthorName = model.AuthorName;
            AuthorSurName = model.AuthorSurName;
            Content = model.Content;
            CreateDate = model.CreateDate;
            EditDate = model.EditDate;
            IsActive = model.IsActive;
            Order = model.Order;
            Summary = model.Summary;
            Title = model.Title;
        }

    }
}
