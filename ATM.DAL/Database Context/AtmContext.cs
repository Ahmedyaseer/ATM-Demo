

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ATM.DAL;

    public  class AtmContext : DbContext
    {

    public AtmContext(DbContextOptions options):base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

