using System;
using System.Collections.Generic;
using System.Text;

namespace LCProblems.Arrays.Easy
{
    public class MoveZeroes
    {
        public static void run()
        {
            var arr = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroesInArr(arr);   //[1,3,12,0,0]
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 1, 0, 2, 4, 0, 3 };
            MoveZeroesInArr(arr);   //[1,2,4,3,0,0]
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 0, 0, 0, 1, 2, 3, 0};
            MoveZeroesInArr(arr);   //[1,2,3,0,0,0,0]
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 0, 1, 0, 0, 0, 3, 0, 0, 7, 12 };
            MoveZeroesInArr(arr);   //[1,3,7,12,0,0,0,0,0,0]
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 0, 0, 0, 0, 0 };
            MoveZeroesInArr(arr);
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 0, 1, 3, 4, 2 };
            MoveZeroesInArr(arr); // [1,3,4,2,0]
            Console.WriteLine(string.Join(',', arr));

            arr = new int[] { 1, 3, 4, 2, 0, 0 };
            MoveZeroesInArr(arr); // [1,3,4,2,0,0]
            Console.WriteLine(string.Join(',', arr));
        }

        static void MoveZeroesInArr(int[] nums)
        {
            for (int i = 0, z = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int tmp = nums[z];
                    nums[z++] = nums[i];
                    nums[i] = tmp;
                }
            }
        }

        static void MoveZeroesInArr1(int[] nums)
        {
            for(int i = 0, z=-1; i < nums.Length; i++)
            {
                if(z==-1 && nums[i] == 0)
                {
                    z = i;
                    continue;
                }
                if (nums[i] != 0 && z != -1)
                {
                    nums[z++] = nums[i];
                    nums[i] = 0;
                }
            }
        }
    }
}
