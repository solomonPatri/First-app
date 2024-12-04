using first_app.users;
using Microsoft.EntityFrameworkCore;

namespace first_app.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }

        public virtual DbSet<User> Users
        {
            get;
            set;
        }

    }
}
