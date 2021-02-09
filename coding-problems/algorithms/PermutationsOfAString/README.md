# Algorithms - Permutations of a String
- *Language: C#*
- *Provided resources: [Visual Studio 2019](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes) C# solution & test projects*

Problem Statement
-----------------

Given a string, print out all permutations of the string.
A permutation is a rearrangement of a collection in which order matters.
For instance, all permutations of the string <code>"abc"</code> are:

<pre>
"abc"
"acb"
"bac"
"bca"
"cab"
"cba"
</pre>


Implementation Details
----------------------

Implement the following method:

```cs
HashSet<string> GetStringPermutations(string str)
```

Parameters:
* <code>str</code> - The string to derive permutations from

Returns:
* A collection of all permutations of <code>str</code>.


Constraints:

* All characters in <code>str</code> are unique (for sanity!)


 In-depth solution explanations and references in [SolutionExplanations.txt](PermutationsOfAString/SolutionExplanations.txt).
