using Microsoft.VisualStudio.TestPlatform.TestHost;
using skola_testovani_uloha1;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Quadratic q;
        [TestMethod]
        [DataRow(1, 5, 6)]
        public void Discriminant_Of_1_5_6(int a, int b, int c)
        {
            double correct = 1;
            double result = q.Discriminant(a, b, c);
            Assert.IsTrue(result == correct);
        }

        [TestMethod]
        [DataRow(1, 5, 6)]
        public void Results_Of_1_5_6(int a, int b, int c)
        {
            double correct1 = -2;
            double correct2 = -3;
            double[] result = q.Result(a, b, c);
            Assert.IsTrue(result[0] == correct1 && result[1] == correct2);
        }
    }
}