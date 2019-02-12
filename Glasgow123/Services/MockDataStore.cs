using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glasgow123.Models;

namespace Glasgow123.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            // Create students
            var students = new List<Student>
            {
                new Student { Id = Guid.NewGuid().ToString(), Name = "Abraham", Surname="Lincoln" },
                new Student { Id = Guid.NewGuid().ToString(), Name = "Helen", Surname="Keller" },
                new Student { Id = Guid.NewGuid().ToString(), Name = "David", Surname="Beckham" },
                new Student { Id = Guid.NewGuid().ToString(), Name = "Maria", Surname="Sharapova" },
                new Student { Id = Guid.NewGuid().ToString(), Name = "Pablo", Surname="Picasso" },
                new Student { Id = Guid.NewGuid().ToString(), Name = "Mariah", Surname="Carey" },
            };

            // Create classes
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Youth, Policy and Welfare: Cross-Cultural Perspectives", Description="Semester 1", Students=students },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Social & Public Policy 1A", Description="Semester 1", Students=students },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Social and Public Policy 2B: Policy, Politics and Power", Description="Semester 2", Students=students },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Health Policy", Description="Semester 2", Students=students },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Social and Public Policy 1B: Understanding Glasgow in a Globalised World", Description="Semester 2", Students=students },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Utopias: Welfare Theory and Social Policies for a \"Good Society\" ", Description="Semester 2", Students=students },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}