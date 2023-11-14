using Microsoft.EntityFrameworkCore;
using TokenPlusMongo.Entities;

namespace TokenPlusMongo.Data
{
    public class TokenComboDb : DbContext
    {
        public TokenComboDb(DbContextOptions<TokenComboDb> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
