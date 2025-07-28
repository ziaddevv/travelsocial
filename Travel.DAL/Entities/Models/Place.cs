using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Place
	{
        public Place(string name, string description, string country, string city, PlaceType placeType = PlaceType.General)
        {
            Name = name;
            Description = description;
            PlaceType = placeType;
            Country = country;
            City = city;
        }

        public int Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public PlaceType PlaceType { get; private set; }
		public string Country { get; private set; }
		public string City { get; private set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
