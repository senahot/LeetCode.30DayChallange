using LeetCode___30_Day_Challange.Week_2;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace LeetCode___NUnit
{
    public class MinStackTeste
    {
        [Test]
        public void MinStacks_BasicTest()
        {
            IMinStacks stack = new MinStacks();
            BasicTest(stack, out int min1, out int top, out int min2);

            Assert.That(-3 == min1);
            Assert.That(0 == top);
            Assert.That(-2 == min2);
        }

        [Test]
        public void MinStack2_BasicTest()
        {
            IMinStacks stack = new MinStack2();
            BasicTest(stack, out int min1, out int top, out int min2);

            Assert.That(-3 == min1);
            Assert.That(0 == top);
            Assert.That(-2 == min2);
        }

        [Test]
        public void MinStacks_TopDonRemoveMin()
        {
            IMinStacks stack = new MinStacks();
            TopDonRemoveMin(stack, out int min1, out int top, out int min2);

            Assert.That(int.MinValue == min1);
            Assert.That(2 == top);
            Assert.That(2 == min2);
        }

        [Test]
        public void MinStack2_TopDonRemoveMin()
        {
            IMinStacks stack = new MinStack2();
            TopDonRemoveMin(stack, out int min1, out int top, out int min2);

            Assert.That(int.MinValue == min1);
            Assert.That(2 == top);
            Assert.That(2 == min2);
        }

        [Test]
        public void BenchMark()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            IMinStacks stack1 = new MinStacks();
            BenchMark_Cenario(stack1, out _, out _, out _);

            sw.Stop();
            var ticks1 = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();

            IMinStacks stack2 = new MinStack2();
            BenchMark_Cenario(stack2, out _, out _, out _);

            sw.Stop();
            var ticks2 = sw.ElapsedTicks;

            TestContext.WriteLine($"MinStack: {ticks2} {Environment.NewLine} MinStack2: {ticks1}");
        }

        private static void BasicTest(IMinStacks stack, out int min1, out int top, out int min2)
        {
            stack.Push(-2);
            stack.Push(0);
            stack.Push(-3);
            min1 = stack.GetMin();
            stack.Pop();
            top = stack.Top();
            min2 = stack.GetMin();
        }

        private static void BenchMark_Cenario(IMinStacks stack, out int min1, out int top, out int min2)
        {
            stack.Push(-2);

            for (int i = 0; i < 1000000; i++)
            {
                stack.Push(-2);
                i++;
            }

            stack.Push(0);
            stack.Push(-3);
            min1 = stack.GetMin();
            stack.Pop();
            top = stack.Top();
            min2 = stack.GetMin();
        }

        private static void TopDonRemoveMin(IMinStacks stack , out int min1, out int top, out int min2)
        {
            min1 = stack.GetMin();
            stack.Push(2);
            top = stack.Top();
            min2 = stack.GetMin();
        }
    }
}
