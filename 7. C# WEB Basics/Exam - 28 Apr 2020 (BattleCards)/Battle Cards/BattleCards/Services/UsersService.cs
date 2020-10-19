using BattleCards.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using BattleCards.Models;

namespace BattleCards.Services
{
    class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);
            var user = this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return user.Username;
        }

        public void Register(string username, string email, string password)
        {
            var newUser = new User
            { 
                Username = username,
                Email = email,
                Password = this.Hash(password)
            };

            this.db.Users.Add(newUser);
            this.db.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(u => u.Username == username);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
