using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;

namespace EntityFrameworkCore.MockDbSet
{
    [TestClass]
    public class MockDbSetAsyncEnumeratorTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenNullEnumeratorPassedIn_ThenArgumentNullExceptionThrown()
        {
            // Arrange
            var enumerator = default(IEnumerator<HeroEntity>);

            // Act
            try
            {
                new MockDbSetAsyncEnumerator<HeroEntity>(enumerator);
            }
            catch (ArgumentNullException ex)
            {
                // Assert
                Assert.AreEqual("inner", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void Ctor_WhenEnumeratorPassedIn_MockAsyncEnumeratorCreated()
        {
            // Arrange
            var mockEnumerator = Substitute.For<IEnumerator<HeroEntity>>();
            // Act
            var asyncEnumerator = new MockDbSetAsyncEnumerator<HeroEntity>(mockEnumerator);
            // Assert
            Assert.IsNotNull(asyncEnumerator);
        }

        [TestMethod]
        public void Dispose_WhenDisposablePatternUsed_InnerEnumeratorDisposeCalled()
        {
            // Arrange

            var mockIAsyncEnumerator = Substitute.For<IEnumerator<HeroEntity>>();

            // Act
            using (var enumerator = new MockDbSetAsyncEnumerator<HeroEntity>(mockIAsyncEnumerator) as IAsyncEnumerator<HeroEntity>)
            { }

            // Assert
            mockIAsyncEnumerator.Received(1).Dispose();
        }

        [TestMethod]
        public async Task MoveNext_WhenEndOfEnumerator_ReturnsFalseIfMoved()
        {
            // Arrange
            var heroes = new List<HeroEntity> { };
            var enumerator = new MockDbSetAsyncEnumerator<HeroEntity>(heroes.GetEnumerator()) as IAsyncEnumerator<HeroEntity>;

            // Act
            var result = await enumerator.MoveNext(CancellationToken.None);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task MoveNext_WhenItemInEnumerator_ReturnsTrueIfMoved()
        {
            // Arrange
            var heroes = new List<HeroEntity> { new HeroEntity { Id = 21, Name = "Nick Fury" } };
            var enumerator = new MockDbSetAsyncEnumerator<HeroEntity>(heroes.GetEnumerator()) as IAsyncEnumerator<HeroEntity>;

            // Act
            var result = await enumerator.MoveNext(CancellationToken.None);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Current_WhenCalled_ReturnsItem()
        {
            // Arrange
            var heroes = HeroBuilder.CreateAListOfHeros();
            var enumerator = new MockDbSetAsyncEnumerator<HeroEntity>(heroes.GetEnumerator()) as IAsyncEnumerator<HeroEntity>;

            // Act
            while (await enumerator.MoveNext(CancellationToken.None))
            {
                var current = enumerator.Current;
                // Assert
                Assert.IsTrue(heroes.Any(h => h == current));
            }
        }

        [TestMethod]
        public async Task MoveNext_WhenCalled_ReturnsFalseIfAtEnd()
        {
            // Arrange
            var heroes = HeroBuilder.CreateAListOfHeros();
            var enumerator = new MockDbSetAsyncEnumerator<HeroEntity>(heroes.GetEnumerator()) as IAsyncEnumerator<HeroEntity>;

            var count = 0;

            // Act
            while (await enumerator.MoveNext(CancellationToken.None))
            {
                count++;
            }

            // Assert
            Assert.AreEqual(heroes.Count(), count);

        }
    }
}
