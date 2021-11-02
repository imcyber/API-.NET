using System;
using api.data.Mapping;
using api.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    name = "Administrador",
                    email = "adm@mail",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );
        }

    }
}
