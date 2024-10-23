using System;

namespace LeetCode
{
    // medium 2: Вам даны два непустых связанных списка, представляющих два неотрицательных целых числа.
    // Цифры хранятся в обратном порядке , и каждый из их узлов содержит одну цифру.
    // Сложите два числа и верните сумму в виде связанного списка.
    // ref: https://leetcode.com/problems/add-two-numbers/
    public static class Program
    {
        public static void Main(string[] args)
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(9, null)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(9))));
            AddTwoNumbers(l1, l2);

            Console.ReadKey();
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int transfer = 0;
            ListNode result = null;
            while (l1 != null || l2 != null)
            {
                (int val, transfer) = Sum(l1?.val ?? 0, l2?.val ?? 0, transfer);
                var nextResult = new ListNode(val, result);
                result = nextResult;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (transfer != 0)
                result = new ListNode(transfer, result);

            Reverse(result, out ListNode resultFirst);
            return resultFirst;
        }

        static ListNode Reverse(ListNode node, out ListNode first, bool isFirstCall = true)
        {
            bool isLast = node.next is null;

            if (isLast)
            {
                first = node;
                return node;
            }

            var parent = Reverse(node.next, out first, false);
            parent.next = node;

            if (isFirstCall)
                node.next = null;

            return node;
        }

        static (int val, int transfer) Sum(int val1, int val2, int prevTransfer)
        {
            var sum = val1 + val2 + prevTransfer;

            var val = sum > 9 ? sum - 10 : sum;
            var transfer = sum > 9 ? 1 : 0;

            return (val, transfer);
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
    }
}