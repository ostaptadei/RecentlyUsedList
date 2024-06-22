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
            public void NewListWithCapacityBound_ShouldBeEmpty()
            {
                var stack = new UniqueStringsStack(true);
                Assert.Equal(0, stack.Length);
            }


            [Fact]
            public void Length_ShouldReturnCorrectStackLength()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item2");
                stack.Add("item3");
                Assert.Equal(3, stack.Length);
            }

            [Fact]
            public void Add_ShouldAddItemToStack()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                Assert.Equal("item1", stack.ElementAt(0));
            }

            [Fact]
            public void Add_ShouldNotAddDuplicateItemToStack()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item1");
                Assert.Equal(1, stack.Length);
            }

            [Fact]
            public void Add_ShouldMoveDuplicateItemToTheStackBeginning()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item2");
                stack.Add("item1");
                Assert.Equal("item1", stack.ElementAt(1));
            }

            [Fact]
            public void Add_ShouldNotAllowNullInsertion()
            {
                var stack = new UniqueStringsStack();
                Assert.Throws<ArgumentNullException>(() => stack.Add(null));
            }

            [Fact]
            public void Add_ShouldNotAllowEmptyStringInsertion()
            {
                var stack = new UniqueStringsStack();
                Assert.Throws<ArgumentException>(() => stack.Add(""));
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
            public void ElementAt_ShouldReturnElementAtCorrectIndex()
            {
                var stack = new UniqueStringsStack();
                stack.Add("item1");
                stack.Add("item2");
                stack.Add("item3");
                Assert.Equal("item2", stack.ElementAt(1));
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