
using System;

namespace elm.Web
{
	public interface IListsWSSSOAPService
	{
		bool CheckInFile(string pageUrl, string comment, string CheckinType);
		bool CheckOutFile(string pageUrl, string checkoutToLocal, string lastmodified);
	}
}
