using Microsoft.EntityFrameworkCore;
using SocialAppAPI.Entities;

namespace SocialAppAPI.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users {  get; set; }
    }
}
