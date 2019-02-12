using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Glasgow123.Models;

namespace Glasgow123.Services
{
    public interface IDataStore<T>
    {
        Task<Person> LoginAsync(string email, string password);
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(int studentId, bool forceRefresh = false);
    }
}
