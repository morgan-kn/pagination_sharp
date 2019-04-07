using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Classes
{
    public struct ServicePaginationInfo
    {
        public int FirstPage, CurrentPage, LastPage;

        public ServicePaginationInfo(int firstPage, int currentPage, int lastPage)
        {
            this.FirstPage = firstPage;
            this.CurrentPage = currentPage;
            this.LastPage = lastPage;
        }
    }
}
