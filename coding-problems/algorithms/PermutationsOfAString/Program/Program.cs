// Note: For problem information, constraints and examples,
// see related Problem.txt and SolutionExplanations.txt files

using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsOfAString
{
    class Program
    {
        /// <summary>
        /// Toggle for debug statements
        /// </summary>
        const bool DEBUG = true;

        static void Main(string[] args)
        {
            string str = "abcd";
            HashSet<string> perms = GetStringPermutations(str);
            List<string> sortedResults = perms.ToList();
            sortedResults.Sort();
            Console.WriteLine($"Permutations of {str}:");
            foreach(string perm in sortedResults) {
                Console.WriteLine($"{perm}");
            }
        }

        /// <summary>
        /// Given a string, print out all permutations of the string.
        /// </summary>
        /// <param name="str">The string to derive permutations from</param>
        /// <returns>A collection of all permutations of str.</returns>
        static HashSet<string> GetStringPermutations(string str)
        {
            HashSet<string> perms = new HashSet<string>();

            if (DEBUG) Console.WriteLine($"GetStringPermutations(\"{str}\")");

            // Base case: empty string ""
            if (str.Length < 1) {
                if (DEBUG) Console.WriteLine("Empty string found");
                return perms;
            }

            // Peel off first letter in string
            // e.g. "a" in "abc"
            // "b" in "bc", etc
            char firstLetter = str[0];

            // Base case: singleton string means only 1 permutation
            // e.g. "c"
            if (str.Length == 1) {
                if (DEBUG) Console.WriteLine($"Singleton string found: [{firstLetter}]");
                perms.Add($"{firstLetter}");
                return perms;
            }

            // Recursively generate "rolling" permutations of remaining string
            // e.g. starting with "abc":
            // GetStringPermutations("abc") - peel off "a"
            // -> GetStringPermutations("bc") - "peel off "b"
            // --> GetStringPermutations("c") - "peel off "c"
            // --> "c": Get back {"c"} (secondary base case)
            // -> "b": Insert "b" everywhere in "c"--get back {"bc", "cb"}
            // "a": Insert "a" everywhere in "bc" and "cb"--get back { "abc", "bac", "bca", "acb", "cab", "cba"}
            string substr = str.Substring(1);
            HashSet<string> rollingPerms = GetStringPermutations(substr);

            // Operate on prior function's return value:
            // Insert character everywhere in-between each ongoing permutation to get
            // new ongoing permutations and return them.
            // e.g. GetStringPermutations("bc") returns with {"bc", "cb"} ongoing permutations,
            // now insert "a" everywhere for each ongoing permutation to get:
            // {"abc", "bac", "bca", "acb", "cab", "cba"}
            foreach(string rPerm in rollingPerms) {
                for(int i = 0; i <= rPerm.Length; i++) {
                    string newRollingPerm = rPerm.Substring(0, i) + firstLetter + rPerm.Substring(i);
                    perms.Add(newRollingPerm);
                }
            }

            if (DEBUG) {
                Console.WriteLine($"Updated rolling perms from:\n\t[{string.Join(", ", rollingPerms.ToArray())}]\nto:\n\t[{string.Join(", ", perms.ToArray())}]\n");
            }

            return perms;
        }
    }
}
