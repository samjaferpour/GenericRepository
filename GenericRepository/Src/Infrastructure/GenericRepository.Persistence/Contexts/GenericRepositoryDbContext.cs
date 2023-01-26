using GenericRepository.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Persistence.Contexts
{
    public class GenericRepositoryDbContext : DbContext
    {
        public GenericRepositoryDbContext(DbContextOptions<GenericRepositoryDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
