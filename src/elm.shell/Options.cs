/*
 * User: 721116
 * Date: 26/09/2012
 * Time: 17:19
 * 
 *  */
using System;
using NMaier.GetOptNet;

namespace elm.shell
{
	/// <summary>
	/// Command line options
	/// </summary>
	[GetOptOptions(UsageIntro="eMIS Loader Module",
	               UsageEpilog="Copyright © West Yorkshire Police 2012"
	              ,OnUnknownArgument= UnknownArgumentsAction.Ignore)]
	public class Options:GetOpt
	{
		[Argument(Helptext="Should elm ignore any missing input files")]
		[FlagArgument(true)]
		public bool IgnoreMissingInput { get; set; }
		
		[Argument(Helptext="Should elm ignore any missing output files")]
		[FlagArgument(true)]
		public bool IgnoreMissingOutput { get; set; }
		
		[Argument(Helptext="Should elm ignore any output files it can't check out")]
		[FlagArgument(true)]
		public bool IgnoreCheckedOut { get; set; }
		
		[Argument(Helptext="Prints this message")]
		[ShortArgument('h')]
		[FlagArgument(true)]
		public bool Help { get; set; }
		
		[Argument(Helptext="Verbose output")]
		[ShortArgument('v')]
		[FlagArgument(true)]
		public bool Verbose { get; set; }
		
		
		
		
		[Argument(Helptext="Source file to upload to eMIS")]
		public String Source { get; set; }

		
		[Argument(Helptext="Source file to upload to eMIS")]
		public Uri Destination { get; set; }
		
	}
}
