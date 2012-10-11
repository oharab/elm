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
			
		}
		
		[Test]
		public void existing_and_checked_in_destination_succeeds()
		{
			given_destination_exists();
			given_destination_checked_in();
			Executing(()=>elm.Upload(source.Name,destination,string.Empty))
				.ShouldNotThrow()
				;
		}
		
		[Test]
		public void existing_but_not_checked_in_destination_throws_error()
		{
			given_destination_exists();
			given_destination_checked_out();
			Executing(()=>elm.Upload(source.Name,destination,string.Empty))
				.ShouldThrow<ElmException>();
		}
		
		
		[Test]
		public void destination_not_existing_throws()
		{
			given_destination_does_not_exist();
			Executing(()=>elm.Upload(source.Name,destination,string.Empty))
				.ShouldThrow<ElmException>();
		}
		
		
		
		
		
	}
}
