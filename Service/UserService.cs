using System.Threading.Tasks;
using MoneyMap.Abstraction;
using MoneyMap.Models;
using MoneyMap.Service;
using MoneyMap.Services.Interface;

namespace MoneyMap.Service;
// UserService class for managing user operations such as login, registration, and deletion.
public class UserService : UserBase, IUserService
{
    // Stores the list of users loaded from the file.
    private List<UserModel> _users;

    // Default admin username and password for initial seeding.
    public const string SeedUsername = "admin";
    public const string SeedPassword = "admin";

    // Constructor to initialize the user service.
    public UserService()
    {
        // Load the list of users from the JSON file.
        _users = LoadUsers();

        // If no users are present, add a default admin user and save to the file.
        if (!_users.Any())
        {
            _users.Add(new UserModel { Username = SeedUsername, Password = SeedPassword });
            SaveUsers(_users);
        }
    }

    public bool DeleteUser(string username)
    {
        // Find the user with the specified username.
        var user = _users.FirstOrDefault(u => u.Username == username);
        if (user == null) // If no user is found, return false.
            return false;

        // Remove the user from the list and save the updated list to the file.
        _users.Remove(user);
        SaveUsers(_users);
        return true;
    }

    public List<UserModel> GetAllUsers()
    {
        return _users; // Return the in-memory list of users.
    }

    public bool Login(UserModel user)
    {
        // Validate input for null or empty values.
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
        {
            return false; // Invalid input.
        }

        // Check if the username and password match any user in the list.
        return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
    }

    public bool Register(UserModel user)
    {
        // Check if the username already exists in the list.
        if (_users.Any(u => u.Username == user.Username))
            return false; // Registration failed: user already exists.

        // Add the new user to the list and save the updated list to the file.
        _users.Add(new UserModel { Username = user.Username, Password = user.Password });
        SaveUsers(_users);
        return true;
    }
}

