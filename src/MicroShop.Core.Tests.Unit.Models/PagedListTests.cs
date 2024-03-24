using MicroShop.Core.Models;
using FluentAssertions;

namespace MicroShop.Core.Tests.Unit.Models
{
    public class PagedListTests
    {
        [Fact]
        public void PagedList_BaseConstructorTest()
        {
            var pagedList = new PagedList<int>();

            pagedList.Items.Count.Should().Be(0);
            pagedList.PageNumber.Should().Be(0);
            pagedList.IsFirstPage.Should().BeTrue();
            pagedList.IsLastPage.Should().BeTrue();
            pagedList.PageSize.Should().Be(0);
            pagedList.TotalCount.Should().Be(0);
            pagedList.TotalPages.Should().Be(0);
        }

        [Fact]
        public void PagedList_ShouldReturnPagedList_WhenArgumentsAreCorrect()
        {
            var list = new List<int>
            {
                4,5,6,7,8,9,10,11,12
            };

            var pagedElements = list.Take(4);

            var pagedList = new PagedList<int>(pagedElements, list.Count, 1, pagedElements.Count());

            pagedList.Items.Count.Should().Be(pagedElements.Count());
            pagedList.TotalCount.Should().Be(list.Count);
            pagedList.TotalPages.Should().Be(3);
            pagedList.PageNumber.Should().Be(1);
        }
    }
}
