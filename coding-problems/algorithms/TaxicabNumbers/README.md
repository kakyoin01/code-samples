# Arrays - Taxicab Numbers
- *Language: C#*
- *Provided resources: [Visual Studio 2019](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes) C# solution & test projects*

Problem Statement
-----------------

Find the first <code>n</code> taxicab numbers and associated (a, b) and (c, d) combinations that satisfy the condition <code>a^3 + b^3 = c^3 + d^3</code>, where [a, b, c, d] are unique positive numbers. A taxicab number is the result of <code>a^3 + b^3</code> or <code>c^3 + d^3</code> when the condition is satisfied.

This is a variant of the "Taxicab numbers" problem. The number 1729 is the second valid taxicab number, which is more famously known as "Ramanujan's number" and the "Ramanujan-Hardy number" after the number on a taxicab taken by British mathematician G.H. Hardy when he visited Indian mathematician Srinivasa Ramanujan in a hospital in 1919.

The traditional problem defines the nth taxicab number as the sum of two positive integer cubes in n distinct ways. For instance:
<pre>
T(1) = 2
      (1^3 + 1^3)

T(2) = 1729
      (1^3 + 12^3)
      (9^3 + 10^3)

T(3) = 87539319
      (167^3 + 436^3)
      (228^3 + 423^3)
      (255^3 + 414^3)
</pre>
Note that each nth taxicab number in the series above (2, 1729, 87539139) has n pairs of matching sums of positive integer cubes. T(1) requires <code>a^3 + b^3</code>, T(2) requires <code>a^3 + b^3 = c^3 + d^3</code>, T(3) requires <code>a^3 + b^3 = c^3 + d^3 = e^3 + f^3</code>, etc. Calculating traditional taxicab numbers (even just the first few) is a monumental task far outside the scope of any coding challenge.

This problem is *instead* asking to find n taxicab numbers such that each number has 2 pairs of matching sums of positive integer cubes, not n pairs. This is shown in the problem statement, in which the constraint is <code>a^3 + b^3 = c^3 + d^3</code> for **every** nth number. For this problem, each nth taxicab number is represented as such:
<pre>
T(1) = 1729
      (1^3 + 12^3)
      (9^3 + 10^3)

T(2) = 4104
      (2^3 + 16^3)
      (9^3 + 15^3)

T(3) = 13832
      (2^3  + 24^3)
      (18^3 + 20^3)
</pre>
More information about this taxicab numbers variation can be found at this link: https://oeis.org/A001235


Implementation Details
----------------------

Implement the following method:

<code>List<TCNumInfo> FindNTaxicabNumbersInfo(int n)</code>

Parameters:
  <code>n</code> - Number of taxicab numbers to gather information about.

Returns:
  A list of information related to first n taxicab numbers found ([a, b, c, d] and the number itself).

Where <code>TCNumInfo</code> is the following struct:
<pre>
  struct TCNumInfo
  {
      int[] Pair1 { get; }
      int[] Pair2 { get; }
      BigInteger TCNumber { get; }
  }
</pre>
* <code>Pair1</code> - (a, b) pair that satisfies <code>a^3 + b^3 = c^3 + d^3</code> in combination with Pair2
* <code>Pair2</code> - (c, d) pair that satisfies <code>a^3 + b^3 = c^3 + d^3</code> in combination with Pair1
* <code>TCNumber</code> - Result from calculation of either <code>a^3 + b^3</code> or <code>c^3 + d^3</code>


Constraints:

* <code>1 <= n <= 5</code>
* <code>0 < a, b, c, d < 100000</code>
* <code>a != b != c != d</code>
 
 
 More details and examples in [Problem.txt](TaxicabNumbers/Problem.txt).
 
 In-depth solution explanations and references in [SolutionExplanations.txt](TaxicabNumbers/SolutionExplanations.txt).
