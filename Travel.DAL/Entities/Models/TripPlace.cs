using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public class TripPlace
	{
		public TripPlace() { }

		public TripPlace(int tripId, int placeId, int sequenceNumber)
		{
			TripId = tripId;
			PlaceId = placeId;
			SequenceNumber = sequenceNumber;
		}

		[ForeignKey("Trip")]
		public int TripId { get; private set; }

		[ForeignKey("Place")]
		public int PlaceId { get; private set; }

		public int SequenceNumber { get; private set; } // order of the place in trip

		public virtual Trip Trip { get; private set; }
		public virtual Place Place { get; private set; }
	}
}
