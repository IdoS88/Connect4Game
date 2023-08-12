using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;


namespace IdoShamir_EyalCohen_Connect4.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options)
       : base(options)
        {
        }

        public DbSet<Player> Player { get; set; } = default!;

        public DbSet<Game> Game { get; set; } = default!;


    }
}
