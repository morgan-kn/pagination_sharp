using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Classes
{
    public struct ServiceInfo
    {
        public string name;
        public int firstPage, lastPage;

        public ServiceInfo(string name, int firstPage, int lastPage)
        {
            this.name = name;
            this.firstPage = firstPage;
            this.lastPage = lastPage;
        }
    }
}
