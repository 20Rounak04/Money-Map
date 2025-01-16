using System;
using System.Collections.Generic;

namespace MoneyMap.Models
{
    public class TransactionModel
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // Credit, Debit, or Debt
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime Date { get; set; }
        public string SourceOfDebt { get; set; } // Only for Debt
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }   // Only for Debt
        public string Notes { get; set; }

        public TransactionModel()
        {
            Tags = new List<string>();
            Status = "Pending"; // Default status
        }
    }


}
