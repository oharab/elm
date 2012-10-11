
using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace elm.shell.WindsorInstallers
{
	public class ElmInstaller:IWindsorInstaller
	{
		public ElmInstaller()
		{
		}
		
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<Elm>()
			);
		}
	}
}
