using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pagination.Controls;
using Pagination.Models;

namespace Pagination.Controllers
{
    [Route("api/services")]
    public class ServicesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<ServiceModel> GetList()
        {
            return ServiceControl.GetList();
        }

        // GET: api/<controller>/id
        [HttpGet("{id}")]
        public ServiceModel GetService(Guid id)
        {
            return ServiceControl.GetService(id);
        }

        // GET: api/<controller>/id/currentPage
        [HttpGet("{id}/{page}")]
        public List<int> GetPagination(Guid id, int page)
        {
            if (page < 0 || !(page is int)) return null;

            return ServiceControl.GetPagination(id, page);
        }

        // POST: api/<controller>/add
        [HttpPost("add")]
        public StatusCodeResult Add([FromBody]ServiceModel service)
        {
            try
            {
                ServiceControl.Add(service);
                return Ok();
            }
            catch { return NoContent(); }
        }

        // POST: api/<controller>/delete
        [HttpPost("delete")]
        public StatusCodeResult Delete([FromBody]Guid id)
        {
            try
            {
                ServiceControl.Delete(id);
                return Ok();
            }
            catch { return NoContent(); }
        }
    }
}
