using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/559/
// difficult
namespace LCProblems.Arrays.Easy
{
    public class PlusOne
    {
        public static void run()
        {
            var arr = PlusOneInArr(new int[] { 4, 3, 2, 1 });
            Console.WriteLine(string.Join(',', arr));   //[4,3,2,2]

            arr = PlusOneInArr(new int[] { 0 });
            Console.WriteLine(string.Join(',', arr)); //[1]

            arr = PlusOneInArr(new int[] { 1,9,9,9 });
            Console.WriteLine(string.Join(',', arr));   //[2,0,0,0]

            arr = PlusOneInArr(new int[] { 9, 9, 9, 9 });
            Console.WriteLine(string.Join(',', arr));   //[1,0,0,0,0]

            arr = PlusOneInArr(new int[] { 2, 4, 9, 3, 9 });
            Console.WriteLine(string.Join(',', arr));   //[2, 4, 9, 4, 0]
        }
        static int[] PlusOneInArr(int[] digits)
        {
            int i;
            var res = new List<int>();
            for (i = digits.Length - 1; i >= 0 && digits[i] == 9; i--)
                res.Insert(0, 0);
                //res.Add(0);
            if (i < 0) {
                res.Insert(0, 1);
                //res.Add(1);
            }
            else
            {
                //res.Add(digits[i] + 1);
                res.Insert(0, digits[i] + 1);
                i--;
                for (; i >= 0; i--)
                    res.Insert(0, digits[i]);
                    //res.Add(digits[i]);
            }
            //res.Reverse();                // time complexity is increasing if we do reverse so avoid it by inserting elements at first position as above
            return res.ToArray();
        }
    }
}
