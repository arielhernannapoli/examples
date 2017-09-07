using System;
using Xunit;

namespace Example.xTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(2)]
        public void Test2(int value)
        {
            Assert.True(2==value);
        }
    }
}
