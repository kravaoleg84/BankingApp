using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.DAL.Entities;
using BankingApp.DAL.Context;
using BankingApp.DAL.Interfaces;
using System.Data.Entity;

namespace BankingApp.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private UserContext db;

        public TransactionRepository(UserContext context)
        {
            this.db = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transaction.Include(t => t.User);
        }

        public Transaction Get(int id)
        {
            return db.Transaction.Find(id);
        }

        public void Create(Transaction tr)
        {
            db.Transaction.Add(tr);
        }

        public void Update(Transaction tr)
        {
            db.Entry(tr).State = EntityState.Modified;
        }
        public IEnumerable<Transaction> Find(Func<Transaction, Boolean> predicate)
        {
            return db.Transaction.Include(t => t.User).Where(predicate).ToList();
        }
        public Transaction FindBy(Func<Transaction, Boolean> predicate)
        {
            return db.Transaction.Where(predicate).FirstOrDefault();
        }
        public Transaction FindByName(Func<Transaction, Boolean> predicate)
        {
            return db.Transaction.Where(predicate).FirstOrDefault();
        }
        public void Delete(int id)
        {
            Transaction tr = db.Transaction.Find(id);
            if (tr != null)
                db.Transaction.Remove(tr);
        }
    }
}