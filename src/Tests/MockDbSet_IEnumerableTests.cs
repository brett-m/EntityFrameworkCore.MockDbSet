using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.MockDbSet.Tests
{
    [TestClass]
    public class MockDbSet_IEnumerableTests
    {
        [TestMethod]
        public void GetEnumerator_GivenAGenericEnumerableOfAMockDbSet_ThenTheIEnumerableGenericInterfaceIsImplemented()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Act
            var enumerable = heroDbSet as IEnumerable<HeroEntity>;

            // Assert
            Assert.IsNotNull(enumerable.GetEnumerator());

        }

        [TestMethod]
        public void GetEnumerator_GivenAEnumerableOfAMockDbSet_ThenTheIEnumerableInterfaceIsImplemented()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Act
            var enumerable = heroDbSet as IEnumerable;

            // Assert
            Assert.IsNotNull(enumerable.GetEnumerator());

        }

    }
}
