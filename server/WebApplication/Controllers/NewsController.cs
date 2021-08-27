using Contracts;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IRSS _rss;
        public NewsController(IRSS rss)
        {
            _rss = rss;
        }

        [HttpGet]
        public NewsList Get()
        {
            var retval = new NewsList();
            retval.List = _rss.News;
            return retval;
        }
        [HttpGet]
        public NewsList Refresh()
        {
            _rss.SetNews();
            return Get();
        } 
    }
}
