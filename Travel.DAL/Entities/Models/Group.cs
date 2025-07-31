using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Group : AuditableEntity
	{
		public Group()
		{
			Members = new List<GroupMembership>();
			Events = new List<Event>();
		}

		public Group(string name, string? description, Privacy privacy)
		{
			Name = name;
			Description = description;
			Privacy = privacy;

			Members = new List<GroupMembership>();
			Events = new List<Event>();
		}

		[Key]
		public int GroupId { get; private set; }

		[ForeignKey("User")]
		public int CreatorId { get; private set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; private set; }

		public string? Description { get; private set; }

		public User User { get; private set; }
		public Privacy Privacy { get; private set; }
		public virtual ICollection<GroupMembership>? Members { get; private set; }
		public virtual ICollection<Event>? Events { get; private set; }

	 
		public void UpdateGroup(string name, string? description, Privacy privacy)
		{
			Name = name;
			Description = description;
			Privacy = privacy;
		}
	 
	}
}
