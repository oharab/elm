
using System;
using NUnit.Framework;

namespace elm.test.extensions
{
	public static class test_extensions
	{
		public static T ShouldThrow<T>(this Action codeToExecute) where T : Exception
		{
			try
			{
				codeToExecute();
			}
			catch (Exception e)
			{
				if (!typeof(T).IsInstanceOfType(e))
					Assert.Fail("Expected exception of type \"{0}\" but got \"{1}\" instead.",
					            typeof(T).Name,
					            e.GetType().Name);
				else
					return (T)e;
			}
			Assert.Fail("Expected an exception of type \"{0}\" but none were thrown.", typeof(T).Name);
            return null; // this never happens as Fail will throw...
		}
	}
}