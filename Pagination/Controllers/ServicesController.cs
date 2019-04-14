using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pagination.Controls;
using Pagination.Models;
using Pagination.Repositories;

namespace Pagination.Controllers
{
    [Route("api/services")]
    public class ServicesController : Controller
    {
        private readonly IServicesMemoryRepo servicesMemoryRepo = new ServicesMemoryRepo();

        // GET: api/<controller>
        [HttpGet]
        public List<ServiceModel> GetList()
        {
            return servicesMemoryRepo.GetList();
        }

        // GET: api/<controller>/id
        [HttpGet("{id}")]
        public ServiceModel GetService(Guid id)
        {
            return servicesMemoryRepo.GetService(id);
        }

        // GET: api/<controller>/id/currentPage
        [HttpGet("{id}/{page}")]
        public List<int> GetPagination(Guid id, int page)
        {
            if (page < 0 || !(page is int)) return null;

            var service = servicesMemoryRepo.GetService(id);
            return Controls.Pagination.Get(service.FirstPage, page, service.LastPage);
        }

        // POST: api/<controller>/add
        [HttpPost("add")]
        public StatusCodeResult Add([FromBody]ServiceModel service)
        {
            var result = servicesMemoryRepo.Add(service);
            if (result) return Ok();
            return NoContent();
        }

        // POST: api/<controller>/delete
        [HttpPost("delete")]
        public StatusCodeResult Delete([FromBody]Guid id)
        {
            var result = servicesMemoryRepo.Delete(id);
            if (result) return Ok();
            return NoContent();
        }
    }
}
