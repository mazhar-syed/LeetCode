using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/549/
namespace LCProblems.Arrays
{
    public class SingleNumber   
    {
        public static void run()
        {
            Console.WriteLine(SingleNumberInArr(new int[] { 2, 2, 1 } ));    //1
            Console.WriteLine(SingleNumberInArr(new int[] { 4, 1, 2, 1, 2 } ));    //4
            Console.WriteLine(SingleNumberInArr(new int[] { 1 } )); //1
            Console.WriteLine(SingleNumberInArr(new int[] { 1, 2, 3, 4, 1, 3, 2 } ));    //4
        }

        static int SingleNumberInArr(int[] nums)
        {
            int uniqueNum = nums[0];
            for (var i = 1; i < nums.Length; i++) uniqueNum = uniqueNum ^ nums[i];
            return uniqueNum;
        }
        static int SingleNumberInArr1(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach(var n in nums)
                if (counts.ContainsKey(n)) counts[n] = counts[n] + 1;
                else counts.Add(n, 1);
            
            foreach(var key in counts.Keys)
                if (counts[key] == 1) return key;

            return -1;
        }
    }
}
// XOR one by one number 
// 1 ^ 1 = 0 , 
// 4 ^ 0 = 4,
//so 1 ^ 1 ^ 4 => 4
