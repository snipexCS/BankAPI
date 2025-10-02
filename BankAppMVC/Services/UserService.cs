using RestSharp;
using BankAppMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAppMVC.Services
{
    public class UserService
    {
        private readonly string apiBaseUrl = "https://localhost:7276/api/UserProfiles";
  

        public async Task<List<UserModel>> GetUsers()
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = await client.ExecuteAsync<List<UserModel>>(request);
            return response.Data ?? new List<UserModel>();
        }

        public async Task<UserModel> GetUser(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync<UserModel>(request);
            return response.Data;
        }






        public async Task<UserModel> CreateUser(UserModel user)
        {
            var client = new RestClient(apiBaseUrl);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(user);
            var response = await client.ExecuteAsync<UserModel>(request);
            return response.Data;
        }

        public async Task<UserModel> UpdateUser(int id, UserModel user)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddJsonBody(user);
            var response = await client.ExecuteAsync<UserModel>(request);
            return response.Data;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var client = new RestClient($"{apiBaseUrl}/{id}");
            var request = new RestRequest();
            request.Method = Method.Delete;
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}
