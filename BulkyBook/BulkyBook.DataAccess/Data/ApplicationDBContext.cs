
using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BulkyBook.DataAccess;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CoverType> CoverTypes { get; set; }
    public DbSet<Product> Products { get; set; }
}
