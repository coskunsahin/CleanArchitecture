using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace MockProject2
{
    public class Posts
    {
        private readonly HttpClient httpClient;
        private const string url = "https://localhost:5001/api/Invoice";

        public Posts(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<JsonElement>> GetPosts()
        {
            var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(body);
            return posts;
        }

        public async Task<JsonElement> CreatePost(string title)
        {
            var payload = new
            {
                title
            };
            var httpContent = new StringContent(JsonSerializer.Serialize(payload));
            var response = await httpClient.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<JsonElement>(body);
            return created;
        }
    }
}