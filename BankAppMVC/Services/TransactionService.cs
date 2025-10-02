using RestSharp;
using BankAppMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppMVC.Services
{
    public class TransactionService
    {
        private readonly string apiBaseUrl = "https://localhost:7276/api/Transactions";


        public async Task<List<TransactionModel>> GetTransactionsByUserId(int userId)
        {
            var client = new RestClient($"{apiBaseUrl}/ByUser/{userId}");
            var request = new RestRequest { Method = Method.Get };
            var response = await client.ExecuteAsync<List<TransactionModel>>(request);
            return response.Data ?? new List<TransactionModel>();
        }

        public async Task<List<TransactionModel>> GetTransactions()
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest { Method = Method.Get };
            var response = await client.ExecuteAsync<List<TransactionModel>>(request);
            return response.Data ?? new List<TransactionModel>();
        }





        

        public async Task<TransactionModel> GetTransaction(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        public async Task<TransactionModel> CreateTransaction(TransactionModel transaction)
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(transaction);
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        public async Task<TransactionModel> UpdateTransaction(int id, TransactionModel transaction)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddJsonBody(transaction);
            var response = await client.ExecuteAsync<TransactionModel>(request);
            return response.Data;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Delete;
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}
