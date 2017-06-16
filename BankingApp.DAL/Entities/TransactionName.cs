using System.ComponentModel.DataAnnotations;

namespace BankingApp.DAL.Entities
{
    public enum TransactionName
    {
        [Display(Name = "Deposit")]
        Deposit,
        [Display(Name = "Withdraw")]
        Withdraw,
        [Display(Name = "Transfer")]
        Transfer
    }
}