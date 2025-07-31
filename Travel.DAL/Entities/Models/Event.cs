using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using Travel.DAL.DataBase;

namespace Travel.DAL.Entities.Models
{
	public class Event : AuditableEntity  // this is an event planned by groups so we need groupid , name , location , event date
    {
		

		public Event(int groupId, string city, string country, string name, string location, DateTime eventDate, string? description = null)
		{
			GroupId = groupId;
			Name = name;
            City = city;
            Country = country;
            EventDate = eventDate;
			Description = description;
		}

		[Key]
		public int Id { get; private set; }

		[ForeignKey("Group")]
		public int GroupId { get; private set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; private set; }

		[Required]
		[MaxLength(100)]
        public string City { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; private set; }

        public DateTime EventDate { get; private set; }

		public string? Description { get; private set; }

		 
		public virtual Group Group { get; private set; }


        public void UpdateEvent(string name, string city, string country, DateTime eventDate, string? description = null)
        {
            Name = name;
            City = city;
            Country = country;
            EventDate = eventDate;
            Description = description;
        }

    }
}
