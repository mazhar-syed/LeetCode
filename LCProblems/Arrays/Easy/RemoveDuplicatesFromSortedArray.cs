using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/727/
namespace LCProblems.Arrays
{
    public class RemoveDuplicatesFromSortedArray
    {
        public static void Run()
        {
            var nums = new int[] { 1, 1, 2 };   
            int len1 = RemoveDuplicates(nums);  //Output: 2, nums = [1,2]
            Console.Write(len1 + ", ");
            for (int i = 0; i < len1; i++) Console.Write(nums[i] + " ");
            Console.WriteLine();

            nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int len2 = RemoveDuplicates(nums);  //Output: 5, nums = [0,1,2,3,4]
            Console.Write(len2 + ", ");
            for (int i = 0; i < len2; i++) Console.Write(nums[i] + " ");
            Console.WriteLine();

            //no duplicates
            nums = new int[] { 0, 5, 8, 9, 13, 14 };
            int len3 = RemoveDuplicates(nums);  //Output: 6, nums = [ 0, 5, 8, 9, 13, 14]
            Console.Write(len3 + ", ");
            for (int i = 0; i < len3; i++) Console.Write(nums[i] + " ");
            Console.WriteLine();

            //with negatives
            nums = new int[] { -20, -7, -7, 1, 1, 1, 3, 3, 4 };
            int len4 = RemoveDuplicates(nums);  //Output: 5, nums = [-20,-7, 1, 3, 4]
            Console.Write(len4 + ", ");
            for (int i = 0; i < len4; i++) Console.Write(nums[i] + " ");
            Console.WriteLine();

            //with empty array
            nums = new int[] {};
            int len5 = RemoveDuplicates(nums);  //Output: 0
            Console.Write(len5);
            Console.WriteLine();
        }

        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            int curr = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[curr - 1]) 
                    nums[curr++] = nums[i];
            }

            return curr;
        }
    }
}
