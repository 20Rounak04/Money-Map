using MoneyMap.Models;

namespace MoneyMap.Components.Pages;

    public partial class Register
    {
        private string? Message;

        private UserModel Users { get; set; } = new UserModel();

        private async void RegisterUser()
        {
            if (UserService.Register(Users))
            {
                Message = "User registered successfully!";
                Nav.NavigateTo("/login");
            }
            else
            {
                Message = "Username already exists.";
            }
        }
    }