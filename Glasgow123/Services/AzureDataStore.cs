using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Glasgow123.Models;

namespace Glasgow123.Services
{
    public class AzureDataStore
    {
        HttpClient client;
        IEnumerable<UniversityClass> items;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<UniversityClass>();
        }

        public async Task<IEnumerable<UniversityClass>> GetItemsAsync(int studentId, bool forceRefresh = false)
        {
            if (forceRefresh)
            {
                var json = await client.GetStringAsync($"api/UniversityClass/enrolled?id={studentId}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<UniversityClass>>(json));
            }

            return items;
        }

        public async Task<Person> LoginAsync(string email, string password)
        {
            if (email != null && password != null)
            {
                var json = await client.GetStringAsync($"api/Person/login?email={email}&password={password}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Person>(json));
            }

            return null;
        }

        public async Task<UniversityClass> GetItemAsync(string id)
        {
            if (id != null)
            {
                var json = await client.GetStringAsync($"api/UniversityClass/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<UniversityClass>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(UniversityClass item)
        {
            if (item == null)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/UniversityClass", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddFeedbackAsync(Feedback feedback)
        {
            if (feedback == null)
                return false;

            var serializedItem = JsonConvert.SerializeObject(feedback);

            var response = await client.PostAsync($"api/Feedback", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(UniversityClass item)
        {
            if (item == null || item.Id == null)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/UniversityClass/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            var response = await client.DeleteAsync($"api/UniversityClass/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}