using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void SeedRandomData(ModelBuilder modelBuilder)
    {
        var names = new string[]
        {
            "Fang Yuan", "Red Fog", "Black Evil", "Liu Chen", "Shen Wei",
            "Rengoku", "Wu Sheng", "Daoist", "Master Chen", "Zhu Rong",
            "Li Mu", "Yan Shi"
        };

        int userId = 1;
        int accountNumber = 1001;
        int transactionId = 1;

        var users = new List<UserProfile>();
        var accounts = new List<Account>();
        var transactions = new List<Transactions>();

        foreach (var name in names)
        {
            users.Add(new UserProfile
            {
                UserId = userId,
                Name = name,
                Email = $"{name.Replace(" ", "").ToLower()}@example.com",
                Phone = "0123456789",
                Address = "Random Street",
                Password = "pass123",
                Picture = "",
                IsAdmin = userId == 1 // <-- Make the first user admin
            });

            accounts.Add(new Account
            {
                AccountNumber = accountNumber,
                UserId = userId,
                AccountType = "Savings",
                Balance = 5000 + userId * 1000
            });

            transactions.Add(new Transactions
            {
                TransactionId = transactionId,
                AccountNumber = accountNumber,
                TransactionType = "Deposit",
                Amount = 5000 + userId * 1000,
                Date = DateTime.Now,
                UserId = userId,
                Description = "Initial deposit"
            });

            userId++;
            accountNumber++;
            transactionId++;
        }

        modelBuilder.Entity<UserProfile>().HasData(users);
        modelBuilder.Entity<Account>().HasData(accounts);
        modelBuilder.Entity<Transactions>().HasData(transactions);
    }
}
