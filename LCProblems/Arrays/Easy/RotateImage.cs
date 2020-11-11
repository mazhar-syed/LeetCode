using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/770/
namespace LCProblems.Arrays.Easy
{
    public class RotateImage
    {
        public static void run()
        {
            var arr = new int[][]
            {
                new int[]{ 1, 2, 3 },
                new int[]{ 4, 5, 6 },
                new int[]{ 7, 8, 9 } 
            };
            Rotate(arr);
            disp(arr);

            arr = new int[][]
            {
                new int[]{5, 1, 9, 11 },
                new int[]{2,4,8,10 },
                new int[]{13,3,6,7 },
                new int[]{15,14,12,16 }
            };
            Rotate(arr);
            disp(arr);
        }
        static void disp(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Rotate1(int[][] matrix)
        {
            int rowstart = 0, rowend = matrix.Length - 1;
            int colstart = 0, colend = matrix[0].Length - 1;
            while(rowstart != rowend && colstart != colend)
            {
                //first place corners to right positions
                int rscs = matrix[rowstart][colstart];
                matrix[rowstart][colstart] = matrix[rowend][colstart];
                matrix[rowend][colstart] = matrix[rowend][colend];
                matrix[rowend][colend] = matrix[rowstart][colend];
                matrix[rowstart][colend] = rscs;

                if (rowstart+1 == rowend && colstart+1 == colend) break;

                //then place sides - total 4 sides
                //put left/start column/side into temp list
                var firstCol = new List<int>();
                for (int i = rowstart + 1; i <= rowend - 1; i++)
                    firstCol.Add(matrix[i][colstart]);

                //now fill left/first column with last row
                for (int i = rowstart + 1; i <= rowend - 1; i++)
                    matrix[i][colstart] = matrix[rowend][i];

                //now fill last row with last col
                var lastCol = new List<int>();
                for (int i = colend - 1; i >= colstart + 1; i--)
                    lastCol.Add(matrix[i][colend]);
                for(int i = colstart+1, li = 0; i <= colend-1; i++,li++)
                    matrix[rowend][i] = lastCol[li];

                //now fill last col with first row
                for (int i = rowend - 1; i >= rowstart + 1; i--)
                    matrix[i][colend] = matrix[rowstart][i];

                //now fill first row with first col
                int ind = 0;
                for (int i = colend - 1; i >= colstart + 1; i--)
                    matrix[rowstart][i] = firstCol[ind++];

                rowstart++; rowend--;
                colstart++; colend--;

                if (rowstart == rowend && colstart == colend && rowstart == colstart) break;
            }
           
        }

        static void Rotate(int[][] matrix)
        {
            int arrLen = matrix.Length;

            //convert rows into cols
            for (int i = 0; i < arrLen; i++)
            {
                for (int j = i; j < arrLen; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            disp(matrix);

            //reverse each row
            for (int i = 0; i < arrLen; i++)
            {
                for (int j = 0; j < arrLen / 2; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[i][arrLen - 1 - j];
                    matrix[i][arrLen - 1 - j] = temp;
                }
            }
            disp(matrix);       
        }
    }
}

/*
5,  1,  9,  11      11, 14, 44, 41, 11;   12  24  43  31  12 ;  13  34  42  21  13;  
2,  4,  8,  10      22  23  33  32  22
13, 3,  6,   7
15, 14, 12, 16

15, 13, 2,  5
14,  3, 4,  1
12,  6, 8,  9
16,  7, 10, 11
=============================
1,  2,  3,   4,  5          11  15  55  51  11;   12  25  54  41  12;   13  35  53  31  13;   14  45  52  21  14 
6,  7,  8,   9,  10         22  24  44  42  22;   23  34  43  32  23;   
11, 12, 13, 14,  15         33
16, 17, 18, 19,  20             51  55  15  11;  41  54  25  12;  31  53  35  13;  21  52  45  14;   
21, 22, 23, 24,  25

21, 16, 11,  6,  1
22, 17, 12,  7,  2
23, 18, 13,  8,  3
24, 19, 14,  9,  4
25, 20, 15, 10,  5

21, 2,  3,   4,  1
22, 7,  8,   9,  2         
23, 12, 13, 14,  3         
24, 17, 18, 19,  4         
25, 20, 15, 10,  5

rs = 1 re = 3
cs = 1 ce = 3

rs = 2 re 2
cs = 2 ce 2
======================
 5  1  9  11
 2  4  8  10
13  3  6  7
15  14 12 16

15 13  2  5
14  4  8  1
12  3  6  9
16  7  10 11

 */
