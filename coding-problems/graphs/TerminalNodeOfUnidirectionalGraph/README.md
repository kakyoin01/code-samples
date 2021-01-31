# Graphs - Terminal Node of Unidirectional Graph
- *Language: C#*
- *Provided resources: [Visual Studio 2019](https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes) C# solution & test projects*

Given any given starting point in a unidirectional graph, find the terminal (last) node. Each node connects to at most one other node. If a loop is encountered while traversing the network, return ID of the last node traversed before closing the loop.
 
Implement the following method:

<code>int FindNetworkEndpoint(int startNodeId, int[] fromIds, int[] toIds)</code>

***Parameters:***
 * <code>startNodeId</code> - The ID of the node to start traversing on.
 * <code>fromIds</code> - Related to toIds. An ordered list of node parent IDs.
 * <code>toIds</code> - Related to fromIds. An ordered list of node children IDs.

***Returns:***
 * The ID of the last node in a unidirectional graph.

<hr>

***Constraints:***

* <code>fromIds.Length == toIds.Length</code> and are not empty, but both are not assumed to be ordered in any way aside from index relation.
* **0** < number of links < **10,000**
* No nodes connected to themselves.
* All node IDs are unique (<code>fromIds</code> meets criteria for a set data structure).
* Cycles in the network are possible.

<hr>

**Example: Directed Acyclic Graph (DAG), no loop**
<pre>
fromIds = [6, 3, 7, 4, 9, 2, 1]
  toIds = [9, 4, 3, 6, 5, 6, 3]
</pre>
<pre>
  7
   \
    v
1-->3-->4-->6-->9-->5
            ^
           /
          2
</pre>
For all <code>startNodeId</code> values, the last node ID will be **5**.
 
 More details and examples in [Problem.txt](TerminalNodeOfUnidirectionalGraph/Problem.txt).
