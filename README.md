# EntityFrameworkCore.MockDbSet
A package to help mock DbSet&lt;Entity> for unit tests.

This is library does not fake change detection in DbSets, but allows you to create a DbSet and loop through items using 
* IQueryable
* IEnumerable<TEntity>
* IAsyncEnumerable<TEntity>

## Example
The code below shows creating a mock in a dbcontext
```CSharp
    // Arrange
    var heros = new List<HeroEntity>
    {
        new HeroEntity { Id = 11, Name = "Iron Man"},
        new HeroEntity { Id = 12, Name = "Thor"},
        new HeroEntity { Id = 13, Name = "Hulk"},
        new HeroEntity { Id = 14, Name = "Captain America"},
        new HeroEntity { Id = 15, Name = "Wolverine"},
        new HeroEntity { Id = 16, Name = "Spider Man"},
        new HeroEntity { Id = 17, Name = "Gamora"},
        new HeroEntity { Id = 18, Name = "Doctor Strange"},
        new HeroEntity { Id = 19, Name = "Wasp"},
        new HeroEntity { Id = 20, Name = "Black Widow"},

    };
    var heroDbSet = new MockDbSet<HeroEntity>(heros);
    var mockDbContext = Substitute.For<HeroesDbContext>();

    mockDbContext.Heroes.Returns(heroDbSet);

    // Act
    var result = mockDbContext.Heroes.Where(h => h.Name.Contains("or")).ToList();

    // Assert
    Assert.AreEqual(3, result.Count);    
```
