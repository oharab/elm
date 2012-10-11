using System;

namespace elm.Web
{
	public enum Status
	{
		Ok,
		DestinationNotFound,
		UnableToCheckOutDestination,
		UploadFailed,
		DiscardCheckoutFailed,
		CheckInFailed,
		UnknownError= -1
	}
}
