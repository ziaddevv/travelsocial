using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Trip
	{
        public Trip(string title, string description, double totalCost, DateTime start, DateTime end,
                TransportationMethod transportation = TransportationMethod.Bus, string? createdBy=null)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Start = start;
            End = end;
            Transportation = transportation;
            CreatedAt = DateTime.Now;
            IsCompleted = false;
            CreatedBy = createdBy;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Double TotalCost { get; private set; }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TransportationMethod Transportation { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public bool IsCompleted { get; private set; }

        public string? CreatedBy { get; private set; }

        public ICollection<Place> Places { get; private set; } = new List<Place>();
    }
}
