using MoneyMap.Models;
using Microsoft.AspNetCore.Components;

namespace MoneyMap.Components.Layout
{

    public partial class MainLayout
    {
        private GlobalState _globalState = new();

        private void LogoutHandler()
        {
            if (_globalState.CurrentUser == null)
            {
                Nav.NavigateTo("/login");
            }
        }

    }
}