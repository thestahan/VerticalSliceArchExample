using Microsoft.EntityFrameworkCore;

namespace VerticalSliceArchExample.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
}
