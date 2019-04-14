using Pagination.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tests.PaginationUnitTests
{
    public class GetPaginationTests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 5, 9, new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9} },
                new object[] { 1, 2, 3, new List<int>(){ 1, 2, 3 } },
                new object[] { 1, 10, 20, new List<int>(){ 1, 2, 3, 9, 10, 11, 18, 19, 20 } },
                new object[] { 5, 7, 200, new List<int>(){ 5, 6, 7, 8, 198, 199, 200 } },
                new object[] { 5, 198, 200, new List<int>(){ 5, 6, 7, 197, 198, 199, 200 } },
                new object[] { 200, 200, 200, new List<int>(){ 200 } },
                new object[] { 1, 10, 5 },
                new object[] { -1, 5, 10 }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Test(int first, int current, int last, List<int> expected = null)
        {
            var actual = Pagination.Controls.Pagination.Get(first, current, last);
            Assert.Equal(expected, actual);
        }
    };

}
