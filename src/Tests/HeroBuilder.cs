using System.Collections.Generic;

namespace EntityFrameworkCore.MockDbSet
{
    public static class HeroBuilder
    {
        public static List<HeroEntity> CreateAListOfHeros()
        {
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
            return heros;
        }
    }
}
