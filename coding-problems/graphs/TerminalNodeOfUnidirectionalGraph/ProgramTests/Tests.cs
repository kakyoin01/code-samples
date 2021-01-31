using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TerminalNodeOfUnidirectionalGraph;

namespace ProgramTests
{
    [TestClass]
    public class Tests
    {
        /*
         * Test Graph:
         * 
         * 0-->1
         * 
         */
        [TestMethod]
        [TestCategory("Basic")]
        public void Test_UnidirectionalGraph_Acyclic_SimpleSmall()
        {
            int[] froms = { 0 };
            int[] tos = { 1 };

            int[] starts = { 0, 1 };

            foreach (int startID in starts)
            {
                Assert.AreEqual(
                    1,
                    Program.FindNetworkEndpoint(startID, froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    startID,
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }

        /*
         * Test Graph:
         * 
         *   2
         *    \
         *     v
         * 1-->3-->4
         * 
         */
        [TestMethod]
        [TestCategory("Basic")]
        public void Test_UnidirectionalGraph_Acyclic_SimpleSmall2()
        {
            int[] froms = { 3, 1, 2 };
            int[] tos   = { 4, 3, 3 };

            int[] starts = { 1, 2, 3, 4 };

            foreach (int startID in starts)
            {
                Assert.AreEqual(
                    4,
                    Program.FindNetworkEndpoint(startID, froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    startID,
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }

        /*
         * Test Graph:
         * 
         *   1-->2-->3-->4
         * 
         */
        [TestMethod]
        [TestCategory("Basic")]
        public void Test_UnidirectionalGraph_Acyclic_SimpleSmallStraightLine()
        {
            int[] froms = { 1, 3, 2 };
            int[] tos = { 2, 4, 3 };

            int[] starts = { 1, 2, 3, 4 };

            foreach (int startID in starts)
            {
                Assert.AreEqual(
                    4,
                    Program.FindNetworkEndpoint(startID, froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    startID,
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }

        /*
         * Test Graph:
         * 
         *   7
         *    \
         *     v
         * 1-->3-->4-->6-->9-->5
         *             ^
         *            /
         *           2
         */
        [TestMethod]
        [TestCategory("Basic")]
        public void Test_UnidirectionalGraph_Acyclic_SimpleLarge()
        {
            int[] froms = { 6, 3, 7, 4, 9, 2, 1 };
            int[] tos   = { 9, 4, 3, 6, 5, 6, 3 };

            int[] starts    = { 1, 2, 3, 4, 5, 6, 7, 9 };
            int[] expecteds = { 5, 5, 5, 5, 5, 5, 5, 5 };

            foreach (int i in Enumerable.Range(0, 7))
            {
                Assert.AreEqual(
                    expecteds[i],
                    Program.FindNetworkEndpoint(starts[i], froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    starts[i],
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }

        /*
         * Test Graph:
         * 
         * 0-->1
         * ^    \
         *  \   /
         *   ---
         */
        [TestMethod]
        [TestCategory("Advanced")]
        public void Test_UnidirectionalGraph_Cyclic_AdvancedSmallCase()
        {
            int[] froms = { 0, 1 };
            int[] tos = { 1, 0 };

            int[] starts = { 0, 1 };
            int[] expecteds = { 1, 0 };

            foreach (int i in Enumerable.Range(0, 2))
            {
                Assert.AreEqual(
                    expecteds[i],
                    Program.FindNetworkEndpoint(starts[i], froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    starts[i],
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }

        /*
         * Test Graph:
         * 
         *   6           4
         *    \           \
         *     v           v
         * 7-->2-->5-->3-->1
         * ^                \
         *  \               /
         *   ---------------
         */
        [TestMethod]
        [TestCategory("Advanced")]
        public void Test_UnidirectionalGraph_Cyclic_AdvancedLargeCase()
        {
            int[] froms = { 5, 6, 4, 1, 7, 3, 2 };
            int[] tos = { 3, 2, 1, 7, 2, 1, 5 };

            int[] starts = { 1, 2, 3, 4, 5, 6, 7 };
            int[] expecteds = { 3, 7, 5, 3, 2, 7, 1 };

            foreach (int i in Enumerable.Range(0, 7))
            {
                Assert.AreEqual(
                    expecteds[i],
                    Program.FindNetworkEndpoint(starts[i], froms, tos),
                    "FindNetworkEndpoint({0}, [{1}], [{2}])",
                    starts[i],
                    string.Join(", ", froms),
                    string.Join(", ", tos)
                );
            }
        }
    }
}
