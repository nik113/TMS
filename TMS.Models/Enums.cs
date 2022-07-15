using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Models
{
	public enum StatusCode
	{
		WrongCredencial = 0,
		SessionExpired = 1,
		ValidationError = 2,
		UnAuthorized = 3,
		ServerError = 4
	}
}
