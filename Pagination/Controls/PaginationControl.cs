using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Controls
{
    public class PaginationControl
    {
        public static string A()
        {
            return "123";
        }

        public static List<int> Get(int firstPage, int currentPage, int lastPage)
        {
            if(firstPage < 0 || currentPage > lastPage) return null;

            List<int> pagination = new List<int>();

            for (var i = firstPage; i <= lastPage; i++)
            {
                if (lastPage - firstPage < 9) pagination.Add(i);
                else
                {
                    var isFirstGroup = i <= firstPage + 2;
                    var isCurrentGroup = i >= currentPage - 1 && i <= currentPage + 1;
                    var isLastGroup = i >= lastPage - 2;

                    if (isFirstGroup || isCurrentGroup || isLastGroup) pagination.Add(i);
                }
            }

            return pagination;
        }
    }
}
