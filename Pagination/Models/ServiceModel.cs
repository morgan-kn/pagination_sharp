using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Models
{
    public class ServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
    }
}
