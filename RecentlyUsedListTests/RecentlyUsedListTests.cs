using RecentlyUsedList;

namespace RecentlyUsedListTests
{
 

    namespace RecentlyUsedListTests
    {
        public class UniqueStringsStackTests
        {
            [Fact]
            public void NewList_ShouldBeEmpty()
            {
                var stack = new UniqueStringsStack();
                Assert.Equal(0, stack.Length);
            }

            [Fact]
            public void Add_ShouldAddItemToList()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                Assert.Equal("item1", stack.ElementAt(0));
            }

            [Fact]
            public void Add_ShouldNotAddDuplicateItemToList()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item1");
                Assert.Single(stack);
            }

            [Fact]
            public void Add_ShouldMoveDuplicateItemToTheEndOfList()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item2");
                stack.Add("item1");
                Assert.Equal("item1", stack.ElementAt(stack.Length - 1));
            }

            [Fact]
            public void Add_ShouldNotAllowNullInsertion()
            {
                var stack = new UniqueStringsStack();
                Assert.Throws<ArgumentException>(() => stack.Add(null));
            }

            [Fact]
            public void Add_ShouldDropLeastRecentlyAddedItemsOnOverflow()
            {
                var stack = new UniqueStringsStack(true, 2);
                stack.Add("item1");
                stack.Add("item2");
                stack.Add("item3");
                Assert.Equal(2, stack.Length);
                Assert.Equal("item2", stack.ElementAt(0));
            }

            [Fact]
            public void ElementAt_ShouldThrowExceptionForNegativeIndex()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                Assert.Throws<ArgumentOutOfRangeException>(() => stack.ElementAt(-1));
            }

            [Fact]
            public void ElementAt_ShouldThrowExceptionForIndexOutOfBounds()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                Assert.Throws<ArgumentOutOfRangeException>(() => stack.ElementAt(5));
            }
        }
    }
}