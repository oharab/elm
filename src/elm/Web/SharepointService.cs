
using System;
using Castle.Core.Logging;

namespace elm.Web
{
	/// <summary>
	/// Description of SharepointService.
	/// </summary>
	public class SharepointService:ISharepointService
	{
		private ILogger log=NullLogger.Instance;
		
		public ILogger Log {
			get { return log; }
			set { log = value; }
		}
		
		private readonly ICopyWSSSOAPService copyService;
		private readonly IListsWSSSOAPService listsService;
		public SharepointService(ICopyWSSSOAPService copyService,IListsWSSSOAPService listsService)
		{
			this.copyService=copyService;
			this.listsService=listsService;
		}
		
		public bool CheckInFile(Uri pageUrl, string commment, CheckInType checkInType)
		{
			return this.listsService.CheckInFile(pageUrl.AbsoluteUri,commment,((int)checkInType).ToString());
		}
		
		public bool CheckOutFile(Uri pageUrl, bool checkedOutToLocal, DateTime? lastModified)
		{
			string lastModifiedDateString=string.Empty;
			if(lastModified!=null)
				lastModifiedDateString=((DateTime)lastModified).ToUniversalTime().ToString ("R");
			
			return this.listsService.CheckOutFile(pageUrl.AbsoluteUri,checkedOutToLocal.ToString(),
			                                      lastModifiedDateString
			                                      
			                                     );
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
