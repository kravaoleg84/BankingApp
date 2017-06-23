using System;
using BankingApp.BLL.Interfaces;
using BankingApp.DAL.Interfaces;
using BankingApp.DAL.Entities;
using BankingApp.BLL.ViewModels;
using BankingApp.BLL.BusinessModels;
using BankingApp.DAL.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace BankingApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService()
        {
            Database = new UnitOfWork();
        }

        public UserDTO GetUser(int id)
        {
            User user = Database.User.Get(id);
            if (user != null)
            {
                return Mapper.Map<User, UserDTO>(user);
            }
            return null;
        }

        public UserDTO GetUserByName(string userName)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                User user = Database.User.FindByName(u => u.UserName == userName);
                if (user != null)
                {
                    return Mapper.Map<User, UserDTO>(user);
                }
            }
            return null;
        }
        public UserDTO GetUserByNameAndPassword(string userName, string password)
        {
            if (!String.IsNullOrEmpty(userName)&&!String.IsNullOrEmpty(password))
            {
                User user = Database.User.
                    FindByNameAndPassword(u => u.UserName == userName && u.Password == password);
                if (user != null)
                {
                    return Mapper.Map<User, UserDTO>(user);
                }
            }
            return null;
        }

        public string DepositMoney(int id, double money)
        {
                User user = Database.User.Get(id);
                if (user != null)
                {
                    user.Balance = new NewBalance(money).Deposit(user.Balance);
                    Database.User.Update(user);
                    Database.Save();
                    AddTransaction(id, money, TransactionName.Deposit, null, null);
                    return "Your request was successfully submitted";
                }
                return "there is no user with such id";
        }

        public string WithdrawMoney(int id, double money)
        {
                User user = Database.User.Get(id);
            if (user != null)
            {
                if (user.Balance >= money)
                {
                    user.Balance = new NewBalance(money).Withdraw(user.Balance);
                    Database.User.Update(user);
                    Database.Save();
                    AddTransaction(id, money, TransactionName.Deposit, null, null);
                    return "Your request was successfully submitted";
                }
                return "Not enough money on your account";
            }
            return "there is no user with such id";
        }

        public string TransferMoney(int fromUserId, string name, double money)
        {
            if (!String.IsNullOrEmpty(name))
            {
                User fromUser = Database.User.Get(fromUserId);
                if (fromUser.Balance >= money)
                {
                    User toUser = Database.User.FindByName(u => u.UserName == name);
                    if (toUser != null)
                    {
                        if (fromUserId == toUser.Id)
                            return "You can't transfer money to yourself";
                        fromUser.Balance = new NewBalance(money).Withdraw(fromUser.Balance);
                        toUser.Balance = new NewBalance(money).Deposit(toUser.Balance);
                        Database.User.Update(fromUser);
                        Database.User.Update(toUser);
                        Database.Save();

                        AddTransaction(fromUserId, money, TransactionName.Transfer, toUser.UserName, null);
                        AddTransaction(toUser.Id, money, TransactionName.Transfer, null, fromUser.UserName);
                    }
                    return "Recipient is not identified";
                }
                return "Not enough money on yuor account";
            }
            return "Enter the name of recipient";
        }

        public void AddUser(string userName, string password)
        {
            User newUser = new User
            {
                UserName = userName,
                Password = password,
                Balance = 0,
                Transactions = null
            };
            Database.User.Create(newUser);
            Database.Save();
        }

        public IEnumerable<TransactionDTO> GetTransactions(string userName)
        {
            var user = Database.User.FindByName(u => u.UserName == userName);
            if (user != null)
            {
                var transactions = Database.Transaction.Find(t => t.UserId == user.Id).ToList();
                return Mapper.Map<IEnumerable<Transaction>, List<TransactionDTO>>(transactions);
            }
            return null;
        }
        public void AddTransaction(int id, double sum, TransactionName name, string toUser, string fromUser)
        {
            Transaction newTr = new Transaction
            {
                Name = name,
                Sum = sum,
                CreateDate = DateTime.Now,
                ToUserName = toUser,
                FromUserName = fromUser,
                UserId = id
            };
            Database.Transaction.Create(newTr);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
