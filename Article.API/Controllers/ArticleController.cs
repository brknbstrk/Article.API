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
    [ApiController]
    public class ArticleController : ControllerApiBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IRepository<Articles,Guid> _repo;
        private readonly IMemoryCache _memoryCache;
        private readonly string cacheKey = "articleCache";
        public ArticleController(IRepository<Articles,Guid> repo,IMemoryCache memoryCache)
        {
            _repo = repo;
            _memoryCache = memoryCache;
        }
        [HttpGet("GetAllArticle")]
        public IActionResult GetAll()
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey,out IEnumerable<ArticleListViewModel> data))
                {
                    data = _repo.GetAll().Select(x => new ArticleListViewModel(x));
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
        public IActionResult Update(ArticleEditViewModel data)
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
        public IActionResult Add(ArticlesCreateViewModel data)
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
                return new JsonResult(new ArticleListViewModel(_repo.GetById(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
