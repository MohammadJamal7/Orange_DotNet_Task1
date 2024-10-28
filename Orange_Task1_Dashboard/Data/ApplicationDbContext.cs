using DotNet_Orange_Task1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Orange_Task1_Dashboard.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		public DbSet<Department> Departments { get; set; }	
		public DbSet<Employee> Employees { get; set; }
		public DbSet<DotNet_Orange_Task1.Models.Task> Tasks { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
	}
}
