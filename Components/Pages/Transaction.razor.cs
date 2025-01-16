using Microsoft.AspNetCore.Components;
using MoneyMap.Models;
using MoneyMap.Services.Interface;

namespace MoneyMap.Pages
{
    public partial class Transaction
    {
        [Inject]
        public ITransactionService TransactionService { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        public TransactionModel TransactionModel { get; set; } = new TransactionModel();
        public List<string> DefaultTags { get; set; } = new()
        {
            "Yearly", "Monthly", "Food", "Drinks", "Clothes", "Gadgets", "Miscellaneous", "Fuel", "Rent", "EMI", "Party"
        };

        private async Task HandleSubmit()
        {
            var success = await TransactionService.AddTransactionAsync(TransactionModel);
            if (success)
            {
                Navigation.NavigateTo("/transaction-list");
            }
            else
            {
                // Handle error
            }
        }
    }
}
