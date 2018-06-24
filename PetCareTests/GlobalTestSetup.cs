using System;
using System.IO;
using NUnit.Framework;

namespace PetCareTests
{
	[SetUpFixture]
	public class GlobalTestSetup
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Trim('\\');
			dnk.log2html.Report.Configure(
				Path.Combine(Directory.GetParent(baseDirectory).Parent.Parent.FullName, "Results"),
				new dnk.log2html.ReportMetaData
				{
					ReportName = "Test Execution Report",
					ReportEnvironment = Configuration.Config.GetEnvironment()
				}
			);
		}
	}
}