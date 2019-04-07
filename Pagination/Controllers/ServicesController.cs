using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pagination.Classes;

namespace Pagination.Controllers
{
    [Route("api/services")]
    public class ServicesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<string> Get()
        {
            return Program.serviceList.GetStringList();
        }

        // GET: api/<controller>/serviceName
        [HttpGet("{serviceName}")]
        public ServiceInfo? Get(string serviceName)
        {
            var serviceInfo = Program.serviceList.GetServiceInfo(serviceName);
            if (serviceInfo != null) return (ServiceInfo)serviceInfo;
            return null;
        }

        // GET: api/<controller>/serviceName/currentPage
        [HttpGet("{serviceName}/{currentPage}")]
        public List<int> Get(string serviceName, int currentPage)
        {
            var pagination = Classes.Pagination.Get(serviceName, currentPage);
            return pagination;
        }

        // POST: api/<controller>/add
        [HttpPost("add")]
        public StatusCodeResult Post([FromBody]ServiceInfo serviceInfo)
        {
            try
            {
                Program.serviceList.Add(serviceInfo.name, serviceInfo.firstPage, serviceInfo.lastPage);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }

        // POST: api/<controller>/remove
        [HttpPost("remove")]
        public StatusCodeResult Post([FromBody]string serviceName)
        {
            try
            {
                Program.serviceList.Remove(serviceName);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }

        // POST: api/<controller>/generate
        [HttpPost("generate")]
        public StatusCodeResult Post()
        {
            Program.serviceList.Generate();
            return Ok();
        }
    }
}
