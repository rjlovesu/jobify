using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jobify.Services {
    class UserService : Service {

        public User loggedUser { get; private set; }

        public static List<User> allUsers = new List<User>{
            new User("admin@gmail.com","X Æ A-12","Musk","admin")

        };

        

        public User LoginUserByEmailAndPassword(string email, string password) {
            loggedUser = allUsers.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return loggedUser;
        }
    }


}
