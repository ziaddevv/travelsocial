using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public class Review
	{
        public Review(double rate, string text, Place place)
        {
            Rate = rate;
            Text = text;
            Place = place;
            PlaceId = place.Id; // set FK explicitly
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public double Rate { get; set; }
        public required string Text { get; set; }
        public int PlaceId { get; set; } // Foreign key
        public required Place Place { get; set; } // Navigation

        
        public DateTime Date { get; set; }
    }
}
