using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Models;
using Client.Models.Dtos;
using Client.Models.Extentions;

namespace Client.Services
{
    internal class PlayerService : IPlayerService
    {
        private static HttpClient httpClient;

        public PlayerService(Uri url)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Connection Successful");
        }
        public async Task<Player> GetPlayer(int id)
        {
            string path = $"api/Players/{id}";
            try
            {
                var response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    var item = await response.Content.ReadAsAsync<PlayerDTO>();
                    var gameDto = item;
                    if (gameDto != null)
                    {
                        return gameDto.ToPlayer();
                    }

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null; 

        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            string path = "api/Players";

            try
            {
                var response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Player>().ToList();
                    }
                    var items = await response.Content.ReadAsAsync<IEnumerable<PlayerDTO>>();
                    return items.Where(p => p != null).Select(p => p.ToPlayer());
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
