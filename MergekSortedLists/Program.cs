namespace MergekSortedLists;
public class Program
{
	public static void Main(string[] args)
	{
		var linkedList1 = new ListNode[] { new ListNode(1, new ListNode(4, new ListNode(5))), new ListNode(1, new ListNode(3, new ListNode(4))), new ListNode(2, new ListNode(6)) };
		var linkedList2 = new ListNode[] { null };
		var linkedList3 = new ListNode[] { null, new ListNode(-1, new ListNode(5, new ListNode(11))),null, new ListNode(6, new ListNode(10)) };
		var sortedLinkedList1 = new Solution().MergeKLists(linkedList1);
		var sortedLinkedList2 = new Solution().MergeKLists(linkedList2);
		var sortedLinkedList3 = new Solution().MergeKLists(linkedList3);

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
class Enumerator
{
    public int Index { get; set; }
    public bool Finished { get; set; }

	public Enumerator(int index, bool finished)
	{
		Index = index;
		Finished = finished;
	}
}
public class Solution
{
	public ListNode MergeKLists(ListNode[] lists)
	{
		var linkedListsIterators = new Enumerator[lists.Length];

		var finishedLinkedLists = 0;

		ListNode sortedLinkedList = new ListNode(0, null);

		for (int i = 0; i < lists.Length; i++)
		{
			if (lists[i] is null)
			{
				linkedListsIterators[i] = new Enumerator(0, true);
				finishedLinkedLists++;
			}
			else
			{
				linkedListsIterators[i] = new Enumerator(0, false);
			}
		}

		while (finishedLinkedLists != lists.Length)
		{
			int chosenArrayIndex = default;
			int? theSmallestElement = default;
			bool isLastElem = false;
			for (int i = 0; i < linkedListsIterators.Length; i++)
			{
				if (linkedListsIterators[i].Finished)
				{
					continue;
				}
				var (elem, isTheEnd) = GetNLinkedListElemAndWhetherEnd(lists[i], linkedListsIterators[i].Index);
				if(theSmallestElement > elem || theSmallestElement is null)
				{
					theSmallestElement = elem;
					chosenArrayIndex = i;
					if (isTheEnd)
					{
						isLastElem = true;
					}
					else
					{
						isLastElem = false;
					}
				}
			}
			if (isLastElem)
			{
				linkedListsIterators[chosenArrayIndex].Finished = true;
				finishedLinkedLists++;
			}

			linkedListsIterators[chosenArrayIndex].Index++;
			AddLinkedListElem(sortedLinkedList, new ListNode(theSmallestElement ?? 0));

		}

		return sortedLinkedList.next;
	}

	public (int, bool) GetNLinkedListElemAndWhetherEnd(ListNode linkedList, int n)
	{
		return Iterator(n, 0, linkedList);

		(int, bool) Iterator(int n, int iteration, ListNode linkedList)
		{
			if (n == iteration)
			{
				return (linkedList.val, linkedList.next is null);
			}
			return Iterator(n, ++iteration, linkedList.next ?? throw new NullReferenceException("Next elem doesn't exist"));
		}
	}

	public void AddLinkedListElem(ListNode linkedList, ListNode elem)
	{
		if (linkedList.next is null)
		{
			linkedList.next = elem;
			return;
		}
		AddLinkedListElem(linkedList.next, elem);
	}
}