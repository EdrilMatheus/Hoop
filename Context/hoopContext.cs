using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hoop.Model;

namespace hoop.Context
{
    public class hoopContext : DbContext
    {
        public hoopContext(DbContextOptions options) : base(options) { }

        public DbSet<Jogador>? Jogadores { get; set; }
        public DbSet<Time>? Times { get; set; }
        public DbSet<Pelada>? Peladas { get; set; }
    }
}