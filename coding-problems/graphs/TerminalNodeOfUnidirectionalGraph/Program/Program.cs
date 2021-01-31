// Note: For problem information, constraints and examples,
// see related Problem.txt file

using System;

namespace TerminalNodeOfUnidirectionalGraph
{
    public class Program
    {
        /// <summary>
        /// Toggle debugging statements during method execution
        /// </summary>
        private const bool DEBUG = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Looking for output? Run the unit tests in Tests.cs!");
        }

        /// <summary>
        /// Finds the last node ID in a unidirectional graph (acyclic or cyclic).
        /// If a cycle is encountered, return the last node ID in the cycle.
        /// </summary>
        /// <param name="startNodeId">Starting node ID in the graph</param>
        /// <param name="fromIds">A relatively ordered array of node IDs that point to nodeIDs in toIds</param>
        /// <param name="toIds">A relatively ordered array of node IDs that are pointed to by nodeIDs in fromIds</param>
        /// <returns>The last node ID in the graph described by fromIds and toIds,
        /// or the last node ID in a cycle if one is encountered.</returns>
        public static int FindNetworkEndpoint(int startNodeId, int[] fromIds, int[] toIds)
        {
            // Special cases for zero and one connection(s)
            if (fromIds.Length == 0) return startNodeId;
            else if (fromIds.Length == 1) return toIds[0];

            int curNodeID = startNodeId;
            int curIndex = IndexOf(curNodeID, fromIds);
            bool[] visitedNodeIdxs = new bool[fromIds.Length];
            int lastIndexVisited = -1;

            if (DEBUG) {
                Console.WriteLine(
                    "startNodeId={0}, fromIds=[{1}], toIds=[{2}], visitedNodeIdxs=[{3}]",
                    startNodeId,
                    String.Join(", ", fromIds),
                    String.Join(", ", toIds),
                    String.Join(", ", visitedNodeIdxs)
                );
            }

            // "Traverse" the from->to list one node at a time until no new connection found
            while (curIndex != -1) {
                // Previously visited node about to be revisited
                // Return last visited node ID
                if(visitedNodeIdxs[curIndex]) {
                    if(DEBUG) Console.WriteLine($"Index {curIndex} with value {curNodeID} already visited");
                    return fromIds[lastIndexVisited];
                }

                if(DEBUG) Console.WriteLine($"Index {curIndex} with value {curNodeID} not visited yet");

                // Record current node as last visited node
                // and move forward one node in the sequence
                visitedNodeIdxs[curIndex] = true;
                lastIndexVisited = curIndex;
                curNodeID = toIds[curIndex];
                curIndex = IndexOf(curNodeID, fromIds);

                if (DEBUG) Console.WriteLine($"Now attempting to visit index {curIndex} with value {curNodeID}\n");
            }

            return curNodeID;
        }

        /// <summary>
        /// Helper function
        /// Performs List.IndexOf(...) functionality for int array
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <param name="arr">The array in which to search for the element</param>
        /// <returns>Index of the element in arr, or -1 if not found</returns>
        static int IndexOf(int element, int[] arr)
        {
            for(int i = 0; i < arr.Length; i++) {
                if (arr[i] == element) return i;
            }
            return -1;
        }
    }
}
