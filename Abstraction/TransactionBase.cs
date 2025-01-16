using System.Text.Json; // Provides functionality for JSON serialization and deserialization
using MoneyMap.Models; // Assumes this namespace contains the User class definition

namespace MoneyMap.Abstraction;

// Abstract base class to manage user-related operations (e.g., loading and saving user data)
public abstract class TransactionBase
{
    // File path where the transactions.json file is stored in the app's local data directory
    protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");

    // Method to load user data from the transactions.json file
    protected List<TransactionModel> LoadTransactions()
    {
        // If the file does not exist, return an empty list to indicate no transactions are saved
        if (!File.Exists(FilePath)) return new List<TransactionModel>();

        // Read the JSON content from the file
        var json = File.ReadAllText(FilePath);

        // Deserialize the JSON content into a list of User objects
        // If deserialization fails (null result), return an empty list
        return JsonSerializer.Deserialize<List<TransactionModel>>(json) ?? new List<TransactionModel>();
    }

    // Method to save user data to the transactions.json file
    protected void SaveTransactions(List<TransactionModel> transactions)
    {
        // Serialize the list of User objects into a JSON string
        var json = JsonSerializer.Serialize(transactions);

        // Write the JSON string to the transactions.json file
        File.WriteAllText(FilePath, json);
    }
}
