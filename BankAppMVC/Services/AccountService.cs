using RestSharp;
using BankAppMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppMVC.Services
{
    public class AccountService
    {
        private readonly string apiBaseUrl = "https://localhost:7276/api/Accounts";


        public async Task<List<AccountModel>> GetAccounts()
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest { Method = Method.Get };
            var response = await client.ExecuteAsync<List<AccountModel>>(request);
            return response.Data ?? new List<AccountModel>();
        }

        public async Task<List<AccountModel>> GetAccountsByUserId(int userId)
        {
            var allAccounts = await GetAccounts();
            return allAccounts.Where(a => a.UserId == userId).ToList();
        }

        

        public async Task<AccountModel> GetAccount(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync<AccountModel>(request);
            return response.Data;
        }

        public async Task<AccountModel> CreateAccount(AccountModel account)
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(account);
            var response = await client.ExecuteAsync<AccountModel>(request);
            return response.Data;
        }

        public async Task<AccountModel> UpdateAccount(int id, AccountModel account)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddJsonBody(account);
            var response = await client.ExecuteAsync<AccountModel>(request);
            return response.Data;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Delete;
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}
