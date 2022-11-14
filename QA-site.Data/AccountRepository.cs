using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
;

namespace QA_site.Data
{
  public class AccountRepository
    {

        private string _connectionString;
        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object Bcrypt { get; private set; }

        public Users Login(string email, string password)
        {
            var user = GetByEmail(email);
            if(user == null)
            {
                return null;
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return isValid ? user : null;
        }

        public Users AddUsers(Users user, string password)
        {
            using var context = new QADataContext(_connectionString);
            object passwordHash = Bcrypt.Net.BCrypt.HashPassword(password);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public Users GetByEmail(string email)
        {
            using var context = new QADataContext(_connectionString);
            return context.Users.FirstOrDefault(u => u.Email == email)
        }

        public void AddUser(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
