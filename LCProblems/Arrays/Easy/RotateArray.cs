using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/646/
//difficult
namespace LCProblems.Arrays
{
    public class RotateArray
    {
        public static void Run()
        {
            Console.WriteLine(3 % 2);
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums, 3);    //[5,6,7,1,2,3,4]
            foreach (var e in nums) Console.Write(e + " ");
            Console.WriteLine();

            nums = new int[] { -1, -100, 3, 99 };
            Rotate(nums, 2);    //[3,99,-1,-100]
            foreach (var e in nums) Console.Write(e + " ");
            Console.WriteLine();

            nums = new int[] { 1 };
            Rotate(nums, 2);    //[1]
            foreach (var e in nums) Console.Write(e + " ");
            Console.WriteLine();

            nums = new int[] { 1, 2 };
            Rotate(nums, 3);    //[2, 1]
            foreach (var e in nums) Console.Write(e + " ");
            Console.WriteLine();
        }

        //One line of thought is based on reversing the array(or parts of it) to obtain the desired result.
        //Think about how reversal might potentially help us out by using an example.
        /*
            1,2,3,4,5,6,7
            7,6,5,4,3,2,1       rev
            5,6,7,1,2,3,4       rev parts (0 to k) (k to n)

            -1, -100, 3, 99
            99, 3, -100, -1     rev 
            3, 99, -1, 100      rev parts

            1,2
            2,1

            1,2,3,4
            4,3,2,1
            2,3,4,1
         */
        static void RotateBest(int[] nums, int k)       //best solution 
        {
            if (nums.Length <= 1) return;
            k %= nums.Length;
            if (k == 0) return;
            ReverseArr(nums, 0, nums.Length - 1);   //rev whole array
            ReverseArr(nums, 0, k - 1); //rev first part until k
            ReverseArr(nums, k, nums.Length - 1);   //rev next part after k to length
        }
        static void ReverseArr(int[] nums, int startI, int startJ)
        {
            for (int i = startI, j = startJ; i < j; i++, j--)
            {
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
            }
        }

        static void Rotate3(int[] nums, int k)
        {
            if (nums.Length <= 1) return;
            k %= nums.Length;
            var copyNums = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++) copyNums[i] = nums[i];
            
            int j = 0;
            for (int i = copyNums.Length - k; i < copyNums.Length; i++)
                nums[j++] = copyNums[i];

            for (int i = 0; i < copyNums.Length - k; i++)
                nums[j++] = copyNums[i];
        }

        static void Rotate2(int[] nums, int k)
        {
            k %= nums.Length;
            for (int r = 0; r < k; r++) 
            {
                int lastEle = nums[nums.Length - 1];
                for (int i = nums.Length - 1; i > 0; i--)
                    nums[i] = nums[i - 1];
                nums[0] = lastEle;
            }
        }

        static void Rotate(int[] nums, int k)
        {
            if (nums.Length <= 1) return;
            k %= nums.Length;
            if (k == 0) return;

            k %= nums.Length;
            int cnt = 0;
            for (int start = 0; cnt < nums.Length; start++)
            {
                int currIndex = start;
                int prev = nums[start];
                do
                {
                    int curr = prev;
                    var newIndex = (currIndex + k) % nums.Length;
                    int temp = nums[newIndex];
                    nums[newIndex] = curr;
                    prev = temp;
                    currIndex = newIndex;
                    cnt++;
                } while (currIndex != start);
            }
        }
    }
}

/*
1,2,3,4,5,6,7
_,2,3,1,5,6,7 c=4 isEmpty=1
_,2,3,1,5,6,4 c=7
_,2,7,1,5,6,4 c=3
_,2,7,1,5,3,4 c=6
_,6,7,1,5,3,4 c=2
_,6,7,1,2,3,4 c=5
5,6,7,1,2,3,4

1,2,3,4    k = 3
_,2,3,1 c=4
_,2,4,1 c=3
_,3,4,1 c=2
2,3,4,1 

1,2,3,4    k = 6 then k = k % arrlength => 6 % 4 => 2
4,1,2,3
3,4,1,2 == after 2nd rotation so apply % as above 
2,3,4,1
1,2,3,4
4,1,2,3
3,4,1,2 == after 6th rotation


-1, -100, 3, 99, k = 2
                 startIndex = 0
_, -100, -1, 99  newIndex = 2, prev = 3, correctlyPlacedCount = 1
3, -100, -1, 99  curr = none, curr is pointing to start index so break, correctlyPlacedCount = 2
                startIndex = 1
3, _, -1, -100  curr = 99, correctlyPlacedCount = 3
3, 99, -1, -100 curr is pointing to start index so break, correctlyPlacedCount = 4
 */
