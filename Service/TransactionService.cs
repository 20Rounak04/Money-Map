using Microsoft.AspNetCore.Components;
using MoneyMap.Abstraction;
using MoneyMap.Models;
using MoneyMap.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMap.Services
{
    public class TransactionService : TransactionBase, ITransactionService
    {
        private List<TransactionModel> _transactions = new();
        private List<UserModel> _users;
        //private List<TransactionModel> _transactions;

        public async Task<bool> AddTransactionAsync(TransactionModel transaction)
        {
            _transactions.Add(transaction);
            SaveTransactions(_transactions);
            return await Task.FromResult(true);

        }

        public async Task<List<TransactionModel>> GetAllTransactionsAsync()
        {
            _transactions = LoadTransactions();
            return await Task.FromResult(_transactions);
        }

        public async Task<List<TransactionModel>> SearchTransactionsAsync(string query, string type, string dateRange)
        {
            var filtered = _transactions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
                filtered = filtered.Where(t => t.Title.Contains(query));

            if (!string.IsNullOrWhiteSpace(type))
                filtered = filtered.Where(t => t.TransactionType == type);

            return await Task.FromResult(filtered.ToList());
        }

        public async Task<decimal> GetCurrentBalanceAsync(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return user != null ? user.Balance : 0;
        }

        public async Task<bool> DeleteTransactionAsync(TransactionModel transaction)
        {
            if (_transactions.Contains(transaction))
            {
                _transactions.Remove(transaction);
                SaveTransactions(_transactions); // Persist changes
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task UpdateTransactionAsync(TransactionModel transaction)
        {
            // Find the transaction to update
            var existingTransaction = _transactions.FirstOrDefault(t => t.Id == transaction.Id);

            if (existingTransaction != null)
            {
                // Update the properties of the transaction
                existingTransaction.Title = transaction.Title;
                existingTransaction.Amount = transaction.Amount;
                existingTransaction.TransactionType = transaction.TransactionType;
                existingTransaction.Status = transaction.Status;
                existingTransaction.DueDate = transaction.DueDate;
                existingTransaction.Tags = transaction.Tags; // If tags exist

                // Persist the updated transaction list
                SaveTransactions(_transactions);
            }

            await Task.CompletedTask;
        }


        private List<string> DefaultTags = new()
        {
            "Yearly", "Monthly", "Food", "Drinks", "Clothes", "Gadgets",
            "Miscellaneous", "Fuel", "Rent", "EMI", "Party"
        };

        private void HandleTagSelection(ChangeEventArgs e, TransactionModel transaction)
        {
            transaction.Tags.Clear();

            if (e.Value is IEnumerable<string> selectedOptions)
            {
                transaction.Tags.AddRange(selectedOptions);
            }
            else if (e.Value is string singleOption)
            {
                transaction.Tags.Add(singleOption);
            }
        }
    }
}
