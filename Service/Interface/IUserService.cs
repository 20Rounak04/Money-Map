﻿using System.Threading.Tasks;
using MoneyMap.Models;

namespace MoneyMap.Services.Interface
{

    // Interface defining the contract for user management services.
    // Any class implementing this interface must provide concrete implementations for the methods below.
    public interface IUserService
    {
        // Authenticates a user based on their username and password.
        // Returns true if the credentials are valid, otherwise false.
        bool Login(UserModel user);

        // Registers a new user with the given details.
        // Returns true if the registration is successful, or false if the username already exists.
        bool Register(UserModel user);

        // Deletes a user identified by their username.
        // Returns true if the user is successfully deleted, or false if the user does not exist.
        bool DeleteUser(string username);

        // Retrieves a list of all registered users.
        // Returns the complete collection of User objects.
        List<UserModel> GetAllUsers();
    }

}
