namespace Jobify.Shared.Models {
    public class User {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //TODO hash this:
        public string Password { get; set; }

        public User(string email, string name, string surname, string password) {
            Email       = email    ;
            Name        = name     ;
            Surname     = surname  ;
            Password    = password ;
        }
    }
}
