
using System;

namespace elm.Web
{
	/// <summary>
	/// Description of SharepointService.
	/// </summary>
	public class SharepointService:ISharepointService
	{
		private readonly ICopyWSSSOAPService copyService;
		private readonly IListsWSSSOAPService listsService;
		public SharepointService(ICopyWSSSOAPService copyService,IListsWSSSOAPService listsService)
		{
		}
		
		public bool CheckInFile(Uri pageUrl, string commment, CheckInType checkInType)
		{
			throw new NotImplementedException();
		}
		
		public bool CheckOutFile(Uri pageUrl, bool checkedOutToLocal, DateTime lastModified)
		{
			throw new NotImplementedException();
		}
		
		public bool IsCheckedOut(Uri pageUrl)
		{
			throw new NotImplementedException();
		}
		
		public bool FileExists(Uri pageUrl)
		{
			throw new NotImplementedException();
		}
		
		public bool UploadFile(Uri destination, byte[] source)
		{
			throw new NotImplementedException();
		}
	}
}
