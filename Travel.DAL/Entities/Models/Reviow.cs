using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public class Review : AuditableEntity
	{
		public Review() { }

		public Review(int userId, int placeId, int rating, string? text = null)
		{
			UserId = userId;
			PlaceId = placeId;
			Rating = rating;
			Text = text;
		 
		}

		[Key]
		public int ReviewId { get; private set; }

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[ForeignKey("Place")]
		public int PlaceId { get; private set; }

		[Range(1, 5)]
		public int Rating { get; private set; }

		public string? Text { get; private set; }

		 
		public virtual User User { get; private set; }
		public virtual Place Place { get; private set; }

		 
		public void UpdateReview(int rating, string? text = null)
		{
			Rating = rating;
			Text = text;
		}
	}
}
