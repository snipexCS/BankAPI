using RestSharp;
using BankAppMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppMVC.Services
{
    public class TransactionService
    {
        private readonly string apiBaseUrl = "https://localhost:7276/api/Transactions";

        // Get all transactions
        public async Task<List<TransactionModel>> GetTransactions()
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest { Method = Method.Get };
            var response = await client.ExecuteAsync<List<TransactionModel>>(request);
            return response.Data ?? new List<TransactionModel>();
        }

        // Get transactions by account number
        public async Task<List<TransactionModel>> GetTransactionsByAccountNumber(int accountNumber)
        {
            var client = new RestClient($"{apiBaseUrl}/ByAccount/{accountNumber}");
            var request = new RestRequest { Method = Method.Get };
            var response = await client.ExecuteAsync<List<TransactionModel>>(request);
            return response.Data ?? new List<TransactionModel>();
        }

        // Get single transaction
        public async Task<TransactionModel> GetTransaction(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        // Create transaction
        public async Task<TransactionModel> CreateTransaction(TransactionModel transaction)
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(transaction);
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        // Update transaction
        public async Task<TransactionModel> UpdateTransaction(int id, TransactionModel transaction)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddJsonBody(transaction);
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        // Delete transaction
        public async Task<bool> DeleteTransaction(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Delete;
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
        public async Task<TransactionModel> TransferMoney(MoneyTransferModel transfer)
        {
            // First, create withdrawal from FromAccount
            var withdrawal = new TransactionModel
            {
                AccountNumber = transfer.FromAccountNumber,
                Amount = transfer.Amount,
                Type = "Withdrawal",
                Description = transfer.Description,
                Date = DateTime.Now
            };
            await CreateTransaction(withdrawal);

            // Then, create deposit to ToAccount
            var deposit = new TransactionModel
            {
                AccountNumber = transfer.ToAccountNumber,
                Amount = transfer.Amount,
                Type = "Deposit",
                Description = transfer.Description,
                Date = DateTime.Now
            };
            await CreateTransaction(deposit);

            return deposit;
        }

    }
}
