
using System;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace elm.shell.WindsorInstallers
{
	
	public class LoggingInstaller:IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<LoggingFacility>(f=>f.UseLog4Net()
			                                      	   .WithAppConfig()
			                                      );
		}
	}
}
