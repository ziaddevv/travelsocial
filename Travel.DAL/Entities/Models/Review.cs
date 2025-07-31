using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public class Review : AuditableEntity
	{
        public Review(double rate, string text, Place place)
        {
            Rate = rate;
            Text = text;
            Place = place;
            PlaceId = place.Id; // set FK explicitly
        }

        public void UpdateReview(double rate, string text) 
        {
            this.Rate = rate;
            this.Text = text;
        }
        public int Id { get; set; }
        public double Rate { get; set; }
        public required string Text { get; set; }
        public int PlaceId { get; set; } // Foreign key
        public required Place Place { get; set; } // Reference Navigation	
    }
}
