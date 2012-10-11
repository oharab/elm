
using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OpenFileSystem.IO;
using OpenFileSystem.IO.FileSystems.Local.Win32;

namespace elm.shell.WindsorInstallers
{
	public class OpenFileSystemInstaller:IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IFileSystem>().ImplementedBy<Win32FileSystem>()
			);
		}
	}
}
