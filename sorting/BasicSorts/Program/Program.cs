// For examples and explanations of how each sorting algorithm works,
// see accompanied Explanations.txt file.

using System;

namespace BasicSorts
{
    class Program
    {
        /// <summary>
        /// Toggle debug statements during program execution
        /// </summary>
        const bool DEBUG = true;

        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 8, 6, 10, 1, 4, 7, 9, 3 };

            Console.WriteLine("Bubble Sort:");
            Console.WriteLine($"Initial: {GetPrintableArr(arr)}");
            BubbleSort(arr);
            Console.WriteLine($"Final: {GetPrintableArr(arr)}\n");

            arr = new[] { 5, 2, 8, 6, 10, 1, 4, 7, 9, 3 };

            Console.WriteLine("Bubble Sort (recursive):");
            Console.WriteLine($"Initial: {GetPrintableArr(arr)}");
            BubbleSortRecursive(arr);
            Console.WriteLine($"Final: {GetPrintableArr(arr)}\n");

            arr = new[] { 5, 2, 8, 6, 10, 1, 4, 7, 9, 3 };

            Console.WriteLine("Selection Sort:");
            Console.WriteLine($"Initial: {GetPrintableArr(arr)}");
            SelectionSort(arr);
            Console.WriteLine($"Final: {GetPrintableArr(arr)}\n");

            arr = new[] { 5, 2, 8, 6, 10, 1, 4, 7, 9, 3 };

            Console.WriteLine("Insertion Sort:");
            Console.WriteLine($"Initial: {GetPrintableArr(arr)}");
            InsertionSort(arr);
            Console.WriteLine($"Final: {GetPrintableArr(arr)}");
        }

        /// <summary>
        /// Bubble Sort - Sort an array by "bubbling" smaller values to the front.
        /// O(N^2) runtime (iterates over array twice).
        /// O(1) space (only swaps values in array).
        /// </summary>
        /// <param name="arr">The array to sort</param>
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++) {
                // Each iteration, move largest unsorted value to
                // end of unsorted range via iterative comparison
                for (int j = 0; j < arr.Length - 1 - i; j++) {
                    if (arr[j] > arr[j + 1]) {
                        Swap(arr, j, j + 1);
                    }
                }
                if (DEBUG) PrintArr(arr);
            }
        }

        /// <summary>
        /// Bubble Sort - Sort an array by "bubbling" smaller values to the front. O(N^2) runtime.
        /// Recursive version.
        /// No runtime improvement--still O(N^2).
        /// No space improvement--still O(1).
        /// </summary>
        /// <param name="arr">The array to sort</param>
        static void BubbleSortRecursive(int[] arr)
        {
            // Base case: array that cannot be sorted or needs no sorting
            if (arr.Length < 2) return;

            // Call first iteration of sort algorithm
            BSRSort(arr, arr.Length);
        }

        /// <summary>
        /// Iterate over a specific length of an array,
        /// moving the largest found value to the given index ceiling.
        /// </summary>
        /// <param name="arr">The array to sort</param>
        /// <param name="upperBoundIdx">The limit to iterate over the array up to</param>
        static void BSRSort(int[] arr, int upperBoundIdx)
        {
            // Base case: remaining subarray needs no more sorting
            if (upperBoundIdx < 2) return;

            // Move largest unsorted value to end of unsorted range via iterative comparison
            for (int i = 0; i < upperBoundIdx - 1; i++) {
                if (arr[i] > arr[i + 1]) Swap(arr, i, i + 1);
            }

            if (DEBUG) PrintArr(arr);

            // Decrement current index ceiling and repeat entire procedure
            BSRSort(arr, upperBoundIdx - 1);
        }

        /// <summary>
        /// Selection Sort - Sort an array by "selecting" the lowest value found in (unsorted) right half
        /// and moving it to the next spot in the (sorted) left half.
        /// O(N^2) runtime (iterates over array twice at worst).
        /// O(1) runtime (only swaps values in array).
        /// </summary>
        /// <param name="arr">The array to sort</param>
        static void SelectionSort(int[] arr)
        {
            int curMinValueIdx;
            for (int i = 0; i < arr.Length; i++) {
                // Find location of lowest value in unsorted (right) half of array
                curMinValueIdx = i;
                for (int j = i; j < arr.Length; j++) {
                    if (arr[j] < arr[curMinValueIdx]) curMinValueIdx = j;
                }

                // Move the lowest value found to the next place in the sorted (left) half of array
                Swap(arr, i, curMinValueIdx);

                if (DEBUG) PrintArr(arr);
            }
        }

        /// <summary>
        /// Insertion Sort - Sort an array by "inserting" each value in the correct array position.
        /// Performs direct comparison bubbling value down in array until a smaller value is encountered.
        /// This is similar to sorting ordered playing cards in a hand in a card game.
        /// O(N^2) runtime (iterates over array twice at worst).
        /// O(1) space (only swaps values in array).
        /// This is a stable sorting algorithm.
        /// </summary>
        /// <param name="arr">The array to sort</param>
        static void InsertionSort(int[] arr)
        {
            // Array doesn't need to/can't be sorted
            if (arr.Length < 2) return;

            // Track value to be potentially inserted earlier in the array
            int curValue;

            for(int i = 1; i < arr.Length; i++) {
                // Store value to potentially be inserted earlier in array
                curValue = arr[i];
                if (DEBUG) Console.WriteLine($"  i={i} - value to insert: {curValue}");

                // Move all values larger than current value up one space in array
                int j = i;
                while (j > 0 && arr[j - 1] > curValue) {
                    arr[j] = arr[j - 1];
                    if (DEBUG) Console.WriteLine($"    j={j} - copied {arr[j]} over -- {GetPrintableArr(arr)}");
                    j--;
                }
                // Insert value in its designated space
                arr[j] = curValue;
                if (DEBUG) Console.WriteLine($"  Inserted {curValue} at index {j} -- {GetPrintableArr(arr)}");
            }
        }

        /// <summary>
        /// Helper function. Swaps two values in an array.
        /// </summary>
        /// <param name="arr">Array in which to swap</param>
        /// <param name="i">Index of first value to swap with second value</param>
        /// <param name="j">Index of second value to swap with first value</param>
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            if (DEBUG) Console.WriteLine($"  Swapped index {i} ({arr[j]}) with index {j} ({arr[i]}) -- {GetPrintableArr(arr)}");
        }

        /// <summary>
        /// Output helper function. Prints array cleanly.
        /// </summary>
        /// <param name="arr">The array to print</param>
        static void PrintArr(int[] arr)
        {
            Console.WriteLine($"Current array: " + GetPrintableArr(arr));
        }

        /// <summary>
        /// Output helper function. Returns formatted array.
        /// </summary>
        /// <param name="arr">The array to print-format</param>
        /// <returns>The array contents in a formatted string</returns>
        static string GetPrintableArr(int[] arr)
        {
            return $"[{string.Join(", ", arr)}]";
        }
    }
}
