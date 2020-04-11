using System.Text;

namespace LeetCode___30_Day_Challange.Week_2
{
    /// <summary>
    /// Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
    /// </summary>
    /// <remarks>
    /// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3291/
    /// </remarks>
    public static class BackSpaceStringCompare
    {
        private const char BackSpace = '#';

        #region BackspaceCompare_1

        /// <remarks>
        /// Space Complexity: O(M+N)
        /// Time  Complexity: O(M+N)
        /// </remarks>
        public static bool BackspaceCompare_1(string S, string T)
        {
            string newS = GetNewString(S);
            string newT = GetNewString(T);

            return newS.Equals(newT);
        }

        public static string GetNewString(string S)
        {
            StringBuilder newS = new StringBuilder();
            int jump = 0;

            for (int i = S.Length - 1; i > -1; i--)
            {
                if (S[i] == BackSpace)
                {
                    jump++;
                }
                else
                {
                    if (jump == 0)
                    {
                        newS.Append(S[i]);
                    }

                    jump = jump == 0 ? 0 : jump - 1;
                }
            }

            return newS.ToString();
        }

        #endregion

        #region BackspaceCompare_2

        /// <remarks>
        /// Space Complexity: O(1)
        /// Time  Complexity: O(M+N)
        /// </remarks>
        public static bool BackspaceCompare_2(string s, string t)
        {
            int sIterator = s.Length;
            int tIterator = t.Length;

            while (true)
            {
                sIterator = GetNewIndex(s, sIterator - 1);
                tIterator = GetNewIndex(t, tIterator - 1);

                if (sIterator < 0 && tIterator < 0)
                {
                    return true;
                }

                if (sIterator < 0 || tIterator < 0 || s[sIterator] != t[tIterator])
                {
                    return false;
                }
            }
        }

        private static int GetNewIndex(string s, int index)
        {
            int jump = 0;

            while (index > -1)
            {
                if (s[index].Equals(BackSpace))
                {
                    jump++;
                }
                else if (--jump < 0)
                {
                    return index;
                }

                index--;
            }

            return index;
        }

        #endregion
    }
}
