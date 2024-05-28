using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
	public RepositoryContext(DbContextOptions options) : base(options)
	{


	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new PostConfiguration());
		modelBuilder.ApplyConfiguration(new LikeConfiguration());
		modelBuilder.ApplyConfiguration(new UserFollowedConfiguration());

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<UserFollowed> UsersFollowed => Set<UserFollowed>();

}
