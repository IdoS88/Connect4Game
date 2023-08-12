﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientModels
{
    public class Game
    {
     
        public int PlayerId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        public DateTime DateInit { get; set; }

        public int TimePlayed { get; set; }

        public string GameStatus { get; set; } = "In Progress";
        // Player, Computer, Draw, In Progress

    }
}
