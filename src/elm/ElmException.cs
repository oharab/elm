
using System;
using System.Runtime.Serialization;

namespace elm
{
	/// <summary>
	/// Desctiption of ElmException.
	/// </summary>
	public class ElmException : Exception, ISerializable
	{
		public ElmException()
		{
		}

	 	public ElmException(string message) : base(message)
		{
		}

		public ElmException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected ElmException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}