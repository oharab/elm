using System;
using System.IO;
using OpenFileSystem.IO;
using OpenFileSystem.IO.FileSystems.InMemory;

namespace elm.test.upload
{
	public abstract class file_upload:context
	{
		protected IFile source;
		protected Uri destination;
	    protected bool destination_checked_in;
		protected Elm elm;
		protected ElmResponse response;
		
		private IFileSystem filesystem=new InMemoryFileSystem();
		
		public file_upload(){
			elm=new Elm();
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
			destination_checked_in=true;
		}
		public void on_upload(){
			response=elm.Upload(source,destination);
		}
			
	}
}
