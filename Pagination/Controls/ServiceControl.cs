using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Controls
{
    public class ServiceControl
    {
        public static List<ServiceModel> GetList()
        {
            // from DB
            return new List<ServiceModel>();
        }

        public static ServiceModel GetService(Guid id)
        {
            // from DB by name
            return new ServiceModel();
        }

        public static List<int> GetPagination(Guid id, int currentPage)
        {
            // from DB by name
            ServiceModel service = new ServiceModel();
            return PaginationControl.Get(service.FirstPage, currentPage, service.LastPage);
        }

        public static void Add(ServiceModel service)
        {
            service.Id = new Guid();
            try { /* add to DB */ }
            catch { throw; }
        }

        public static void Delete(Guid id)
        {
            try { /* remove from DB */ }
            catch { throw; }
        }
    }
}
