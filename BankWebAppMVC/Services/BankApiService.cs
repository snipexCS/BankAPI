using BankWebAppMVC.Models;
using Newtonsoft.Json;
using RestSharp;

namespace BankWebAppMVC.Services
{
    public class BankApiService
    {
        private readonly string _baseUrl;
        private readonly RestClient _client;

        public BankApiService(string baseUrl)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _client = new RestClient(_baseUrl);
        }

       
        public async Task<UserProfile?> AuthenticateAsync(string email, string password)
        {
            var request = new RestRequest("api/userprofiles/auth", Method.Post)
                .AddJsonBody(new { Email = email, Password = password });

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return null;

            return JsonConvert.DeserializeObject<UserProfile>(response.Content);
        }

        
        public async Task<List<Account>> GetAccountsByUserIdAsync(int userId)
        {
            var request = new RestRequest("api/accounts", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return new List<Account>();

            var allAccounts = JsonConvert.DeserializeObject<List<Account>>(response.Content);
            return allAccounts?.Where(a => a.UserId == userId).ToList() ?? new List<Account>();
        }

        
        public async Task<List<Transactions>> GetTransactionsByAccountAsync(int accountNumber)
        {
            var request = new RestRequest($"api/transactions/ByAccount/{accountNumber}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return new List<Transactions>();

            return JsonConvert.DeserializeObject<List<Transactions>>(response.Content) ?? new List<Transactions>();
        }
        public async Task<RestResponse> ExecuteRequestAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }

     
       
        public async Task<UserProfile?> GetUserByIdAsync(int userId)
        {
            var request = new RestRequest($"api/userprofiles/{userId}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return null;
            return JsonConvert.DeserializeObject<UserProfile>(response.Content);
        }

        
        public async Task<List<UserProfile>> GetAllUsersAsync()
        {
            var request = new RestRequest("api/userprofiles", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return new List<UserProfile>();
            return JsonConvert.DeserializeObject<List<UserProfile>>(response.Content) ?? new List<UserProfile>();
        }


      
        public async Task<bool> TransferMoneyAsync(int fromAccount, int toAccount, decimal amount, string description)
        {
            var withdraw = new Transactions
            {
                AccountNumber = fromAccount,
                TransactionType = "Withdrawal",
                Amount = amount,
                Date = DateTime.Now,
                UserId = fromAccount, 
                Description = description
            };

            var deposit = new Transactions
            {
                AccountNumber = toAccount,
                TransactionType = "Deposit",
                Amount = amount,
                Date = DateTime.Now,
                UserId = toAccount, 
                Description = description
            };

            var r1 = await _client.ExecuteAsync(new RestRequest("api/transactions", Method.Post).AddJsonBody(withdraw));
            var r2 = await _client.ExecuteAsync(new RestRequest("api/transactions", Method.Post).AddJsonBody(deposit));

            return r1.IsSuccessful && r2.IsSuccessful;
        }
    }
}
