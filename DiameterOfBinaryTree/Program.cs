//https://leetcode.com/problems/diameter-of-binary-tree

namespace DiameterOfBinaryTree;

class Program
{
    static void Main(string[] args)
    {
        //Tested in LeetCode
    }
}

public class Solution 
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int max = 0;
        _=DepthFirstSearch(root, 0, ref max);
        return max;
    }

    private static int DepthFirstSearch(TreeNode node, int currentDepth, ref int maxLengthNow)
    {
        if(node is null)
            return currentDepth - 1;
        int maxLeft = DepthFirstSearch(node.left, currentDepth + 1, ref maxLengthNow);
        int maxRight = DepthFirstSearch(node.right, currentDepth + 1, ref maxLengthNow);
        maxLengthNow = Math.Max(maxLengthNow, (maxLeft-currentDepth) + (maxRight-currentDepth));
        return Math.Max(maxLeft, maxRight);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}