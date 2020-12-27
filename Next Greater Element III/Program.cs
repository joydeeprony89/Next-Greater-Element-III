using System;

namespace Next_Greater_Element_III
{
    // https://leetcode.com/problems/next-greater-element-iii/discuss/101824/Simple-Java-solution-(4ms)-with-explanation.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NextGreaterElement(534976));
        }

        static int NextGreaterElement(int n)
        {
            char[] nums = n.ToString().ToCharArray();
            int i, j;
            // I) Start from the right most digit and 
            // find the first digit that is
            // smaller than the digit next to it.
            for (i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i - 1] <= nums[i]) break;
            }

            // If no such digit is found, its the edge case 1.
            if (i == 0) return -1; // scenari when input is desc sorted , eg - 4321

            // II) Find the smallest digit on right side of (i-1)'th 
            // digit that is greater than number[i-1]
            char smallElement = nums[i - 1];
            int smallIndex = i;
            for (j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] > smallElement && nums[j] <= nums[smallIndex]) smallIndex = j;
            }

            // III) Swap the above found smallest digit with 
            // number[i-1]
            char c = nums[i - 1];
            nums[i - 1] = nums[smallIndex];
            nums[smallIndex] = c;

            // IV) Sort the digits after (i-1) in ascending order
            Array.Sort(nums, i, nums.Length - i);
            int val;
            return Int32.TryParse(new string(nums), out val) ? val : -1;
        }
    }
}
