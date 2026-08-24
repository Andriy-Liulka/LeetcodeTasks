namespace AddTwoNumbers;

class Program
{
    static void Main(string[] args)
    {
        var sln = new Solution();

        var result = sln.AddTwoNumbers(new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(4))));
        Show(result); //[7,0,8]
        Console.WriteLine();

        var result2 = sln.AddTwoNumbers(new ListNode(0),
            new ListNode(0));
        Show(result2); //[0]
        Console.WriteLine();

        var result3 = sln.AddTwoNumbers(
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))) );
        Show(result3); //[8,9,9,9,0,0,0,1]
        Console.WriteLine();

        var result4 = sln.AddTwoNumbers(new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(9)))));
        Show(result4); //[7, 0, 1, 0, 1]
        Console.WriteLine();
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ProcessNext(l1, l2, false);
        return l1;
    }

    void ProcessNext(ListNode l1, ListNode l2, bool isPlusOne)
    {
        int value1 = l1.val;
        int value2 = l2?.val ?? 0;
        int result = value1 + value2;
        if (isPlusOne)
        {
            result++;
            isPlusOne = false;
        }
        if (result >= 10)
        {
            isPlusOne = true;
            result -= 10;
        }
        l1.val = result;
        if (l1.next is not null && l2?.next is not null)
        {
            ProcessNext(l1.next, l2.next, isPlusOne);
            return;
        }
        if (l1.next is null && l2?.next is not null)
        {
            l1.next = l2.next;
        }
        if (isPlusOne)
        {
            if (l1.next is not null)
            {
                ProcessNext(l1.next, null, isPlusOne);
            }
            else
            {
                l1.next = new ListNode(1, null);
            }
        }
    }
}