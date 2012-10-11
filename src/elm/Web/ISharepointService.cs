
using System;

namespace elm.Web
{
	public interface ISharepointService
	{
		bool CheckInFile(Uri pageUrl,string commment,CheckInType checkInType);
		bool CheckOutFile(Uri pageUrl,bool checkedOutToLocal,DateTime? lastModified);
		bool DiscardCheckout(Uri destination);
		
		bool IsCheckedOut(Uri pageUrl);
		
		bool FileExists(Uri pageUrl);
		
		bool UploadFile(Uri destination,byte[] source);
		
		
	}
}
