using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Models.Dtos;
using Client.Models;
using Client.Models.Extentions;

namespace Client.Services
{
    public class GameService : IGameService
    {
        private static HttpClient httpClient;

        public GameService(Uri url)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = url;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Uri> AddGame(GameDTO gameToAddDto)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
    "api/Games", gameToAddDto);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<int> GetComputerMove()
        {
            string path = "api/Games/GetComputerTurn";
            try
            {
                int computerMove = -1;
                HttpResponseMessage response = await httpClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {

                    computerMove = await response.Content.ReadAsAsync<int>();
                }
                Console.WriteLine("server returned " + computerMove);
                return computerMove;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        public async Task<Game> GetGame(int id)
        {
            string path = $"api/Games/{id}";
            try
            {
                var response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }
                    var items = await response.Content.ReadAsAsync<GameDTO>();
                    var gameDto = items;
                    if (gameDto != null)
                    {
                        return gameDto.ToGame();
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
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public Task<IEnumerable<Game>> GetGames()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Game>> GetGames(int userId)
        {
            string path = $"api/Games/GetGamesByUserId/{userId}";
            try
            {
                var response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Game>().ToList();
                    }
                    var items = await response.Content.ReadAsAsync<IEnumerable<GameDTO>>();
                    return items.ConvertToGames();
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


