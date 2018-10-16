namespace Static
{
    using System;
    class Compare
    {
        /// <summary>
        /// Method normalize string comparisor for sort purposes
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int StringC(string A, string B)
        {
            int diff = String.CompareOrdinal(B, A);
            return diff > 0 ? 1 : (diff < 0 ? -1 : 0);
        }

        public static int IntC(int A, int B) => B > A ? 1 : (B < A ? -1 : 0);
    }
}
