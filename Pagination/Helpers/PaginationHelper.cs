using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pagination.Classes;

namespace Pagination.Helpers
{
    public class PaginationHelper
    {
        public static List<int> GetPagination(ServicePaginationInfo paginationInfo)
        {
            return IsValidParams(paginationInfo) ? CreatePagination(paginationInfo) : new List<int>();
        }

        public static List<int> CreatePagination(ServicePaginationInfo paginationInfo)
        {
            List<int> pagination = new List<int>();

            for (var i = paginationInfo.FirstPage; i <= paginationInfo.LastPage; i++)
            {
                if (paginationInfo.LastPage - paginationInfo.FirstPage < 9)
                {
                    pagination.Add(i);
                }
                else
                {
                    var isFirstGroup = i <= paginationInfo.FirstPage + 2;
                    var isCurrentGroup = i >= paginationInfo.CurrentPage - 1 && i <= paginationInfo.CurrentPage + 1;
                    var isLastGroup = i >= paginationInfo.LastPage - 2;

                    if (isFirstGroup || isCurrentGroup || isLastGroup) pagination.Add(i);
                }
            }

            return pagination;
        }

        private static bool IsValidParams(ServicePaginationInfo paginationInfo)
        {
            return paginationInfo.FirstPage >= 0 && paginationInfo.CurrentPage <= paginationInfo.LastPage;
        }
    }
}
