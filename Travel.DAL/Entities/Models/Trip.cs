using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Trip : AuditableEntity
	{
        public Trip(string title, string description, double totalCost, DateTime start, DateTime end,
                TransportationMethod transportation = TransportationMethod.Bus)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Start = start;
            End = end;
            Transportation = transportation;
            IsCompleted = false;
        }


        public void UpdateTrip(bool isCompleted,string title, string description, double totalCost, DateTime start, DateTime end, TransportationMethod transportationMethod)
        {
            this.IsCompleted = isCompleted;
            this.Title = title;
            this.Description = description;
            this.TotalCost = totalCost;
            this.Start = start;
            this.End = end;
            this.Transportation = transportationMethod;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Double TotalCost { get; private set; }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TransportationMethod Transportation { get; private set; }
        public bool IsCompleted { get; private set; }

        public ICollection<Place> Places { get; private set; } = new List<Place>(); // Collection Navigation	
    }
}
