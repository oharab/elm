/*
 * User: 721116
 * Date: 08/10/2012
 * Time: 11:39
 * 
 *  */
using System;
using elm.test.extensions;
using elm.Web;
using NUnit.Framework;

namespace elm.test.upload
{
	/// <summary>
	/// Description of simple_file_upload.
	/// </summary>
	public class simple_file_upload:file_upload
	{
		public simple_file_upload()
		{
			given_source("testfile.txt","This is a new file");
			given_destination("http://example.com/sites/testfile.txt".ToUri(),"This is an old file.");
			given_destination_checked_in();
			on_upload();
		}
		
		[Test]
		public void upload_completes()
		{
			response.Status.Is(Status.Ok);
		}
		
		[Test]
		public void file_contents_are_updated()
		{
			
		}
		
		[Test]
		public void file_is_checked_in()
		{
			
		}
		
		
		
	}
}
