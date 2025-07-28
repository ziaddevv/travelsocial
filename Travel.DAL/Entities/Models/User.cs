using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DAL.Entities.Enums;

namespace Travel.DAL.Entities.Models
{
	public class User
	{
	    public User() { }

		public User(string? bio=null,  TravelState travel = TravelState.NotTravelling, string? createdBy = null,string ? profileImage=null)
		{
			BIO = bio;
			ProfileImage = profileImage;
			TravelState = travel;
			CreatedBy = createdBy;
			CreatedOn = DateTime.Now;
			IsDeleted = false;

		}

		public int Id { get; private set; }
		// name --> first + last
		// email
		// password
		// bio
		public string? BIO {  get; private set; }
        public string? ProfileImage { get; private set; }
        public  TravelState TravelState { get; private set; }//not traverllign default
		public string? CreatedBy { get; private set; }
		public DateTime? CreatedOn { get; private set; }
		public string? ModifiedBy { get; private set; }
		public DateTime? ModifiedOn { get; private set; }
		public DateTime? DeletedOn { get; private set; }

		public bool IsDeleted { get; private set; }
        

		//

	}
}
