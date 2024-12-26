using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
>>>>>>> origin/testBranch

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

<<<<<<< HEAD
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBContext>();
=======
/*builder.Services.AddDefaultIdentity<IdentityUser>(options=> options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>(); */ 
builder.Services.AddDefaultIdentity<IdentityUser>() // remove option that can only signin if email is confirmed
    .AddEntityFrameworkStores<ApplicationDBContext>();
>>>>>>> origin/testBranch
/*builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();*/
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages(); 
app.MapControllerRoute(
    name: "default",
    /*pattern: "{controller=Home}/{action=Index}/{id?}");*/
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
