using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Article.API.Controllers.Base
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerApiBase: ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        public ControllerApiBase()
        {
        }
    }
}
