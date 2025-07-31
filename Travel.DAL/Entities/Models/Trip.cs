

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Travel.DAL.Entities.Models
{
	public class Trip : AuditableEntity
	{
		public Trip()
		{
			Posts = new List<Post>();
			TripPlaces = new List<TripPlace>();
			 
		}

		public Trip(int userId, string title, string? description = null, DateTime? startDate = null,
					DateTime? endDate = null, string? transportation = null, decimal? totalCost = null,
					bool isPublic = true, string? coverPhotoUrl = null)
		{
			UserId = userId;
			Title = title;
			Description = description;
			StartDate = startDate;
			EndDate = endDate;
			Transportation = transportation;
			TotalCost = totalCost;
			IsPublic = isPublic;
			CoverPhotoUrl = coverPhotoUrl;

			Posts = new List<Post>();
			TripPlaces = new List<TripPlace>();
			 
		}

		[Key]
		public int TripId { get; private set; }

		[ForeignKey("User")]
		public int UserId { get; private set; }

		[Required]
		[MaxLength(200)]
		public string Title { get; private set; }

		public string? Description { get; private set; }

		public DateTime? StartDate { get; private set; }

		public DateTime? EndDate { get; private set; }

		[MaxLength(100)]
		public string? Transportation { get; private set; }

		[Column(TypeName = "decimal(10,2)")]
		public decimal? TotalCost { get; private set; }

		public bool IsPublic { get; private set; }

		public string? CoverPhotoUrl { get; private set; }

		
		public virtual User User { get; private set; }
		public virtual ICollection<Post> Posts { get; private set; }
		public virtual ICollection<TripPlace> TripPlaces { get; private set; }
		 


		public void UpdateTrip(string title, string? description = null, DateTime? startDate = null,
							  DateTime? endDate = null, string? transportation = null, decimal? totalCost = null)
		{
			Title = title;
			Description = description;
			StartDate = startDate;
			EndDate = endDate;
			Transportation = transportation;
			TotalCost = totalCost;
		}

		public void SetPrivacy(bool isPublic)
		{
			IsPublic = isPublic;
		}




	}
}
