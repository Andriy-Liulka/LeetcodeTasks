//https://leetcode.com/problems/divide-two-integers/

namespace DivideTwoIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {

            var number = new Solution().Divide(10, 3); //Expected: 3
            var number2 = new Solution().Divide(-10, 3); // Expected -3
            var number3 = new Solution().Divide(21, -3); // Expected -7
            var number4 = new Solution().Divide(1, 2); // Expected 0
            var number5 = new Solution().Divide(-1, 1); // Expected -1
            var number6 = new Solution().Divide(-2147483648, -1); // Expected 2147483647
            var number7 = new Solution().Divide(-2147483648, 1); // Expected -2147483648
            var number8 = new Solution().Divide(-2147483648, -1); // Expected  2147483647
        }
    }

    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            int sign = (dividend > 0) ^ (divisor > 0) ? -1 : 1;
            bool bothNegative = (dividend < 0) | (divisor < 0);

            var tempdividend = (long)dividend;
            var tempdivisor = (long)divisor;

            if (sign == -1 || bothNegative)
            {
                tempdividend = Math.Abs(tempdividend);
                tempdivisor = Math.Abs(tempdivisor);
            }

            if (tempdividend == tempdivisor)
            {
                return 1 * sign;
            }
            else if(tempdividend == 0 || tempdivisor > tempdividend)
            {
                return 0;
            }
            else if (tempdivisor ==  1)
            {
                return ValidateOverflow(tempdividend * sign);
            }

            long quotient = 0;
            do
            {
                tempdividend -= tempdivisor;
                quotient++;
            } while (tempdividend >= tempdivisor);

            var result = quotient * sign;

            return (int)result;
        }

        private int ValidateOverflow(long value)
        {
            if (value > Int32.MaxValue)
            {
                value = Int32.MaxValue;
            }
            else if (value < Int32.MinValue)
            {
                value = Int32.MinValue;
            }

            return (int)value;
        }
    }
}
