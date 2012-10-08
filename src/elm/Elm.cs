using System;
using elm.Extensions;
using elm.Web;
using OpenFileSystem.IO;

namespace elm
{
	public class Elm
	{
		private readonly ISharepointService sharepointService;
		
		public Elm(ISharepointService sharepointService)
		{
			this.sharepointService=sharepointService;
		}
		
		public ElmResponse Upload(IFile source, Uri destination,string checkInComments)
		{
			ElmResponse r=new ElmResponse();
			try{
				sharepointService.CheckOutFile(destination,false,DateTime.Now);
				sharepointService.UploadFile(destination,source.ToByteArray());
				sharepointService.CheckInFile(destination,checkInComments,CheckInType.CheckinMajorVersion);
				r.Status=Status.Ok;
			}catch(Exception){
				throw new ElmException();
			}
			
			return r;
			
		}
	}
}
