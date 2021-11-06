using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Dto;
using AutoMapper;
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
        private IMapper _mapper;

        public RewardController(HgContext hgContext, IMapper mapper)
        {
            _hgContext = hgContext;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Authorize]
        public IEnumerable<RewardDtoGet> Get()
        {
            var guid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _mapper.Map<List<RewardDtoGet>>(_hgContext.Rewards);
        }
    }
}