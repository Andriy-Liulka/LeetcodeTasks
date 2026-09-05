//https://leetcode.com/problems/merge-two-sorted-lists

namespace MergeTwoSortedLists;

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();
        var res1 = solution.MergeTwoLists(
            new ListNode(1, new ListNode(2, new ListNode(4, null))),
            new ListNode(1, new ListNode(3, new ListNode(4, null))));
        Show(res1);
        Console.WriteLine();
        var res2 = solution.MergeTwoLists(
            new ListNode(1, new ListNode(2, new ListNode(4, null))),
            new ListNode(0, new ListNode(0, new ListNode(20, null))));
        Show(res2);
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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null || list2 is null)
            return list1 ?? list2;
        return GetMerged(list1, list2); ;
    }

    private ListNode GetMerged(ListNode list1, ListNode list2)
    {
        if (list1.val <= list2.val)
        {
            Merge(list1, list2);
            return list1;
        }
        Merge(list2, list1);
        return list2;
    }

    private static void Merge(ListNode list1, ListNode list2)
    {
        if (list2 is null)
            return;
        ListNode secondNext = null;
        if (list1.val <= list2.val && (list1.next is null || list2.val <= list1.next.val))
        {
            secondNext = list2.next;
            list2.next = list1.next;
            list1.next = list2;
        }
        else
            secondNext = list2;
        if (list1.next is not null)
            Merge(list1.next, secondNext);
        else
            list1.next = secondNext;
    }
}