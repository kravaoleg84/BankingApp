using BankingApp.BLL.ViewModels;
using BankingApp.DAL.Entities;
using System.Collections.Generic;

namespace BankingApp.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        UserDTO GetUserByName(string userName);
        UserDTO GetUserByNameAndPassword(string userName, string password);
        string DepositMoney(int id, double money);
        string WithdrawMoney(int id, double money);
        string TransferMoney(int fromUserId, string name, double money);
        IEnumerable<TransactionDTO> GetTransactions(int id);
        void AddTransaction(int userId, double sum, TransactionName name, string toUser, string fromUser);
        void AddUser(string userName, string password);
        void Dispose();
    }
}
