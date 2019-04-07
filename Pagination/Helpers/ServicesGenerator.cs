using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Classes
{
    public class ServicesGenerator
    {
        public static List<ServiceInfo> Generate()
        {
            var a = new ServiceInfo("aaa", 1, 10);
            var b = new ServiceInfo("bbb", 15, 16);
            var c = new ServiceInfo("ccc", 0, 100);
            var d = new ServiceInfo("ddd", 1, 102);
            var e = new ServiceInfo("eee", 99, 190);
            var list = new List<ServiceInfo>() {a, b, c, d, e};
            return list;
        }
    }
}
