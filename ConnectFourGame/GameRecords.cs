using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class GameRecords
    {
        

        public int GameRecordId { get; set; }
        public string PlayerName { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string GameMoves { get; set; }
        // Add any other necessary properties for game details

        public static List<GameRecords> GetGameRecords(string connectionString) 
        {
            List<GameRecords> gameRecords = new List<GameRecords>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT GameRecordId, PlayerName, StartTime, Duration, GameMoves FROM GameRecords";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GameRecords gameRecord = new GameRecords
                            {
                                GameRecordId = (int)reader["GameRecordId"],
                                PlayerName = (string)reader["PlayerName"],
                                StartTime = (DateTime)reader["StartTime"],
                                Duration = (int)reader["Duration"],
                                GameMoves = (string)reader["GameMoves"]
                            };
                            gameRecords.Add(gameRecord);
                        }
                    }
                }
            }

            return gameRecords;
        }


    }
}
