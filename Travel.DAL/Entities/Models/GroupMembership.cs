using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
    public class GroupMembership : AuditableEntity
    {
        public GroupMembership() { }

		public GroupMembership(int userId, int groupId, GroupRole role = GroupRole.Member)
		{
			UserId = userId;
			GroupId = groupId;
			Role = role;
			JoinedAt = DateTime.UtcNow;
		}

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[ForeignKey("Group")]
		public int GroupId { get; private set; }

		public DateTime JoinedAt { get; private set; }

		public GroupRole Role { get; private set; }

		
		public virtual User User { get; private set; }
		public virtual Group Group { get; private set; }

		
		public void ChangeRole(GroupRole role)
		{
			Role = role;
		}
	}
}
