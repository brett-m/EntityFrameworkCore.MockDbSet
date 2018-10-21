using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCore.MockDbSet
{
    [TestClass]
    public class DbContextTests
    {

        [TestMethod]
        public void DbContext_IsInitializedWithMockDbSet_TheDbSetIsAccessible()
        {
            // Arrange
            var mockDbSet = new MockDbSet<HeroEntity>(HeroBuilder.CreateAListOfHeros());

            // Act
            var dbcontext = new HeroesDbContext() { Heroes = mockDbSet };

            // Assert
            Assert.IsNotNull(dbcontext.Heroes);
            Assert.IsTrue(dbcontext.Heroes.Any());
        }


    }
}
