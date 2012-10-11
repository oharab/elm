/*
 * User: 721116
 * Date: 26/09/2012
 * Time: 16:36
 * 
 *  */
using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

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
			
			if(opt.Source ==null && opt.Destination==null
				|| opt.Source ==null && opt.Destination!=null
			   || opt.Source!=null && opt.Destination==null)
			{
				opt.PrintUsage();
				return;
			}
			IWindsorContainer container=null;
			try
			{
				container=BootstrapContainer();
				Elm elm=container.Resolve<Elm>();
				ElmResponse response=elm.Upload(opt.Source,opt.Destination,string.Empty);
				Console.WriteLine("Elm Completed.");
				Console.WriteLine("Status : '" +response.Status.ToString() + "'");
			}
			catch(Exception ex)
			{
				Console.WriteLine("Unexpected Error Occurred.");
				Console.WriteLine(ex.Message);
				Console.WriteLine();
			}
			finally{
				if(container!=null)
					container.Dispose();
			}
		}
		
		private static IWindsorContainer BootstrapContainer()
		{
			return new WindsorContainer()
				.Install(Configuration.FromAppConfig(),
				         FromAssembly.This()
				        );
		}
	}
}