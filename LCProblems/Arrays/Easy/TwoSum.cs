using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/
// difficult
namespace LCProblems.Arrays.Easy
{
    public class TwoSum
    {
        public static void run()
        {
            var res = TwoSumInArr(new int[] { 2, 7, 11, 15 }, 9);
            Console.WriteLine(string.Join(',', res));   //0,1

            res = TwoSumInArr(new int[] { 3, 2, 4 }, 6);
            Console.WriteLine(string.Join(',', res));   //1,2

            res = TwoSumInArr(new int[] { 3, 3 }, 6);
            Console.WriteLine(string.Join(',', res));   //0,1

            res = TwoSumInArr(new int[] { 3, 3, 5, 9, 1, 8, 5, 6 }, 17);
            Console.WriteLine(string.Join(',', res));   //3,5

            res = TwoSumInArr(new int[] { 14, 3, 5, 9, 1, 8, 5, 6 }, 17);
            Console.WriteLine(string.Join(',', res));   //0,1

            res = TwoSumInArr(new int[] { 14, 4, 5, 9, 3, 1, 8, 15, 6 }, 17);
            Console.WriteLine(string.Join(',', res));   //0,4

            res = TwoSumInArr(new int[] { 19, 5, 14, 9, -3, -1, 18, 15, 6 }, 13);
            Console.WriteLine(string.Join(',', res));   //2,5
        }

        static int[] TwoSumInArr(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                var rem = target - (nums[i]);
                if (map.ContainsKey(rem)) return new int[] { i, map[rem] };
                if(!map.ContainsKey(nums[i])) map.Add(nums[i], i);
            }
            return new int[] { };
        }
        static int[] TwoSumInArr1(int[] nums, int target)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
                if (map.ContainsKey(nums[i])) map[nums[i]].Add(i);
                else map.Add(nums[i], new List<int>() { i });

            for (int i = 0; i < nums.Length; i++)
            {
                int rem = target - (nums[i]);
                if(map.ContainsKey(rem))
                {
                    if( map[rem].Count == 1)
                    {
                        if (map[rem][0] != i) return new int[] { i, map[rem][0] };
                        else continue;
                    } 
                    else
                    {
                        foreach(var ind in map[rem])
                            if(ind != i) return new int[] { i, ind };
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
}

/*

2,7,11,15 : target = 9
7,2,-2,-6

0,  1, 2, 3, 4, 5, 6, 7, 8 
14, 4, 5, 9, 3, 1, 8, 5, 6 :  17 
3, 13,12, 8,14,16, 9,12,11 

*/