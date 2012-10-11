﻿using System;
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
			
			try{
				if(!sharepointService.FileExists(destination))
					return new ElmResponse{Status=Status.DestinationNotFound};
				if(!sharepointService.CheckOutFile(destination,false,null))
				   return new ElmResponse{Status= Status.UnableToCheckOutDestination};
				IFile sourceFile=fileSystem.GetFile(source);
				if(!sharepointService.UploadFile(destination,sourceFile.ToByteArray()))
				{
					if(sharepointService.DiscardCheckout(destination))
						return new ElmResponse{Status= Status.UploadFailed};
					else
						return new ElmResponse{Status=Status.DiscardCheckoutFailed};
				}
				if(!sharepointService.CheckInFile(destination,checkInComments,CheckInType.CheckinMajorVersion))
				   return new ElmResponse{Status=Status.CheckInFailed};
				return new ElmResponse{Status=Status.Ok};
			}catch(Exception ex){
				log.ErrorFormat(ex,"Error uploading File.");
				return new ElmResponse{Status=Status.UnknownError};
			}
		}
	}
}
