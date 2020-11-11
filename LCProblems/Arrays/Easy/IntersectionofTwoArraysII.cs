using System;
using System.Collections.Generic;
using System.Text;

namespace LCProblems.Arrays.Easy
{
    public class IntersectionofTwoArraysII
    {
        public static void run()
        {
            var res1 = Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2,2 });  //2,2
            Console.WriteLine(string.Join(',', res1));

            var res2 = Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }); //4,9
            Console.WriteLine(string.Join(',', res2));

            var res3 = Intersect(new int[] { 1, 4, 4, 4, 5 }, new int[] { 2, 5, 5, 4, 4, 4, 8 });   
            Console.WriteLine(string.Join(',', res3));  //4,4,4,5

            var res4 = Intersect(new int[] { 1, 4, 4, 4, 5, 5 }, new int[] { 2, 5, 5, 5, 7, 4, 8, 10 });   
            Console.WriteLine(string.Join(',', res4)); //4,5,5
        }

        static int[] Intersect(int[] nums1, int[] nums2)
        {
            var res = new List<int>();
            var dic1 = new Dictionary<int, int>();
            var dic2 = new Dictionary<int, int>();
            foreach(var n in nums1)
            {
                if (dic1.ContainsKey(n)) dic1[n] += 1;
                else dic1.Add(n, 1);
            }
            foreach (var n in nums2)
            {
                if (dic2.ContainsKey(n)) dic2[n] += 1;
                else dic2.Add(n, 1);
            }

            foreach(var k1 in dic1.Keys)
            {
                if (!dic2.ContainsKey(k1)) continue;

                int cnt = Math.Min(dic1[k1], dic2[k1]);
                for (int i = 0; i < cnt; i++) res.Add(k1);
            }

            return res.ToArray();
        }

        static int[] Intersect1(int[] nums1, int[] nums2)
        {
            if (nums1.Length <= 0 || nums2.Length <= 0) return new int[] { };

            var res = new List<int>();
            Array.Sort(nums1);
            Array.Sort(nums2);

            int p1=0, p2=0;
            while (true)
            {
                if (nums1[p1] == nums2[p2])
                {
                    res.Add(nums2[p2]);
                    p1++;
                    p2++;
                }
                else if (nums1[p1] < nums2[p2]) p1++;
                else p2++;
                if (p1 >= nums1.Length || p2 >= nums2.Length) break;
            }
            return res.ToArray();
        }
    }
}

//sort both the arrays first.
//use dictionaries or hashmaps
//3, 4, 4, 4, 5, 5 
//2, 4, 5, 5, 5, 7, 8, 10
