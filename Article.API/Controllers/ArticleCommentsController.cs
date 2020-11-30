using Article.API.Controllers.Base;
using Article.API.Model;
using Article.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Article.API.Controllers
{
    public class ArticleCommentsController : ControllerApiBase
    {
        private readonly ILogger<ArticleCommentsController> _logger;
        private readonly IRepository<ArticlesComments, Guid> _repo;
        private readonly IMemoryCache _memoryCache;
        private readonly string cacheKey = "articleCommentCache";
        public ArticleCommentsController(IRepository<ArticlesComments,Guid> repo, IMemoryCache memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }
        [HttpGet("GetAllArticleComments")]
        public IActionResult GetAll()
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<ArticleCommentsListViewModel> data))
                {
                    data = _repo.GetAll().Select(x=> new ArticleCommentsListViewModel(x));
                    _memoryCache.Set(cacheKey, data);
                }

                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPost("Update")]
        public IActionResult Update(ArticleCommentsEditViewModel data)
        {
            try
            {
                _repo.Update(data.ToEditModel());
                _repo.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(ArticleCommentsCreateViewModel data)
        {
            try
            {
                _repo.Add(data.ToCreateModel());
                _repo.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repo.Delete(id);
                _repo.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return new JsonResult(_repo.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
