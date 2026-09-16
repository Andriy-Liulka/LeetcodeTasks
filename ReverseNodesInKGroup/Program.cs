//https://leetcode.com/problems/reverse-nodes-in-k-group/

namespace ReverseNodesInKGroup;

class Program
{
    static void Main(string[] args)
    {
        var sln = new SolutionQueues();
        var res1 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, 
            new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, 
                new ListNode(9))))))))), 3); // k=3
        Show(res1);
        Console.WriteLine();
        var res2 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3, 
            new ListNode(4, new ListNode(5, new ListNode(6)))))), 3); //k=3
        Show(res2);
        Console.WriteLine();
        var res3 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3, 
            new ListNode(4, new ListNode(5, new ListNode(6)))))), 2); //k=2
        Show(res3);
        Console.WriteLine();
        var res4 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, 
            new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8)))))))), 3); // k = 3
        Show(res4);
        Console.WriteLine();
        var res5 = sln.ReverseKGroup(new ListNode(1, new ListNode(2)), 2); // k = 2
        Show(res5);
        Console.WriteLine();
        var res6 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3,
            new ListNode(4, new ListNode(5))))), 2); // k = 2
        Show(res6);
        Console.WriteLine();
        var res7 = sln.ReverseKGroup(new ListNode(1, new ListNode(2, new ListNode(3,
            new ListNode(4, new ListNode(5))))), 3); // k = 3
        Show(res7);
        Console.WriteLine();
    }

    private static void Show(ListNode node)
    {
        Console.Write(node?.val);
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

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k)
    {

        return null;
    }

    private static (ListNode,ListNode) RecurseBrowsing(ListNode head, int n, int k)
    {
        bool endReverse = false;
        if (n >= k)
        {
            endReverse = true;
            n = 0;
        }

        if (head is null)
        {
            return (null, null);
        }
        
        
        ListNode current = head;
        var( next, last) = RecurseBrowsing(head.next, n + 1, k);


        if (endReverse && last is null)
        {
            last = head;
        }
        next.next = current;


        return (null,null);
    }
}

public class SolutionStacks
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        List<KeyValuePair<bool, Stack<ListNode>>> list = new List<KeyValuePair<bool, Stack<ListNode>>>(k);
        bool isNotEnd = true;
        ListNode current = head;
        while (isNotEnd)
        {
            isNotEnd = TryPrepareStack(current, k, out Stack<ListNode> stack);

            if (isNotEnd)
                current = stack.Peek().next;
            if (stack.Peek() is not null)
            {
                list.Add(new KeyValuePair<bool, Stack<ListNode>>(isNotEnd, stack));
            }
        }

        ListNode theNewTail = null;
        ListNode theNewHead = null;
        bool isVeryFirst = true;
        ListNode veryFirstElement = null;
        foreach (KeyValuePair<bool, Stack<ListNode>> stackPair in list)
        {
            ListNode currentElem = null;
            if (stackPair.Key)
            {
                Stack<ListNode> stack = stackPair.Value;
                for (int i = 1; i <= k; i++)
                {
                    if (currentElem is not null)
                    {
                        var nextElem = stack.Peek();
                        nextElem.next = currentElem;
                    }
                    else
                    {
                        theNewHead = stack.Peek();
                    }
                    currentElem = stack.Pop();
                }
            }
            else
            {
                if (currentElem is null)
                {
                    theNewHead = stackPair.Value.Peek();
                }
                currentElem = stackPair.Value.Pop();
            }
            if(theNewHead is not null && theNewTail is not null)
            {
                theNewHead.next = theNewTail;
            }
            theNewTail = currentElem;
            if (isVeryFirst)
            {
                isVeryFirst = false;
                veryFirstElement = currentElem;
            }
        }
        return veryFirstElement;
    }

    private static bool TryPrepareStack(ListNode head, int k, out Stack<ListNode> stack)
    {
        ListNode realHead = head;
        ListNode current = head;
        stack = new Stack<ListNode>();
        for (int i = 1; i <= k; i++)
        {
            if (current is null)
            {
                stack = new Stack<ListNode>();
                stack.Push(realHead);
                return false;
            }
            stack.Push(current);
            current = current.next;
        }
        return true;
    }
}

public class SolutionQueues
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        List<Queue<ListNode>> list = new List<Queue<ListNode>>(k);
        ListNode current = head;
        while (current is not null)
        {
            TryPrepareQueue(current, k, out Queue<ListNode> queue, out ListNode lastELem);
            if (queue.Peek() is not null)
                list.Add(queue);
            current = lastELem;
        }

        ListNode last = null;
        for (int j = list.Count - 1; j >= 0; j--)
        {
            int initQueueSize = list[j].Count;
            while (list[j].TryDequeue(out ListNode currentElem))
            {
                if (last is null && initQueueSize < k)
                {
                    last = currentElem;
                    break;
                }
                currentElem.next = last;
                last = currentElem;
            }
        }
        return last;
    }

    private static void TryPrepareQueue(ListNode head, int k, out Queue<ListNode> queue, out ListNode last)
    {
        ListNode current = head;
        queue = new Queue<ListNode>();
        for (int i = 1; i <= k; i++)
        {
            if (current is null)
            {
                if (queue.Count > 0)
                {
                    var newQueue = new Queue<ListNode>();
                    newQueue.Enqueue(queue.Dequeue());
                    queue = newQueue;
                }
                last = null;
                return;
            }
            queue.Enqueue(current);
            current = current.next;
        }
        last = current;
    }
}

public class SolutionFastest
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode groupprev = dummy;

        while (true)
        {
            ListNode kth = FindKthElement(groupprev.next, k);

            if (kth == null)
            {
                break;
            }
            ListNode groupNext = kth.next;
            ListNode current = groupprev.next;
            ListNode prev = groupNext;

            while (current != groupNext)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            ListNode oldHead = groupprev.next;
            groupprev.next = kth;
            groupprev = oldHead;
        }

        return dummy.next;
    }

    public ListNode FindKthElement(ListNode current, int k)
    {
        while (current != null && k - 1 > 0)
        {
            current = current.next;
            k--;
        }
        return current;
//1 2 3 4 5 6
// k=3
// 3->1-2
// 2->2-3
    }
}