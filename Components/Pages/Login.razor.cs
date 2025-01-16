using MoneyMap.Models;
using Microsoft.AspNetCore.Components;

namespace MoneyMap.Components.Pages;
    public partial class Login
    {
        private string? ErrorMessage;

        public UserModel Users { get; set; } = new();

        private async void HandleLogin()
        {
            if (UserService.Login(Users))
            {
                Nav.NavigateTo("/dashboard");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }
    }
