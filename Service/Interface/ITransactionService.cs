using MoneyMap.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMap.Services.Interface
{
    public interface ITransactionService
    {
        Task<bool> AddTransactionAsync(TransactionModel transaction);
        Task<List<TransactionModel>> GetAllTransactionsAsync();
        Task<List<TransactionModel>> SearchTransactionsAsync(string query, string type, string dateRange);
        Task<decimal> GetCurrentBalanceAsync(string username);

        Task<bool> DeleteTransactionAsync(TransactionModel transaction);
        Task UpdateTransactionAsync(TransactionModel transaction);
    }
}
