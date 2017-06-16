using System.Data.Entity;
using BankingApp.DAL.Entities;

namespace BankingApp.DAL.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public UserContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}