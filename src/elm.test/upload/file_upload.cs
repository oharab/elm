using System;
using System.IO;
using elm.Web;
using Moq;
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
		private Mock<ISharepointService> sharepointservice;
				
		protected override void BeforeExecuting()
		{
			elm=new Elm(sharepointservice.Object,filesystem);
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
			
		}
		
		public void given_destination_exists()
		{
			
		}
		public void given_destination_does_not_exist()
		{
			
		}
		
		public void given_destination_checked_out()
		{
			
		}
	}
}
