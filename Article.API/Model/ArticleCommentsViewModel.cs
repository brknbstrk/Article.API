namespace Article.API.Model
{
    using Article.Infrastructure;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ArticleCommentsCreateViewModel : ArticleCommentsBaseViewModel
    {
        public ArticlesComments ToCreateModel()
        {
            return new ArticlesComments
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Surname = Surname,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                Comment = Comment,
                ArticleId = ArticleId
            };
        }
    }
    public class ArticleCommentsEditViewModel : ArticleCommentsBaseViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public ArticlesComments ToEditModel()
        {
            return new ArticlesComments
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                EditDate = DateTime.Now,
                Comment = Comment,
                ArticleId = ArticleId
            };
        }
    }
    public class ArticleCommentsListViewModel : ArticleCommentsBaseViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public ArticleCommentsListViewModel(ArticlesComments model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Surname = model.Surname;
            this.CreateDate = model.CreateDate;
            this.EditDate = model.EditDate;
            this.Comment = model.Comment;
            this.ArticleId = model.ArticleId;
        }

    }
}
