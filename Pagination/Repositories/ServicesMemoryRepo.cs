using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pagination.Models;

namespace Pagination.Repositories
{
    public class ServicesMemoryRepo : IServicesMemoryRepo
    {
        private ConcurrentDictionary<Guid, ServiceModel> storage = new ConcurrentDictionary<Guid, ServiceModel>();

        public List<ServiceModel> GetList()
        {
            return storage.Values.ToList();
        }

        public ServiceModel GetService(Guid id)
        {
            ServiceModel service;
            storage.TryGetValue(id, out service);
            return service;
        }

        public bool Add(ServiceModel service)
        {
            return storage.TryAdd(new Guid(), service);
        }

        public bool Delete(Guid id)
        {
            return storage.TryRemove(id, out ServiceModel v);
        }
    }
}
