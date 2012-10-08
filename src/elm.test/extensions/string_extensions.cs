/*
 * User: 721116
 * Date: 08/10/2012
 * Time: 11:44
 * 
 *  */
using System;

namespace elm.test.extensions
{

	
	public static class string_extensions
	{
		public static Uri ToUri(this string uri){
			Uri u;
			if(!Uri.TryCreate(uri,UriKind.Absolute, out u)) u=null;
			return u;
		}
	}
}
