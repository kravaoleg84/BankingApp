using System;
using BankingApp.DAL.Entities;
using BankingApp.DAL.Context;
using BankingApp.DAL.Interfaces;

namespace BankingApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserContext db;
        private UserRepository userRepo;
        private TransactionRepository transactionRepo;

        public UnitOfWork()
        {
            db = new UserContext("DefaulConnection");
        }
        public IRepository<User> User
        {
            get
            {
                if (userRepo == null)
                    userRepo = new UserRepository(db);
                return userRepo;
            }
        }

        public IRepository<Transaction> Transaction
        {
            get
            {
                if (transactionRepo == null)
                    transactionRepo = new TransactionRepository(db);
                return transactionRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}