using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Article.API.Controllers.Base
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerApiBase: ControllerBase
    {
        public ControllerApiBase()
        {
        }
    }
}
