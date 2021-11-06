using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private HgContext _hgContext;

        public HistoryController(HgContext hgContext)
        {
            _hgContext = hgContext;
        }

        [HttpPut]
        [Authorize]
        public QR AddVerifyQR(string qrcode)
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
            return qr.First();
        }
        
        [HttpGet]
        public IEnumerable<History> Get()
        {
            var guid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _hgContext.Histories.Where(h => h.GUID == guid).ToList();
        }
    }
}