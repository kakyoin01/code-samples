// Note: For problem information, constraints and examples,
// see related Problem.txt and SolutionExplanations.txt files

using System;
using System.Collections.Generic;
using System.Numerics;

namespace TaxicabNumbers
{
    public class Program
    {
        /// <summary>
        /// Toggle debug statements on/off
        /// </summary>
        const bool DEBUG = false;

        /// <summary>
        /// Arbitrary limit--increasing will drastically up runtime but find more matches.
        /// </summary>
        const int LIMIT = 100_000;

        /// <summary>
        /// Number of taxicab numbers to gather info for.
        /// Note that lowering this number may yield less accurate results--test this
        /// by turning DEBUG to true to see the order in which taxicab numbers are
        /// found to see why!
        /// </summary>
        const int NUMS_TO_FIND = 100;

        static void Main(string[] args)
        {
            List<TCNumInfo> infos = FindNTaxicabNumbersInfo(NUMS_TO_FIND);
            for (int i = 0; i < infos.Count; i++) {
                Console.WriteLine($"{i + 1} - " + infos[i].ToString());
            }
        }

        /// <summary>
        /// Find the first n taxicab numbers and associated (a, b) and (c, d) pairs that satisfy the condition
        /// a^3 + b^3 = c^3 + d^3, where [a, b, c, d] are unique numbers.
        /// </summary>
        /// <param name="n">Number of taxicab numbers to gather information about</param>
        /// <returns>A list of information related to first n taxicab numbers found ([a, b, c, d] and the number itself).</returns>
        static List<TCNumInfo> FindNTaxicabNumbersInfo(int n)
        {
            List<TCNumInfo> infos = new List<TCNumInfo>();
            Dictionary<BigInteger, List<int[]>> cubeSumsDict = new Dictionary<BigInteger, List<int[]>>();
            BigInteger result;
            int[] newPair;

            // Step through unique (x, y) pairs only
            for(int a = 0; a <= LIMIT; a++) {
                for(int b = a; b <= LIMIT; b++) {
                    // Calculate new cubes pair sum result as dictionary key
                    result = (BigInteger)(Math.Pow(a, 3) + Math.Pow(b, 3));
                    newPair = new int[] { a, b };

                    // If key exists, one or more matches are found
                    if(cubeSumsDict.ContainsKey(result)) {
                        foreach(int[] pair in cubeSumsDict[result]) {
                            TCNumInfo newInfo = new TCNumInfo(pair, newPair, result);

                            if (DEBUG) Console.WriteLine($"Found new info: {newInfo}");
                            
                            infos.Add(newInfo);

                            // Sort results and duck out early if quota satisfied
                            if (infos.Count >= n) {
                                infos.Sort();
                                return infos;
                            }
                        }
                    }

                    // Track cubes pair sum and number pair for potential future matches
                    if (cubeSumsDict.ContainsKey(result)) {
                        cubeSumsDict[result].Add(newPair);
                    } else {
                        cubeSumsDict.Add(result, new List<int[]>());
                        cubeSumsDict[result].Add(newPair);
                    }
                }
            }

            if (DEBUG) Console.WriteLine("Exhausted int list, returning infos before {0} numbers found", n);

            infos.Sort();
            return infos;
        }
    }

    /// <summary>
    /// Represents information regarding one taxicab number.
    /// </summary>
    public readonly struct TCNumInfo : IComparable
    {
        public TCNumInfo(int[] pair1, int[] pair2, BigInteger tcNumber)
        {
            Pair1 = pair1;
            Pair2 = pair2;
            TCNumber = tcNumber;
        }
        
        public int[] Pair1 { get; }

        public int[] Pair2 { get; }

        /// <summary>
        /// Taxicab number equivalent to a^3 + b^3 or c^3 + d^3
        /// </summary>
        public BigInteger TCNumber { get; }

        public int CompareTo(object obj)
        {
            if (obj is TCNumInfo info) {
                return this.TCNumber.CompareTo(info.TCNumber);
            }
            return 1;
        }

        override public string ToString()
        {
            return $"TCNumber: {TCNumber}, Pair1: [{string.Join(", ", Pair1)}], Pair2: [{string.Join(", ", Pair2)}]";
        }
    }
}
