using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkCore.MockDbSet
{
    [TestClass]
    public class MockDbSetAsyncEnumerableTests
    {

        [TestMethod]
        public void Ctor_WhenValidEnumerablePassedIn_ThenClassCreated()
        {
            // Arrange
            var inner = new List<HeroEntity>() as IEnumerable<HeroEntity>;

            // Act
            var enumerable = new MockDbSetAsyncEnumerable<HeroEntity>(inner);

            // Assert
            Assert.IsNotNull(enumerable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenNullEnumerablePassedIn_ThenArgumentNullExceptionThrown()
        {
            // Arrange
            var inner = default( IEnumerable<HeroEntity>);

            // Act
            try
            {
                new MockDbSetAsyncEnumerable<HeroEntity>(inner);
            }
            catch(ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("enumerable", ex.ParamName);
                throw;
            }
        }

        [TestMethod]        
        public void Ctor_WhenValidExpressionParameters_ThenClassCreated()
        {
            // Arrange
            var query = new List<HeroEntity>().AsQueryable();
            var expression = query.Expression;
            // Act
            var enumerable = new MockDbSetAsyncEnumerable<HeroEntity>(expression);

            // Assert
            Assert.IsNotNull(enumerable);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenNullExpressionPassedIn_ThenArgumentNullExceptionThrown()
        {
            // Arrange
            var expression = default(Expression);
            // Act
            try
            {
                new MockDbSetAsyncEnumerable<HeroEntity>(expression);
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("expression", ex.ParamName);
                throw;
            }

        }


        [TestMethod]
        public void GetAsyncEnumerator_WhenConstructedWithExpression_ReturnsGenericIAsyncEnumerator()
        {
            // Arrange

            // Act

            // Assert

        }


        [TestMethod]
        public void Provider_WhenConstructedWithExpression_ReturnsProvider()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void GetAsyncEnumerator_WhenConstructedWithEnumerable_ReturnsGenericIAsyncEnumerator()
        {
            // Arrange
            var inner = new List<HeroEntity>() as IEnumerable<HeroEntity>;
            var enumerable = new MockDbSetAsyncEnumerable<HeroEntity>(inner);

            // Act

            var result = enumerable.GetAsyncEnumerator();

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Provider_WhenConstructedWithEnumerable_ReturnsProvider()
        {
            // Arrange
            var inner = new List<HeroEntity>() as IEnumerable<HeroEntity>;
            var enumerable = new MockDbSetAsyncEnumerable<HeroEntity>(inner);

            // Act
            var provider = ((IQueryable)enumerable).Provider;

            // Assert
            Assert.IsNotNull(provider);

        }
    }
}
