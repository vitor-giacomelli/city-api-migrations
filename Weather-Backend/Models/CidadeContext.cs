using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Backend.Models
{
    public class CidadeContext : DbContext
    {
        public CidadeContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Cidade> Cidades{ get; set; }
    }
}
