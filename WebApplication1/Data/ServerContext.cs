using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Models.Games;
using Server.Models.Queries_Models;

namespace Server.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options)
       : base(options)
        {
        }

        public DbSet<Player> Player { get; set; } = default!;

        public DbSet<Server.Models.Games.Game> Game { get; set; } = default!;

        public DbSet<Server.Models.Queries_Models.Q2> Q2 { get; set; } = default!;

    }
}
