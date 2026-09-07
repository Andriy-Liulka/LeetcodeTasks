//https://leetcode.com/problems/swap-nodes-in-pairs/

namespace SwapNodesInPairs;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.SwapPairs(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
        Show(result);
        Console.WriteLine();
        ListNode list10 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9, new ListNode(10))))))))));
        var result10 = solution.SwapPairs(list10);
        Show(result10);
        Console.WriteLine();
        ListNode list9 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9)))))))));
        var result9 = solution.SwapPairs(list9);
        Show(result9);
    }

    private static void Show(ListNode node)
    {
        Console.Write(node.val);
        if (node.next is not null)
        {
            Show(node.next);
        }
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode SwapPairs(ListNode head)
    {
        ListNode initRef = head is not null && head.next is not null ? head.next : head;
        Swap(null, head);
        return initRef;
    }

    private static void Swap(ListNode previous, ListNode node)
    {
        if (node is null || node.next is null)
            return;

        ListNode realNext = node.next;
        if (node.next.next is null)
        {
            if (previous is not null)
            {
                previous.next = node.next;
                node.next = null;
                realNext.next = node;
            }
            else
            {
                node.next = null;
                realNext.next = node;
            }
        }
        else
        {
            node.next = node.next.next;
            realNext.next = node;
            if (previous is not null)
            {
                previous.next = realNext;
            }
            Swap(node, node.next);
        }
    }
}