using System;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionName Name { get; set; }
        [Range(50, 20000)]
        public double Sum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}