using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RewardController : ControllerBase
    {
        private HgContext _hgContext;

        public RewardController(HgContext hgContext)
        {
            _hgContext = hgContext;
        }
        
        [HttpGet]
        [Authorize]
        public IEnumerable<Reward> Get()
        {
            var guid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _hgContext.Rewards;
        }
    }
}