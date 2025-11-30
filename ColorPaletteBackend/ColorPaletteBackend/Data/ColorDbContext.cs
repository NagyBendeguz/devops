using ColorPaletteBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorPaletteBackend.Data
{
    public class ColorDbContext: DbContext
    {
        public DbSet<Color> Colors { get; set; }

        public ColorDbContext(DbContextOptions<ColorDbContext> ctx) : base(ctx)
        {
            
        }
    }
}
