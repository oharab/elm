
using System;
using System.IO;
using OpenFileSystem.IO;

namespace elm.Extensions
{
	public static class OpenFileSystemExtensions
	{
		public static byte[] ToByteArray(this IFile file){
			Stream stream=file.OpenRead();
			byte[] data=new byte[stream.Length];
			stream.Read(data,0,(int)stream.Length);
			return data;
		}
	}
}
