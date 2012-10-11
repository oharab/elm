using System;
using System.IO;
using elm.Web;
using OpenFileSystem.IO;
using OpenFileSystem.IO.FileSystems.InMemory;

namespace elm.test.upload
{
	public abstract class file_upload:context
	{
		protected IFile source;
		protected Uri destination;
		protected Elm elm;
		
		private IFileSystem filesystem=new InMemoryFileSystem();
		private DumbSharepointService sharepointservice;
		
		public file_upload(){
			sharepointservice=new DumbSharepointService();
			elm=new Elm(sharepointservice,filesystem);
		}
		
		public void given_source(string filename,string contents){
			source=filesystem.GetCurrentDirectory().GetFile(filename);
			using (var writer = new StreamWriter(source.OpenWrite()))
				writer.Write(contents);
		}
		
		public void given_destination(Uri uri,string contents){
			this.destination=uri;
		}
		
		public void given_destination_checked_in(){
			sharepointservice.DestinationIsCheckedIn=true;
		}
		
		public void given_destination_exists()
		{
			sharepointservice.DestinationExists=true;
		}
		public void given_destination_does_not_exist()
		{
			sharepointservice.DestinationExists=false;
		}
		
		public void given_destination_checked_out()
		{
			sharepointservice.DestinationIsCheckedIn=false;
		}
	}
}
