using ConnectionTestAPI.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionTestAPI.Contexts
{
    public class AccountContext : DbContext
    {   
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasKey(a => a.Id);

            base.OnModelCreating(builder);
        }
    }

    public class AccountContextFactory : IDbContextFactory<AccountContext>
    {
        public AccountContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=localhost;Port=5432;Database=accountdb;");
            return new AccountContext(optionsBuilder.Options);
        }
    }
}
