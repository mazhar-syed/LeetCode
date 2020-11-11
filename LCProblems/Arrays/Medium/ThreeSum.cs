using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/776/
namespace LCProblems.Arrays.Medium
{
    public class ThreeSum
    {
        static void disp(IList<IList<int>> triplets)
        {
            foreach (var list in triplets)
            {
                Console.Write("[");
                foreach (var item in list)
                    Console.Write(item + ",");
                Console.Write("],  ");
            }
                
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void run()
        {
            disp(ThreeSumInArr(new int[] { 0, 0, 0, 1, 2, 1 }));    //[0,0,0]
            disp(ThreeSumInArr(new int[] { -1, 0, 1, 2, -1, -4 }));    //[[-1,-1,2], [-1,0,1]]

            disp(ThreeSumInArr(new int[] {  }));    //[]
            disp(ThreeSumInArr(new int[] { 0 }));    //[]

            disp(ThreeSumInArr(new int[] { 1, 2, 3, 4, 5 }));    //[]
            disp(ThreeSumInArr(new int[] { -1, -2, -3, -4, -5 }));    //[]
            disp(ThreeSumInArr(new int[] { -2, 0, 0, 2, 2 }));    //[-2, 0, 2]
            disp(ThreeSumInArr(new int[] { 0, 0, 0, 0 }));    //[0, 0, 0]
            disp(ThreeSumInArr(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 }));
            //[[-4,0,4],[-4,1,3],  [-3,-1,4],[-3,0,3],[-2,-1,3],  [-3,1,2],[-2,0,2],[-1,-1,2],[-1,0,1]]
            disp(ThreeSumInArr(new int[] {-4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0 }));
            //[[-5,1,4],[-4,0,4],[-4,1,3],[-2,-2,4],[-2,1,1],  [0,0,0]]
        }

        static IList<IList<int>> ThreeSumInArr(int[] nums)
        {
            IList<IList<int>> returnLists = new List<IList<int>>();
            HashSet<string> uniqueTripletsSet = new HashSet<string>();
            HashSet<int> remUnique = new HashSet<int>();

            var listRem = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) listRem.Add(i, 0 - (nums[i]));

            foreach (var rkey in listRem.Keys)
            {
                if (remUnique.Contains(listRem[rkey])) continue;
                remUnique.Add(listRem[rkey]);

                int target = listRem[rkey];
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == rkey) continue;
                    var rem = target - (nums[i]);
                    if (map.ContainsKey(rem) && (nums[rkey] + nums[i] + rem) == 0)
                    {
                        var newTriplets = new List<int>() { nums[rkey], nums[i], rem };
                        newTriplets.Sort();
                        var key = newTriplets[0].ToString() + "-" + newTriplets[1].ToString() + "-" + newTriplets[2].ToString();
                        if (!uniqueTripletsSet.Contains(key))
                        {
                            uniqueTripletsSet.Add(key);
                            returnLists.Add(newTriplets);
                        }
                    }
                    if (!map.ContainsKey(nums[i])) map.Add(nums[i], i);
                }
            }   
            return returnLists;
        }

        static void TwoSumInArr(int[] nums, int target, int skipi, int val1, IList<IList<int>> returnLists, HashSet<string> uniqueTripletsSet)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == skipi) continue;
                var rem = target - (nums[i]);
                if (map.ContainsKey(rem) && (val1 + nums[i] + rem)==0)
                { 
                    var newTriplets = new List<int>() { val1, nums[i], rem };
                    newTriplets.Sort();
                    var key = newTriplets[0].ToString() + "-" + newTriplets[1].ToString() + "-" + newTriplets[2].ToString();
                    if (!uniqueTripletsSet.Contains(key))
                    {
                        uniqueTripletsSet.Add(key);
                        returnLists.Add(newTriplets);
                    }
                }
                if (!map.ContainsKey(nums[i])) map.Add(nums[i], i);
            }
        }

        static IList<IList<int>> ThreeSumInArr1(int[] nums)
        {
            IList<IList<int>> returnLists = new List<IList<int>>();

            var listRem = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++) listRem.Add(i, 0 - (nums[i]));

            foreach(var rkey in listRem.Keys)
            {
                var rem = listRem[rkey];
                var dict = new Dictionary<int, int>();
                for(int i = 0; i < nums.Length; i++)
                {
                    if (rkey == i) continue;
                    var otherRem = rem - (nums[i]);
                    if (dict.ContainsKey(otherRem)) {
                        bool used = false;
                        foreach(var list in returnLists)
                        {
                            if (nums[rkey] == 0 && nums[i] == 0 && otherRem == 0)
                            {
                                if (!(list[0] == 0 && list[1] == 0 && list[2] == 0)) continue;
                            }
                            if(list.Contains(nums[rkey]) && list.Contains(nums[i]) && list.Contains(otherRem))
                            {
                                used = true; break;
                            }
                        }

                        if (used) continue;
                        else returnLists.Add(new List<int>() { nums[rkey], nums[i], otherRem });
                    }
                    if (!dict.ContainsKey(nums[i])) dict.Add(nums[i], i);
                }
            }
            return returnLists;
        }
    }
}
