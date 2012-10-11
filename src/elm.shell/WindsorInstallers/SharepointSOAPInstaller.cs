
using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using elm.Web;

namespace elm.shell.WindsorInstallers
{
	
	public class SharepointSOAPInstaller:IWindsorInstaller
	{
		
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IListsWSSSOAPService>().ImplementedBy<ListsWSSWOAPService>()
				.DependsOn(
					Dependency.OnAppSettingsValue("Uri","ListsUri")
				)
				
				,Component.For<ICopyWSSSOAPService>().ImplementedBy<CopyWSSSOAPService>()
				,Component.For<ISharepointService>().ImplementedBy<SharepointService>()
			);
		}
	}
}
