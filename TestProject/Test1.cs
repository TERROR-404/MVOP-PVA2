namespace TestProject;

[TestClass]
public class Fibonacci
{
    [TestMethod]
    public void TestMethod1()
    {
        int n = 5;
        int[] expected = { 0, 1, 1, 2, 3, 5 };
        int[] actual = Fibonacci(n);
        CollectionAssert.AreEqual(expected, actual);
    }

    public int[] Fibonacci(int n)
    {
        int[] ans = new int[n + 1];
        ans[1] = 1;
        for (int i = 2; i < n + 1; i++)
        {
            ans[i] = (ans[i - 1] + ans[i - 2]);
        }
        return ans;
    }
}
