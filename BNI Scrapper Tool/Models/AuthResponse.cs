using System.Collections.Generic;

namespace  Devil7.Automation.BNI.Scrapper.Models
{
	public class AuthResponse
	{
		public Error error { get; set; }

		public class ApiError
		{
			public string errorCode { get; set; }
			public string message { get; set; }
		}

		public class Error
		{
			public string type { get; set; }
			public IList<ApiError> apiErrors { get; set; }
		}

	}
}
