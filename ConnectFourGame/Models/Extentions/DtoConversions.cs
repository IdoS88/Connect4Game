using Client.Models.Dtos;

using System.Collections.Generic;
using System.Linq;

namespace Client.Models.Extentions
{
    public static class DtoConversions
    {
        public static IEnumerable<PlayerDTO> ConvertToDtos(this IEnumerable<Player> players)
        {
            return players.Aggregate(new List<PlayerDTO>(), (list, player) =>
            {
                list.Add(player.ToDto());
                return list;
            });

        }
        public static IEnumerable<Player> ConvertToPlayers(this IEnumerable<PlayerDTO> players)
        {
            return players.Aggregate(new List<Player>(), (list, player) =>
            {
                list.Add(player.ToPlayer());
                return list;
            });

        }

        //public static IEnumerable<GameDTO> ConvertToDtos(this IEnumerable<Game> games)
        //{
        //    return games.Aggregate(new List<GameDTO>(), (list, game) =>
        //    {
        //        list.Add(game.ToDto());
        //        return list;
        //    });
        //}

        public static IEnumerable<Game> ConvertToGames(this IEnumerable<GameDTO> games)
        {
            return games.Aggregate(new List<Game>(), (list, game) =>
            {
                list.Add(game.ToGame());
                return list;
            });

        }
        public static PlayerDTO ToDto(this Player player)
        {
            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Phone = player.Phone,
                CountrySelection = player.CountrySelection,
            };
        }

        public static Player ToPlayer(this PlayerDTO playerDto)
        {
            return new Player
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Phone = playerDto.Phone,
                CountrySelection = playerDto.CountrySelection,
            };
        }

        public static GameDTO ToDto(this GameRecords game, string status)
        {
            return new GameDTO
            {
                GameId = 0,
                PlayerId = game.PlayerID,
                DateInit = game.StartTime,
                TimePlayed = game.Duration,
                GameStatus = status,
            };
        }
        public static UpdateGameDTO ToPatchDto(this Game game)
        {
            return new UpdateGameDTO
            {
                GameId = game.GameId,
                GameStatus = game.GameStatus,
                TimePlayed = game.TimePlayed,
                PlayerId = game.PlayerId,
            };
        }

        public static Game ToGame(this GameDTO gameDto)
        {
            return new Game
            {
                GameId = gameDto.GameId,
                GameStatus = gameDto.GameStatus,
                PlayerId = gameDto.PlayerId,
                DateInit = gameDto.DateInit,
                TimePlayed = gameDto.TimePlayed
            };
        }
        public static Game ToGame(this UpdateGameDTO gameDto)
        {
            return new Game
            {
                GameId = gameDto.GameId,
                GameStatus = gameDto.GameStatus,
                PlayerId = gameDto.PlayerId,
                TimePlayed = gameDto.TimePlayed
            };
        }
        /*
        public static IEnumerable<PlayerDTO> ConvertToDtos(this IEnumerable<Player> players)
        {
            return players.Aggregate(new List<PlayerDTO>(), (list, player) =>
            {
                list.Add(player.ToDto());
                return list;
            });

        }
        public static IEnumerable<Player> ConvertToPlayers(this IEnumerable<PlayerDTO> players)
        {
            return players.Aggregate(new List<Player>(), (list, player) =>
            {
                list.Add(player.ToPlayer());
                return list;
            });

        }

        //public static IEnumerable<GameDTO> ConvertToDtos(this IEnumerable<Game> games)
        //{
        //    return games.Aggregate(new List<GameDTO>(), (list, game) =>
        //    {
        //        list.Add(game.ToDto());
        //        return list;
        //    });
        //}

        public static IEnumerable<Game> ConvertToGames(this IEnumerable<GameDTO> games)
        {
            return games.Aggregate(new List<Game>(), (list, game) =>
            {
                list.Add(game.ToGame());
                return list;
            });

        }
        public static PlayerDTO ToDto(this Player player)
        {
            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Phone = player.Phone,
                CountrySelection = player.CountrySelection,
            };
        }

        public static Player ToPlayer(this PlayerDTO playerDto)
        {
            return new Player
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Phone = playerDto.Phone,
                CountrySelection = playerDto.CountrySelection,
            };
        }

        public static GameDTO ToDto(this GameRecords game, string status)
        {
            return new GameDTO
            {
                GameId = 0,
                PlayerId = game.PlayerID,
                DateInit = game.StartTime,
                TimePlayed = game.Duration,
                GameStatus = status,
            };
        }
        public static UpdateGameDTO ToPatchDto(this Game game)
        {
            return new UpdateGameDTO
            {
                GameId = game.GameId,
                GameStatus = game.GameStatus,
                TimePlayed = game.TimePlayed,
                PlayerId = game.PlayerId,
            };
        }

        public static Game ToGame(this GameDTO gameDto)
        {
            return new Game
            {
                GameId = gameDto.GameId,
                GameStatus = gameDto.GameStatus,
                PlayerId = gameDto.PlayerId,
                DateInit = gameDto.DateInit,
                TimePlayed = gameDto.TimePlayed
            };
        }
        public static Game ToGame(this UpdateGameDTO gameDto)
        {
            return new Game
            {
                GameId = gameDto.GameId,
                GameStatus = gameDto.GameStatus,
                PlayerId = gameDto.PlayerId,
                TimePlayed = gameDto.TimePlayed
            };
        }
        */
    }
}
