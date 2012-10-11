using System;
using Castle.Core.Logging;
using elm.Extensions;
using elm.Web;
using OpenFileSystem.IO;

namespace elm
{
	public class Elm
	{
		private readonly ISharepointService sharepointService;
		private ILogger log=NullLogger.Instance;
		
		public ILogger Log {
			get { return log; }
			set { log = value; }
		}
		
		public Elm(ISharepointService sharepointService)
		{
			this.sharepointService=sharepointService;
		}
		
		public ElmResponse Upload(IFile source, Uri destination,string checkInComments)
		{
			log.DebugFormat("Upload of '{0}' to '{1}' beginning.",source.Name,destination.AbsoluteUri);
			ElmResponse r=new ElmResponse();
			try{
				sharepointService.CheckOutFile(destination,false,DateTime.Now);
				sharepointService.UploadFile(destination,source.ToByteArray());
				sharepointService.CheckInFile(destination,checkInComments,CheckInType.CheckinMajorVersion);
				r.Status=Status.Ok;
			}catch(Exception ex){
				log.ErrorFormat(ex,"Error uploading File.");
				throw new ElmException();
			}
			
			return r;
			
		}
	}
}
