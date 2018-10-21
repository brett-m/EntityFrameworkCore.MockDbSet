using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace EntityFrameworkCore.MockDbSet
{
    public class HeroEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HeroesDbContext : DbContext
    {
        public virtual DbSet<HeroEntity> Heroes { get; set; }
    }
}
