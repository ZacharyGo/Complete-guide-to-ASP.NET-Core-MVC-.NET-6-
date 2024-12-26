
using BulkyBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess;
<<<<<<< HEAD

public class ApplicationDBContext : IdentityDbContext
=======
public class ApplicationDBContext :IdentityDbContext
>>>>>>> origin/testBranch
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories {  get; set; }
    public DbSet<CoverType> CoverTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Company> Companies { get; set; }
}
