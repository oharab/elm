using System;

namespace elm.Web
{
	public enum Status
	{
		Ok=200,
		DestinationNotFound=404,
		ServerError=500,
		UnknownError= -1
	}
}
