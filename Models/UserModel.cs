namespace MoneyMap.Models;
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
        
        public decimal Balance { get; set; }
}

