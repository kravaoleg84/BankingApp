using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.DAL.Entities;
using BankingApp.DAL.Context;
using BankingApp.DAL.Interfaces;
using System.Data.Entity;

namespace BankingApp.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private UserContext db;

        public UserRepository(UserContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.User;
        }

        public User Get(int id)
        {
            return db.User.Find(id);
        }

        public void Create(User user)
        {
            db.User.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.User.Where(predicate).ToList();
        }

        public User FindByName(Func<User, Boolean> predicate)
        {
            return db.User.Where(predicate).FirstOrDefault();
        }

        public User FindByNameAndPassword(Func<User, Boolean> predicate)
        {
            return db.User.Where(predicate).FirstOrDefault();
        }

        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
                db.User.Remove(user);
        }
    }
}