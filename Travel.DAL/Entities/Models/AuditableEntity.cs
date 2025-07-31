using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.DAL.Entities.Models
{
	public abstract class AuditableEntity
	{
		protected AuditableEntity()
		{
			CreatedOn = DateTime.UtcNow; 
			IsDeleted = false;
		}

		public string? CreatedBy { get; private set; }
		public DateTime? CreatedOn { get; private set; }
		public string? ModifiedBy { get; private set; }
		public DateTime? ModifiedOn { get; private set; }
		public DateTime? DeletedOn { get; private set; }
		public bool IsDeleted { get; private set; }

		 
		public void SetCreatedBy(string createdBy)
		{
			CreatedBy = createdBy;
		}

		public void SetModified(string? modifiedBy = null)
		{
			ModifiedBy = modifiedBy;
			ModifiedOn = DateTime.UtcNow;
		}

		public void SetDeleted(string? deletedBy = null)
		{
			DeletedOn = DateTime.UtcNow;
			ModifiedBy = deletedBy;
			ModifiedOn = DateTime.UtcNow;
			IsDeleted = true;
		}
	}
}
