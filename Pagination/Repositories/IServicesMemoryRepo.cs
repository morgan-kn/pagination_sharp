using System;
using System.Collections.Generic;
using Pagination.Models;

namespace Pagination.Repositories
{
    public interface IServicesMemoryRepo
    {
        List<ServiceModel> GetList();
        ServiceModel GetService(Guid id);
        bool Add(ServiceModel service);
        bool Delete(Guid id);
    }
}