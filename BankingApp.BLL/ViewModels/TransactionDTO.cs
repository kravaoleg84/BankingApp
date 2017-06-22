using System;
using BankingApp.DAL.Entities;

namespace BankingApp.BLL.ViewModels
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public TransactionName Name { get; set; }
        public double Sum { get; set; }
        public DateTime CreateDate { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
    }
}
