using System.Collections.Generic;

namespace BankingApp.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public User()
        {
            Transactions = new List<Transaction>();
        }
    }
}