using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode___30_Day_Challange.Week_2
{
    /// <summary>
    /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
    ///     * push(x) -- Push element x onto stack.
    ///     * pop() -- Removes the element on top of the stack.
    ///     * top() -- Get the top element.
    ///     * getMin() -- Retrieve the minimum element in the stack.
    ///     
    /// Your MinStack object will be instantiated and called as such:
    /// MinStack obj = new MinStack();
    /// obj.Push(x);
    /// obj.Pop();
    /// int param_3 = obj.Top();
    /// int param_4 = obj.GetMin();
    ///
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3292/
    /// </remarks>
    /// 
    #region MinStack with Value Tuple

    public class MinStacks : IMinStacks
    {
        private readonly Stack<(int Value, int Min)> stack = new Stack<(int, int)>();

        public void Push(int newValue)
        {
            int min = (this.stack.Any()) switch
            {
                true => Min(newValue, this.GetMin()),
                false => newValue
            };

            (int, int) node = new ValueTuple<int, int>(newValue, min);
            this.stack.Push(node);
        }

        public void Pop() => _ = this.stack.Any() ? this.stack.Pop().Value : int.MinValue;

        public int Top() => this.stack.Any() ? this.stack.Peek().Value : int.MinValue;

        public int GetMin() => this.stack.Any() ? this.stack.Peek().Min : int.MinValue;

        private static int Min(int x, int y)
        {
            return (y > x) switch
            {
                true => x,
                false => y
            };
        }
    }

    #endregion

    #region MinStack with 2 stacks

    /// <remaks>
    /// This one is faster
    /// </remaks>
    public class MinStack2 : IMinStacks
    {
        private readonly Stack<int> minStack = new Stack<int>();
        private readonly Stack<int> valStack = new Stack<int>();

        public void Push(int newValue)
        {
            int min = (minStack.Any()) switch
            {
                true => Min(newValue, minStack.Peek()),
                false => newValue
            };

            minStack.Push(min);
            valStack.Push(newValue);
        }

        public void Pop()
        {
            _ = valStack.Any() ? valStack.Pop() : 0;
            _ = minStack.Any() ? minStack.Pop() : 0;
        }

        public int Top() => valStack.Any() ? valStack.Peek() : int.MinValue;

        public int GetMin() => minStack.Any() ? minStack.Peek() : int.MinValue;

        private static int Min(int newValue, int oldMin)
        {
            return (newValue < oldMin) switch
            {
                true => newValue,
                false => oldMin
            };
        }
    }

    #endregion
}
