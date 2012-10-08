/*
 * User: 721116
 * Date: 26/09/2012
 * Time: 16:36
 * 
 *  */
using System;

namespace elm.shell
{
	class Program
	{
		public static void Main(string[] args)
		{
			Options opt=new Options();
			opt.Parse(args);
			if(opt.Help)
			{
				opt.PrintUsage();
				return;
			}
			
			if(opt.Source==string.Empty && opt.Destination!=string.Empty 
			   || opt.Source!=string.Empty && opt.Destination==string.Empty)
			{
				opt.PrintUsage();
				return;
			}
			
			
		}
	}
}