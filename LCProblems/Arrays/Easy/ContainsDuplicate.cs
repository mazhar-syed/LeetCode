using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/578/
namespace LCProblems.Arrays
{
    public class ContainsDuplicate
    {
        public static void run()
        {
            Console.WriteLine(ContainsDuplicateInArr(new int[] { 1, 2, 3, 1 }));    //true
            Console.WriteLine(ContainsDuplicateInArr(new int[] { 1, 2, 3, 4 }));    //false
            Console.WriteLine(ContainsDuplicateInArr(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 })); //true
        }
        static bool ContainsDuplicateInArr(int[] nums)
        {
            HashSet<int> hashset = new HashSet<int>();
            foreach (var n in nums) hashset.Add(n);
            return hashset.Count != nums.Length;
        }
    }
}
