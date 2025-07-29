
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
 
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class User : AuditableEntity
	{
		public User()
		{
			Posts = new List<Post>();
			Trips = new List<Trip>();
			Followers = new List<Follow>();
			Following = new List<Follow>();
			GroupMemberships = new List<GroupMembership>();
			CreatedGroups = new List<Group>();
		 
			Notifications = new List<Notification>();
		}

		public User(string username, string email, string passwordHash, string? bio = null,
					string? profilePicUrl = null, TravelState travelState = TravelState.NotTravelling)
		{
			//Username = username;
			//Email = email;
			//PasswordHash = passwordHash;
			Bio = bio;
			ProfilePicUrl = profilePicUrl;
			TravelState = travelState;



			Posts = new List<Post>();
			Trips = new List<Trip>();
			Reviews = new List<Review>();
			Comments = new List<Comment>();
			Likes = new List<Like>();
			Followers = new List<Follow>();
			Following = new List<Follow>();
			GroupMemberships = new List<GroupMembership>();
			CreatedGroups = new List<Group>();
		 
			Notifications = new List<Notification>();
		}

		[Key]
		public int UserId { get; private set; }

		//[Required]
		//[MaxLength(50)]
		//public string Username { get; private set; }

		//[Required]
		//[MaxLength(100)]
		//public string Email { get; private set; }

		//[Required]
		//public string PasswordHash { get; private set; }

		[MaxLength(500)]
		public string? Bio { get; private set; }

		public string? ProfilePicUrl { get; private set; }

		public TravelState TravelState { get; private set; }






		public virtual ICollection<Post>? Posts { get; private set; }
		public virtual ICollection<Trip>? Trips { get; private set; }
		public virtual ICollection<Review>? Reviews { get; private set; }
		public virtual ICollection<Comment>? Comments { get; private set; }
		public virtual ICollection<Like>? Likes { get; private set; }
		public virtual ICollection<Follow>? Followers { get; private set; }
		public virtual ICollection<Follow>? Following { get; private set; }
		public virtual ICollection<GroupMembership>? GroupMemberships { get; private set; }
		public virtual ICollection<Group>? CreatedGroups { get; private set; }
		 
		public virtual ICollection<Notification>? Notifications { get; private set; }

		public void UpdateProfile(string? bio, string? profilePicUrl)
		{
			Bio = bio;
			ProfilePicUrl = profilePicUrl;
		}

		public void ChangeTravelState(TravelState newState)
		{
			TravelState = newState;
		}
	}

}
