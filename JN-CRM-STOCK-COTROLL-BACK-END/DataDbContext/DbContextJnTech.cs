using JN_CRM_STOCK_COTROLL_BACK_END.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace JN_CRM_STOCK_COTROLL_BACK_END.DataDbContext
{
    public class DbContextJnTech : DbContext
    {
    public DbSet<ClientData>   ClientsData { get; set; }
    public DbSet<SellerData> SellersData {get; set;}
     public DbSet<UserData> UsersData {get; set;}
     public DbSet<ProductData> ProductsData {get; set;}
     public DbSet<SaleData> SalesData {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle(connectionString:"Data Source=localhost:1521;User Id=jntechcrm;Password=abcd1234;Integrated Security=no");
            optionsBuilder.UseSqlite("Data Source=mydb.db");
            base.OnConfiguring(optionsBuilder);
        }
    }

    



}