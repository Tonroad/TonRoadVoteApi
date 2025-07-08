using Microsoft.EntityFrameworkCore;
using TonRoadVoteApi.Models;

namespace TonRoadVoteApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Vote> Votes { get; set; }
	}
}

