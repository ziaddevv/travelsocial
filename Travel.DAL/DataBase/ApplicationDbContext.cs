using Microsoft.EntityFrameworkCore;
using Travel.DAL.Entities.Models;

namespace Travel.DAL.DataBase
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() 
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Like>()
				.HasKey(l => new { l.UserId, l.PostId });
			modelBuilder.Entity<Follow>()
				.HasKey(f => new { f.FollowerId, f.FolloweeId });
			modelBuilder.Entity<TripPlace>()
				.HasKey(tp => new { tp.TripId, tp.PlaceId });
			modelBuilder.Entity<GroupMembership>()
				.HasKey(gm => new { gm.UserId, gm.GroupId });




			modelBuilder.Entity<Follow>()
			.HasOne(f => f.Follower)
			.WithMany(u => u.Following)
			.HasForeignKey(f => f.FollowerId)
			.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Follow>()
				.HasOne(f => f.Followee)
				.WithMany(u => u.Followers)
				.HasForeignKey(f => f.FolloweeId)
				.OnDelete(DeleteBehavior.ClientSetNull);


			modelBuilder.Entity<Comment>()
				.HasOne(c => c.ParentComment)
				.WithMany(c => c.Replies)
				.HasForeignKey(c => c.ParentCommentId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Post>()
				.HasOne(p => p.User)
				.WithMany(u => u.Posts)
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Post)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PostId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<GroupMembership>()
	        .HasOne(gm => gm.User)
	         .WithMany(u => u.GroupMemberships)
	       .HasForeignKey(gm => gm.UserId)
	      .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<GroupMembership>()
				.HasOne(gm => gm.Group)
				.WithMany(g => g.Members)
				.HasForeignKey(gm => gm.GroupId)
				.OnDelete(DeleteBehavior.Cascade);



			modelBuilder.Entity<Like>()
					.HasOne(l => l.User)
					.WithMany(u => u.Likes)
					.HasForeignKey(l => l.UserId)
					.OnDelete(DeleteBehavior.NoAction); 

			modelBuilder.Entity<Like>()
				.HasOne(l => l.Post)
				.WithMany(p => p.Likes)
				.HasForeignKey(l => l.PostId)
				.OnDelete(DeleteBehavior.Cascade);


					modelBuilder.Entity<Group>()
			  .HasOne(g => g.User)   
			  .WithMany(u => u.CreatedGroups)  
			  .HasForeignKey(g => g.CreatorId)  
			  .OnDelete(DeleteBehavior.Restrict);




		}

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Place> Places { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Like> Likes { get; set; }
		public DbSet<Follow> Follows { get; set; }
		public DbSet<TripPlace> TripPlaces { get; set; }
		 
		public DbSet<GroupMembership> GroupMemberships { get; set; }
		public DbSet<Notification> Notifications { get; set; }
	}
}