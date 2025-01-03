using InfinityPages.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityPages.Context
{
    public class InfinityPagesContext : DbContext
    {
        public DbSet<Book> BookStore { get; set; }
        public InfinityPagesContext(DbContextOptions<InfinityPagesContext> options) : base(options) 
        { 
        }
    }
}
