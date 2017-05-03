using System;
using Newtonsoft.Json;
using Kinvey;

namespace PatientMonitor
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Patient : Entity
	{
		[JsonProperty("userID")]
		public string UserID { get; set; }

		[JsonProperty("firstName")]
		public string FirstName { get; set; }

		[JsonProperty("lastName")]
		public string LastName { get; set; }

		[JsonProperty("doctorID")]
		public string DoctorID { get; set; }
	}
}
