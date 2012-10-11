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
		private readonly IFileSystem fileSystem;
		public ILogger Log {
			get { return log; }
			set { log = value; }
		}
		
		public Elm(ISharepointService sharepointService,IFileSystem fileSystem)
		{
			this.sharepointService=sharepointService;
			this.fileSystem=fileSystem;
			
		}
		
		public ElmResponse Upload(string source, Uri destination,string checkInComments)
		{
			log.DebugFormat("Upload of '{0}' to '{1}' beginning.",source,destination.AbsoluteUri);
			ElmResponse r=new ElmResponse();
			try{
				IFile sourceFile=fileSystem.GetFile(source);
				sharepointService.CheckOutFile(destination,false,null);
				sharepointService.UploadFile(destination,sourceFile.ToByteArray());
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
