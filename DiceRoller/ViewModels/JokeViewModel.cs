using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiceRoller.ViewModels
{
    class JokeViewModel
    {
        public static async Task<Models.Joke> GetJokeAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "YifQM+1DEuzvlRYdF8nVmg==5HogpNKqW5aXulY3");
            Models.Joke joke = null;
            HttpResponseMessage response = await client.GetAsync("v1/chucknorris");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                joke = JsonSerializer.Deserialize<Models.Joke>(responseString);
            }
            return joke;
        }
    }
}
