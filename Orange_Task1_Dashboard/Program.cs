using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Orange_Task1_Dashboard.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
					   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

// Add Identity with roles support
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
	options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add this line

var app = builder.Build();

// Seed roles and a default manager user
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await SeedData.Initialize(services);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Ensure this is included

app.Run();
