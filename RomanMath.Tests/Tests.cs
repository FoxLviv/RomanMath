using NUnit.Framework;
using RomanMath.Impl;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("IV+II+V");
			Assert.AreEqual(11, result);
		}

		[Test]
		public void Test2()
		{
			var result = Service.Evaluate("IV+II*V+XCVIII*CMLXXXIXVIII");
			Assert.AreEqual(97720, result);
		}
	}
}