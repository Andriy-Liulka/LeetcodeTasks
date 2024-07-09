using System.Collections.Generic;

namespace RemoveNthNodeFromEndOfList;

public class Program
{
	public static void Main(string[] args)
	{
		var result1 = new Solution().RemoveNthFromEnd(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);
		var result2 = new Solution().RemoveNthFromEnd(new ListNode(1), 2);
		var result3 = new Solution().RemoveNthFromEnd(new ListNode(1, new ListNode(2)), 1);

		Console.Read();
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
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		if (head.next is null)
		{
			return null;
		}

		var destructurizedNodes = new Dictionary<int, int>();
		int dictCapacity = default;

		RestructureLinkedListIntoDictionary(destructurizedNodes, head);

		dictCapacity = destructurizedNodes.Count;

		destructurizedNodes.Remove(dictCapacity - n);

		var newLinked = new ListNode();

		StructureLinked(destructurizedNodes.Select(x => x.Value).ToArray(), newLinked,0, dictCapacity - 1);

		return newLinked;
	}

	public void RestructureLinkedListIntoDictionary(IDictionary<int,int> dict, ListNode head, int iterator = 0)
	{
		GoNext(dict, head, iterator);
	}

	public void GoNext(IDictionary<int, int> dict, ListNode current, int iterator = 0) 
	{
		dict.Add(iterator, current.val);
		iterator++;

		if (current.next is null)
		{
			return;
		}
		GoNext(dict, current.next, iterator);
	}

	public void StructureLinked(int[] values, ListNode previous, int currentIndex, int capacity)
	{
		previous.val = values[currentIndex];
		currentIndex++;

		if (currentIndex >= capacity)
		{
			return;
		}

		previous.next = new ListNode();

		StructureLinked(values, previous.next, currentIndex, capacity);
	}
}

