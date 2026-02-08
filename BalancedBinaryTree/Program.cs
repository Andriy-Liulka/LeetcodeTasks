//https://leetcode.com/problems/balanced-binary-tree/description/?envType=daily-question&envId=2026-02-08

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

public class Solution
{
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        bool isBalanced = true;
        IsBalancedRecursive(root, 0, out _,ref isBalanced);
        
        return isBalanced;
    }

    private void IsBalancedRecursive(TreeNode root, int height, out int maxReachedDepth,ref bool isBalanced)
    {
        if (root == null)
        {
            maxReachedDepth = height;
            return;
        }
        
        IsBalancedRecursive(root.left, height + 1, out maxReachedDepth, ref isBalanced);
        int leftHeightFactor = maxReachedDepth;
        maxReachedDepth = height;
        
        IsBalancedRecursive(root.right, height + 1, out maxReachedDepth, ref isBalanced);
        int rightHeightFactor = maxReachedDepth;
        maxReachedDepth = height;

        if (isBalanced)
        {
            isBalanced = Math.Abs(leftHeightFactor - rightHeightFactor) <= 1;
        }
        maxReachedDepth = Math.Max(leftHeightFactor, rightHeightFactor);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var root1 = new TreeNode(1, 
            new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3, new TreeNode(4), new TreeNode(4))), 
            new TreeNode(2));
        bool res1 = new Solution().IsBalanced(root1);//false
        
        var root2 = new TreeNode(1, new TreeNode(2,null,null ), new TreeNode(2,null,null ));
        bool res2 = new Solution().IsBalanced(root2);//true
        
        var root3 = new TreeNode(1);
        bool res3 = new Solution().IsBalanced(root3);//true
        
        var root4 = new TreeNode(1, new TreeNode(2), new TreeNode(2, new TreeNode(3), new TreeNode(3)) );
        bool res4 = new Solution().IsBalanced(root4);//true
        
        //[1,2,3,4,5,6,null,8]
        var root5 = new TreeNode(1,  new TreeNode(2, new TreeNode(3, new TreeNode(4)), new TreeNode(3)), new TreeNode(2, new TreeNode(3), null));
        bool res5 = new Solution().IsBalanced(root5);//true
        
        //[1,2,2,3,3,null,null,4,4]
        var root6 = new TreeNode(1,  new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2, null, null));
        bool res6 = new Solution().IsBalanced(root6);//false
        
        //[1,2,2,3,null,null,3,4,null,null,4]
        TreeNode root7 = new TreeNode(1,
            new TreeNode(2,                               // Left branch
                new TreeNode(3, 
                    new TreeNode(4),                      // 4 is the left child of 3
                    null), 
                null), 
            new TreeNode(2,                               // Right branch
                null, 
                new TreeNode(3, 
                    null, 
                    new TreeNode(4)))                     // 4 is the right child of 3
        );
        bool res7 = new Solution().IsBalanced(root7);//false
        
        //[3,9,20,null,null,15,7]
        var root8 = new TreeNode(1,
            new TreeNode(2),                              // Left child of 3
            new TreeNode(2,                              // Right child of 3
                new TreeNode(3),                         // Left child of 20
                new TreeNode(3))                          // Right child of 20
        );
        bool res8 = new Solution().IsBalanced(root8);//true
    }
} 