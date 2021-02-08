// Note: For problem information, constraints and examples,
// see related Problem.txt and SolutionExplanations.txt files

// Note: Uncomment line below to see brute force code run
// or keep commented out to see efficient code run

//#define BRUTEFORCE

using System;
using System.Collections.Generic;
using System.Linq;

namespace SubarraySumEqualsK
{
    public class Program
    {
        /// <summary>
        /// Toggle debugging statements during method execution
        /// </summary>
        private const bool DEBUG = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Looking for output? Run the unit tests in Tests.cs!");
        }

        /// <summary>
        /// Given an array of integers and a target sum, return the total number of
        /// continuous subarrays whose sum equals the target sum.
        /// </summary>
        /// <param name="nums">Unordered array of integers</param>
        /// <param name="targetSum">Sum to match with sums of subarrays inside of nums array</param>
        /// <returns>The number of subarrays found in nums with sum equal to targetSum</returns>
        public static int SubarraySums(int[] nums, int targetSum)
        {
            int matchCount = 0;

            if (DEBUG) Console.WriteLine("nums=[{0}], targetSum={1}\n", string.Join(", ", nums), targetSum);

#if BRUTEFORCE
            // Brute force method--check all possible subarrays. Not ideal.
            // Uncomment #define line above to run this solution

            int sum;

            for(int i = 0; i < nums.Length; i++) {
                sum = 0;
                if (DEBUG) Console.WriteLine($"num={nums[i]}, index={i}");
                for(int j = i; j < nums.Length; j++) {
                    sum += nums[j];
                    if (sum == targetSum) {
                        Console.WriteLine($"\tFound match at indices {i}-{j}");
                        matchCount++;
                    }
                }
            }
#else
            // Efficient solution--track sums using dictionary
            // Calculate difference between sums to find potential matches
            // Comment out #define line above to run this solution

            int curSum = 0;
            Dictionary<int, int> sumsDict = new Dictionary<int, int>();

            foreach(int num in nums) {
                // Calculate new rolling sum
                curSum += num;

                if (DEBUG) Console.WriteLine($"num={num}, curSum={curSum}");

                // Check for direct match to targetSum at current step
                // (tests subarrays starting from front of array)
                if (curSum == targetSum) {
                    if (DEBUG) Console.WriteLine($"Match found at num={num}, curSum={curSum}");
                    matchCount++;
                }

                // Test subarrays not including front of array:
                // Check for a prior sum x such that curSum - x = targetSum
                // (or when rearranged, x = curSum - targetSum)
                int sumOffset = curSum - targetSum;

                // If matching key found, # of matches found equal to # of
                // times sum offset has been found as rolling sum previously
                if (sumsDict.ContainsKey(sumOffset)) {
                    if (DEBUG) Console.WriteLine($"{sumsDict[sumOffset]} match(es) found at num={num}, curSum={curSum}, sumOffset={sumOffset}");
                    matchCount += sumsDict[sumOffset];
                }

                // Add current rolling sum as a key to dictionary,
                // or if sum has already been found, increment found count
                if (!sumsDict.ContainsKey(curSum)) {
                    if (DEBUG) Console.WriteLine($"Adding new sum key {curSum} to dict");
                    sumsDict.Add(curSum, 1);
                } else {
                    if (DEBUG) Console.WriteLine($"Incrementing value at key={curSum} from {sumsDict[curSum]} to {sumsDict[curSum] + 1}");
                    sumsDict[curSum] = sumsDict[curSum] + 1;
                }

                if (DEBUG) {
                    Console.WriteLine("Current dict:");
                    sumsDict.ToList().ForEach(kvp => Console.WriteLine($"\t{kvp.Key}->{kvp.Value}"));
                    Console.WriteLine();
                }
            }
#endif
            if (DEBUG) Console.WriteLine($"\nFound {matchCount} subarrays with targetSum={targetSum}");            
            return matchCount;
        }
    }
}
