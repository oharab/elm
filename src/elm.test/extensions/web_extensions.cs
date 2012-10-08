using System;
using elm.Web;
using NUnit.Framework;

namespace elm.test.extensions
{

	public static class web_extensions
	{
		public static void Is(this Status actual,Status expected){
			Assert.AreEqual(expected,actual);
		}
	}
}
