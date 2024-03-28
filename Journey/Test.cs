using System.Reflection.Metadata.Ecma335;

namespace Tests
{
	[TestClass]
	public class Test
	{
		public bool Equal(int i1, int i2)
		{
			return i1 == i2;
		}

		public int Plus(int i1, int i2)
		{
			return i1 + i2;
		}

		public bool Greater(int i1, int i2)
		{
			return i1 > i2;
		}

		[TestMethod]
		public void EqualTest1()
		{
			bool temp = Equal(10, 10);
			Assert.AreEqual(temp, true);
		}

		[TestMethod]
		public void PlusTest()
		{
			int temp = Plus(10, 10);
			Assert.AreEqual(temp, 20);
		}

		[TestMethod]
		public void GreaterTest()
		{
			bool temp = Greater(10, 10);
			Assert.AreEqual(temp, false);
		}
	}
}