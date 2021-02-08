# Arrays - Subarray Sum Equals K
- *Language: C#*
- *Provided resources: [Visual Studio 2019](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes) C# solution & test projects*

Given an array of integers and a target sum, return the total number of continuous subarrays whose sum equals the target sum.
This is more commonly known as the "Subarray sum equals k" problem, where k = target sum.
A subarray is defined as all or part of a contiguous (not skipping elements) sequence of elements within the given array.
 
Implement the following method:

<code>int SubarraySums(int[] nums, int targetSum)</code>

***Parameters:***
 * <code>nums</code> - Unordered array of integers.
 * <code>targetSum</code> - Sum to match with sums of subarrays inside of nums array.

***Returns:***
 * The number of subarrays found in nums with sum equal to targetSum.

<hr>

***Constraints:***

* <code>nums.Length</code> >= 1
* -100 <= <code>nums[i]</code> <= 100

<hr>

**Example 1**

* <code>nums</code> = <code>{1, 3, 1, 1, 2, 2}</code>
* <code>targetSum</code> = <code>4</code>

There are **4** subarrays with sum of 4:
<pre>
  {1, 3}
     {3, 1}
        {1, 1, 2}
              {2, 2}
</pre>


**Example 2**
 
* <code>nums</code> = <code>{10, 2, -2, -20, 10}</code>
* <code>targetSum</code> = <code>-10</code>

There are **3** subarrays with sum of -10:
<pre>
  {10, 2, -2, -20}
      {2, -2, -20, 10}
             {-20, 10}
</pre>
 
 
 More details and examples in [Problem.txt](SubarraySumEqualsK/Problem.txt).
 
 In-depth solution explanations in [SolutionExplanations.txt](SubarraySumEqualsK/SolutionExplanations.txt).
