using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EntityFrameworkCore.MockDbSet.Tests
{
    [TestClass]
    public class MockDbSet_IAsyncEnumerableTests
    {
        [TestMethod]
        public void GetEnumerator_GivenAnAsyncGenericEnumerableOfAMockDbSet_ThenTheIEnumerableGenericInterfaceIsImplemented()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Act
            var enumerable = heroDbSet as IAsyncEnumerable<HeroEntity>;

            // Assert
            Assert.IsNotNull(enumerable.GetEnumerator());
        }
    }
}
