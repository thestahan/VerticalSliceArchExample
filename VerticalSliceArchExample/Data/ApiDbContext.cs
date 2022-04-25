using Microsoft.EntityFrameworkCore;
using VerticalSliceArchExample.Domain;

namespace VerticalSliceArchExample.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}
