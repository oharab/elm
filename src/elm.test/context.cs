/*
 * User: 721116
 * Date: 02/10/2012
 * Time: 17:38
 * 
 *  */
using System;
using NUnit.Framework;
namespace elm.test
{
	[TestFixture]
	public class context
	{
		[SetUp]
		protected virtual void SetUp()
		{
		}

		[TearDown]
		protected virtual void TearDown()
		{
		}

		public Action Executing(Action action)
		{
			return action;
		}
	}
}
