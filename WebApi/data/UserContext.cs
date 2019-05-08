using Microsoft.EntityFrameworkCore;
using WebApi.entity;

namespace WebApi.data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}