using GameStart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart.Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private User()
        {

        }

        public User(string userName, string passWord, string role, string firstName, string lastName)
        {
            UserName = userName;
            Password = passWord;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
