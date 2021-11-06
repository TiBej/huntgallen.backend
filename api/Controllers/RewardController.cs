using System.Collections.Generic;
using System.Security.Claims;
using api.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return _mapper.Map<List<RewardDtoGet>>(_hgContext.Rewards);
        }
    }
}