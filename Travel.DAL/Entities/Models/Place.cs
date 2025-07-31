using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Place : AuditableEntity
	{

		public Place()
		{
			TripPlaces = new List<TripPlace>();
			Reviews = new List<Review>();
		}

		public Place(string name, string city, string country, string? description = null,
					 double? latitude = null, double? longitude = null, PlaceType placeType = PlaceType.Other)
		{
			Name = name;
			City = city;
			Country = country;
			Description = description;
			Latitude = latitude;
			Longitude = longitude;
			PlaceType = placeType;

			TripPlaces = new List<TripPlace>();
			Reviews = new List<Review>();
		}
		[Key]
		public int PlaceId { get; private set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; private set; }

		[Required]
		[MaxLength(100)]
		public string City { get; private set; }

		[Required]
		[MaxLength(100)]
		public string Country { get; private set; }

		public string? Description { get; private set; }

		public double? Latitude { get; private set; }

		public double? Longitude { get; private set; }

		public PlaceType PlaceType { get; private set; }


		public virtual ICollection<TripPlace> TripPlaces { get; private set; }
		public virtual ICollection<Review> Reviews { get; private set; }
	}
}
