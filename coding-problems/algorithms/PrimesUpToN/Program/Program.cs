// Note: For problem information, constraints, examples and solution explanations,
// see related Problem.txt and SolutionExplanations.txt files

using System;
using System.Text;

namespace PrimesUpToN
{
    class Program
    {
        /// <summary>
        /// Toggle debug statements during method execution
        /// </summary>
        const bool DEBUG = false;

        /// <summary>
        /// Change to see different outcomes
        /// </summary>
        const int LIMIT = 10_000;

        static void Main(string[] args)
        {
            PrintPrimesUpToN(LIMIT);
        }

        /// <summary>
        /// Print all prime numbers up to a custom number n.
        /// This method utilizes the famous "Sieve of Eratosthenes" solution
        /// to filter out composite (non-prime) numbers as they are encountered.
        /// </summary>
        /// <param name="n">The upper limit for prime numbers</param>
        static void PrintPrimesUpToN(int n)
        {
            // No prime numbers exist below 2.
            // See SolutionExplanations.txt for more details.
            if (n < 2) return;

            // Need n + 1 length to track numbers instead of indices
            bool[] flags = new bool[n + 1];

            // Initialize with (almost all) true flags
            // 0 and 1 are not prime numbers by definition (see above)
            Array.Fill(flags, true);
            flags[0] = false;
            flags[1] = false;

            // Start with the first possible prime number
            int potentialPrime = 2;

            // Loop until candidate^2 > limit number
            // or alternatively, candidate > sqrt(limit number).
            // The former is done to avoid an expensive Math.Sqrt() call.
            //
            // NOTE: See SolutionExplanations.txt for mathematical logic
            // as to why this range is optimal!
            while (potentialPrime * potentialPrime <= n) {
                // Eliminate all flags representing multiples of current candidate since
                // they are divisible by candidate.
                // Skip marking off candidate itself, since it may be prime if small enough
                // to not be a multiple of any other number besides itself and 1.
                if (DEBUG) Console.WriteLine($"Eliminating multiples of {potentialPrime}");
                for (int i = 2 * potentialPrime; i < flags.Length; i += potentialPrime) {
                    flags[i] = false;
                }

                // Find next candidate that hasn't been eliminated yet (if any)
                int next = potentialPrime + 1;
                while (next < flags.Length && !flags[next]) next++;
                potentialPrime = next;
            }

            if (DEBUG) Console.WriteLine();

            // Output formatted results
            Console.WriteLine($"Prime numbers <= {n}:");
            StringBuilder sb = new StringBuilder();
            for (int j = 2; j < flags.Length; j++) if (flags[j]) sb.Append($"{j}, ");
            Console.WriteLine(sb.ToString()[0..^2]);
        }
    }
}