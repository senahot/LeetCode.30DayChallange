namespace LeetCode___30_Day_Challange.Week_2
{
    public interface IMinStacks
    {
        int GetMin();
        void Pop();
        void Push(int newValue);
        int Top();
    }
}