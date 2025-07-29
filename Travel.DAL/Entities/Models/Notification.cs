using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class Notification : AuditableEntity
	{
		public Notification() { }

		public Notification(int userId, NotificationType type, int relatedId, string message)
		{
			UserId = userId;
			Type = type;
			RelatedId = relatedId;
			Message = message;
			IsRead = false;
		}

		[Key]
		public int NotificationId { get; private set; }

		[ForeignKey("User")]
		public int UserId { get; private set; }

		public NotificationType Type { get; private set; }

		public int RelatedId { get; private set; }

		[Required]
		public string Message { get; private set; }

		public bool IsRead { get; private set; }

	 
		public virtual User User { get; private set; }

	 
		public void MarkAsRead()
		{
			IsRead = true;
		}
	}
}
