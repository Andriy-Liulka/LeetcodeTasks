//https://leetcode.com/problems/create-binary-tree-from-descriptions

public class TreeNode
{
    private readonly string Id;
    
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
        
        this.Id = Guid.NewGuid().ToString();
    }
}

public class Solution
{
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        TreeNode root = default(TreeNode);
        Dictionary<int, TreeNode> nodes = new Dictionary<int, TreeNode>();

        HashSet<int> parentNumbers = new HashSet<int>(descriptions.Length);
        HashSet<int> childNumbers = new HashSet<int>(descriptions.Length);

        bool isLastLeftUpdated = true;
        
        foreach (var descriptionArray in descriptions)
        {
            int parentValue = descriptionArray[0];
            int childValue = descriptionArray[1];
            bool isLeft = descriptionArray[2] == 1;
            
            parentNumbers.Add(parentValue);
            childNumbers.Add(childValue);
            
            var treeNode =
                isLeft ?
                    new TreeNode(
                        val: parentValue,
                        left: nodes.TryGetValue(childValue, out var childLeftValue) ? childLeftValue : new TreeNode(val: childValue),
                        right: null)
                    :
                    new TreeNode(
                        val: parentValue, 
                        left: null, 
                        right: nodes.TryGetValue(childValue, out var childRightValue)? childRightValue : new TreeNode(val: childValue)
                        );
            
            bool isParentNodeExists = nodes.TryGetValue(parentValue, out TreeNode parentNode);
            if (isParentNodeExists)
            {
                if (isLeft)
                {
                    parentNode.left = treeNode.left;
                }
                else
                {
                    parentNode.right = treeNode.right;
                }
            }
            
            bool isChildNodeExists = nodes.TryGetValue(childValue, out TreeNode childNode);
            if (isChildNodeExists)
            {
                if (isLeft)
                {
                    treeNode.left = childNode;
                }
                else
                {
                    treeNode.right = childNode;
                }
            }
            
            if (isLeft)
            {
                nodes.TryAdd(treeNode.val, treeNode);
                nodes.TryAdd(treeNode.left.val, treeNode.left);
            }
            else
            {
                nodes.TryAdd(treeNode.val, treeNode);
                nodes.TryAdd(treeNode.right.val, treeNode.right);
            }
        }
        
        int rootKey = parentNumbers.Except(childNumbers).Single();
        
        return nodes[rootKey];
    }

    public void ShowTree(TreeNode root)
    {
        Console.Write($"-----------------------------------------\n");
        var list = new List<TreeNode>{root};
        while (list.Count > 0)
        {
            var nextLayerList = new List<TreeNode>(list.Capacity * 2);
            foreach (var node in list)
            {
                if (node is null)
                {
                    Console.Write("null, ");
                    continue;
                }
                
                Console.Write($"{node!.val}, ");
                
                nextLayerList.Add(node.left);
                nextLayerList.Add(node.right);
            }
            Console.WriteLine();
            list = nextLayerList;
        }
        Console.Write($"-----------------------------------------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        var threeNode1 = solution.CreateBinaryTree([[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]]);//[50,20,80,15,17,19]
        solution.ShowTree(threeNode1);
        
        var threeNode2 = solution.CreateBinaryTree([[1,2,1],[2,3,0],[3,4,1]]);//[1,2,null,null,3,4]
        solution.ShowTree(threeNode2);
        
        var threeNode3 = solution.CreateBinaryTree([[1,2,1]]);//[1,2, null]
        solution.ShowTree(threeNode3);
        
        var threeNode4 = solution.CreateBinaryTree([[85,82,1],[74,85,1],[39,70,0],[82,38,1],[74,39,0],[39,13,1]]);//[74,85,39,82,null,13,70,38]
        solution.ShowTree(threeNode4);
    }



}
