using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public class Follow  // this is a table to link users like it is user_to_user  
	{
		public Follow() { }

		public Follow(int followerId, int followeeId)
		{
			FollowerId = followerId;
			FolloweeId = followeeId;
			FollowedAt = DateTime.UtcNow;
		}

		[ForeignKey("Follower")]
		public int FollowerId { get; private set; }

		[ForeignKey("Followee")]
		public int FolloweeId { get; private set; }

		public DateTime FollowedAt { get; private set; }

		
		public virtual User Follower { get; private set; }
		public virtual User Followee { get; private set; }
	}
}
