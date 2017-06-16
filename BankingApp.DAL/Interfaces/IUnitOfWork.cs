using System;
using BankingApp.DAL.Entities;

namespace BankingApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> User { get; }
        IRepository<Transaction> Transaction { get; }
        void Save();
    }
}
