using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubarraySumEqualsK;

namespace ProgramTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [TestCategory("Basic")]
        public void Test_SubarraySumEqualsK_Basic1()
        {
            int[] nums = { 1, 1, 1 };
            int targetSum = 2;
            Assert.AreEqual(
                2,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Basic")]
        public void Test_SubarraySumEqualsK_Basic2()
        {
            int[] nums = { 1, 2, 3 };
            int targetSum = 4;
            Assert.AreEqual(
                0,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Basic")]
        public void Test_SubarraySumEqualsK_Basic3()
        {
            int[] nums = { 0 };
            int targetSum = 0;
            Assert.AreEqual(
                1,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Basic")]
        public void Test_SubarraySumEqualsK_Basic4()
        {
            int[] nums = { -1 };
            int targetSum = -1;
            Assert.AreEqual(
                1,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Basic")]
        public void Test_SubarraySumEqualsK_Basic5()
        {
            int[] nums = { -2, 2 };
            int targetSum = 0;
            Assert.AreEqual(
                1,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Advanced")]
        public void Test_SubarraySumEqualsK_Advanced1()
        {
            int[] nums = { 1, 3, 1, 1, 2, 2 };
            int targetSum = 4;
            Assert.AreEqual(
                4,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }

        [TestMethod]
        [TestCategory("Advanced")]
        public void Test_SubarraySumEqualsK_Advanced2()
        {
            int[] nums = { 10, 2, -2, -20, 10 };
            int targetSum = -10;
            Assert.AreEqual(
                3,
                Program.SubarraySums(nums, targetSum),
                "SubarraySums([{0}], {1})",
                string.Join(", ", nums),
                targetSum
            );
        }
    }
}
