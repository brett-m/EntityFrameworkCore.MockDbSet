using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EntityFrameworkCore.MockDbSet.Tests
{
    [TestClass]
    public class MockDbSet_IQueryableTests
    {

        [TestMethod]
        public void Provider_CreatingAMockDbSet_ShouldImplementIQueryableProvider()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

         
            // Act
            var queryable = heroDbSet as IQueryable;

            // Assert
            Assert.IsNotNull(queryable.Provider);
            Assert.IsInstanceOfType(queryable.Provider, typeof(IQueryProvider));

        }


        [TestMethod]
        public void Expression_CreatingAMockDbSet_ShouldImplementIQueryableExpression()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Act
            var queryable = heroDbSet as IQueryable;

            // Assert
            Assert.IsNotNull(queryable.Expression);
        }

        [TestMethod]
        public void ElementType_CreatingAMockDbSet_ShouldImplementIQueryableElementType()
        {
            // Arrange
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Act
            var queryable = heroDbSet as IQueryable;

            // Assert
            Assert.IsNotNull(queryable.ElementType);            
            Assert.AreSame(typeof(HeroEntity), queryable.ElementType); 
        }
    }
}
