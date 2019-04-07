using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pagination.Helpers;

namespace Pagination.Classes
{
    public class Pagination
    {
        public static List<int> Get(string serviceName, int currentPage)
        {
            var service = Program.serviceList.GetServiceInfo(serviceName);
            if (service != null)
            {
                ServiceInfo s = (ServiceInfo) service;
                ServicePaginationInfo paginationInfo = new ServicePaginationInfo(s.firstPage, currentPage, s.lastPage);
                List<int> pagination = PaginationHelper.GetPagination(paginationInfo);
                return pagination;
            }

            return null;
        }
    }
}
