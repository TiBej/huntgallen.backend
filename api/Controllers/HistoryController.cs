using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using api.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private HgContext _hgContext;
        private IMapper _mapper;

        public HistoryController(HgContext hgContext, IMapper mapper)
        {
            _hgContext = hgContext;
            _mapper = mapper;
        }

        [HttpPut]
        [Authorize]
        public QRDtoGet AddVerifyQR(string qrcode)
        {
            var qr = _hgContext.QRs.Where(qr => qr.Code == qrcode).ToList();
            if (qr.Count < 1) throw new Exception();

            _hgContext.AddAsync(new History()
            {
                QR_Id = qr.First().Id,
                GUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                TimeStamp = DateTime.Now
            });

            _hgContext.SaveChanges();
            return  _mapper.Map<QRDtoGet>(qr.First());
        }
        
        [HttpGet]
        public IEnumerable<HistoryDtoGet> Get()
        {
            var guid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var histories = _hgContext.Histories.Where(h => h.GUID == guid)
                .Include(h => h.QR).ToList();
            return _mapper.Map<List<HistoryDtoGet>>(histories);
        }
    }
}