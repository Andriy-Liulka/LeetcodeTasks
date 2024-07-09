//https://www.youtube.com/watch?v=R4UHOLZ-bEk

namespace BinaryThreeNodeSum;

public class ThreeNode
{
    public int val = 0;
    public ThreeNode left;
    public ThreeNode right;
}
public class Program
{
    static void Main(string[] args)
    {
        var three = new ThreeNode
        {
            val = 1,
            left = new ThreeNode
            {
                val = 4,
                left = new ThreeNode
                {
                    val = 2,
                },
                right = new ThreeNode
                {
                    val = 3,
                    left = new ThreeNode
                    {
                        val = 2
                    }
                }
            },
            right = new ThreeNode
            {
                val = 7,
                left = new ThreeNode
                {
                    val = 5,
                },
                right = new ThreeNode
                {
                    val = 4,
                }
            }
        };

        var result = Calculate(three);

        Console.WriteLine($"Result: {result}");
    }

    private static int Calculate(ThreeNode node)
    {
        if (node is null)
        {
            return 0;
        }
        var leftSum = Calculate(node.left);
        var rightSum = Calculate(node.right);

        var bigger = leftSum > rightSum ? leftSum : rightSum;

        return bigger + node.val;
    }
}
