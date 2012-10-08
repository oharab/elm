
using System;
using elm.Web;

namespace elm.test
{
	/// <summary>
	/// Description of DumbSharepointService.
	/// </summary>
	public class DumbSharepointService:ISharepointService
	{
		public bool DestinationExists { get; set; }
		public bool DestinationIsCheckedIn { get; set; }
		
		
		public bool CheckInFile(Uri pageUrl, string commment, CheckInType checkInType)
		{
			if(DestinationExists && !DestinationIsCheckedIn)
			{
				DestinationIsCheckedIn=true;
				return true;
			}
			else
			{
				throw new Exception();
			}
		}
		
		public bool CheckOutFile(Uri pageUrl, bool checkedOutToLocal, DateTime lastModified)
		{
			if(DestinationExists && DestinationIsCheckedIn)
			{
				DestinationIsCheckedIn=false;
				return true;
			}
			else
			{
				throw new Exception();
			}

		}
		
		public bool IsCheckedOut(Uri pageUrl)
		{
			return !DestinationIsCheckedIn;
		}
		
		public bool FileExists(Uri pageUrl)
		{
			return DestinationExists;
		}
	}
}
