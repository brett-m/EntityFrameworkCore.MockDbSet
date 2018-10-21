using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.MockDbSet.Tests
{
    [TestClass]
    public class MockDbSetTests
    {
        [TestMethod]
        public void Ctor_CreateWithDefaultConstructor_MockDbSetShouldBeCreated()
        {
            // Arrange

            // Act
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Assert
            Assert.IsNotNull(heroDbSet);
        }

        [TestMethod]
        public void Ctor_CreateWithDefaultConstructor_ShouldBeOfTypeDbSet()
        {
            // Arrange

            // Act
            var heroDbSet = new MockDbSet<HeroEntity>();

            // Assert
            Assert.IsInstanceOfType(heroDbSet, typeof(DbSet<HeroEntity>));
        }


        [TestMethod]
        public void Ctor_PassingInList_ShouldPopulateMockDbSetWithAllItems()
        {
            // Arrange
            var heroes = HeroBuilder.CreateAListOfHeros();

            // Act
            var heroDbSet = new MockDbSet<HeroEntity>(heroes);

            // Assert
            Assert.AreEqual(heroes.Count(), ((IEnumerable<HeroEntity>)heroDbSet).Count());

        }
    }
}
