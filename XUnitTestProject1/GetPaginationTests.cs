using System;
using System.Collections;
using System.Collections.Generic;
using Pagination.Classes;
using Pagination.Helpers;
using Xunit;

namespace PaginationUnitTests
{
    public class GetPaginationTests
    {
        static readonly ArrayList case1_5_9 = new ArrayList()
        {
            new ServicePaginationInfo(1, 5, 9),
            new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9}
        };

        static readonly ArrayList case1_2_3 = new ArrayList()
        {
            new ServicePaginationInfo(1, 2, 3),
            new List<int>() {1, 2, 3}
        };

        static readonly ArrayList case1_10_20 = new ArrayList()
        {
            new ServicePaginationInfo(1, 10, 20),
            new List<int>() {1, 2, 3, 9, 10, 11, 18, 19, 20}
        };

        static readonly ArrayList case5_7_200 = new ArrayList()
        {
            new ServicePaginationInfo(5, 7, 200),
            new List<int>() {5, 6, 7, 8, 198, 199, 200}
        };

        static readonly ArrayList case5_198_200 = new ArrayList()
        {
            new ServicePaginationInfo(5, 198, 200),
            new List<int>() {5, 6, 7, 197, 198, 199, 200}
        };

        static readonly ArrayList case200 = new ArrayList()
        {
            new ServicePaginationInfo(200, 200, 200),
            new List<int>() {200}
        };

        static readonly ArrayList case1_10_5 = new ArrayList()
        {
            new ServicePaginationInfo(1, 10, 5),
            new List<int>() {}
        };

        static readonly ArrayList case1N_5_10 = new ArrayList()
        {
            new ServicePaginationInfo(-1, 5, 10),
            new List<int>() {}
        };

        [Fact]
        public void Test1_5_9()
        {
            Test(GetPaginationTests.case1_5_9);
        }

        [Fact]
        public void Test1_2_3()
        {
            Test(GetPaginationTests.case1_2_3);
        }

        [Fact]
        public void Test1_10_20()
        {
            Test(GetPaginationTests.case1_10_20);
        }

        [Fact]
        public void Test5_7_200()
        {
            Test(GetPaginationTests.case5_7_200);
        }

        [Fact]
        public void Test5_198_200()
        {
            Test(GetPaginationTests.case5_198_200);
        }

        [Fact]
        public void Test200()
        {
            Test(GetPaginationTests.case200);
        }

        [Fact]
        public void Test1_10_5()
        {
            EmptyResultTest(GetPaginationTests.case1_10_5);
        }

        [Fact]
        public void Test1N_5_10()
        {
            EmptyResultTest(GetPaginationTests.case1N_5_10);
        }

        private void Test(ArrayList testCase)
        {
            var paginationInfo = (ServicePaginationInfo) testCase[0];
            var expected = testCase[1];
            var pagination = PaginationHelper.CreatePagination(paginationInfo);
            Assert.Equal(pagination, expected);
        }

        private void EmptyResultTest(ArrayList testCase)
        {
            var paginationInfo = (ServicePaginationInfo)testCase[0];
            var expected = testCase[1];
            var pagination = PaginationHelper.GetPagination(paginationInfo);
            Assert.Equal(pagination, expected);
        }
    };

}
