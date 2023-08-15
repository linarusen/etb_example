namespace customer.db;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;

public class CustomerContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

    #region Modeller
    public DbSet<Customer> Customers { get; set; }

    #endregion
}