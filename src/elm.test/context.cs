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
	public abstract class context
	{
		[SetUp]
		protected virtual void SetUp()
		{
		}

		[TearDown]
		protected virtual void TearDown()
		{
		}

		protected virtual void BeforeExecuting()
		{
			
		}
		
		public Action Executing(Action action)
		{
			BeforeExecuting();
			return action;
		}
	}
}
