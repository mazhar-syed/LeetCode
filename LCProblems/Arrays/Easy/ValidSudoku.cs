using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/769/
namespace LCProblems.Arrays.Easy
{
    public class ValidSudoku
    {
        public static void run()
        {
            var arr = new char[][] {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            var res = IsValidSudoku(arr);
            Console.WriteLine(res);
            res = IsValidSudoku(new char[][]
            {
                new char[] {'8','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            });
            Console.WriteLine(res);
        }
        static bool IsValidSudoku(char[][] board)
        {
            //check entire line row or cols
            for (int i = 0; i < 9; i++)
            {
                var rowset = new HashSet<int>();
                var colset = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    if (rowset.Contains(board[i][j])) return false;
                    else
                        if (board[i][j] != '.') rowset.Add(board[i][j]);

                    if (colset.Contains(board[j][i])) return false;
                    else
                        if (board[j][i] != '.') colset.Add(board[j][i]);
                }
            }
            //check sub sets 3x3
            var subsets = new int[][]
            {
                new int[]{ 0, 0, 2, 2 },
                new int[]{ 0, 3, 2, 5 },
                new int[]{ 0, 6, 2, 8 },

                new int[]{ 3, 0, 5, 2 },
                new int[]{ 3, 3, 5, 5 },
                new int[]{ 3, 6, 5, 8 },

                new int[]{ 6, 0, 8, 2 },
                new int[]{ 6, 3, 8, 5 },
                new int[]{ 6, 6, 8, 8 }
            };
            foreach(var set in subsets)
                if (!checkSubSets(board, set[0], set[1], set[2], set[3])) return false;
            
            return true;
        }
        static bool checkSubSets(char[][] board, int x1, int y1, int x2, int y2)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                {
                    if (board[i][j] == '.') continue;
                    if (set.Contains(board[i][j])) return false;
                    else set.Add(board[i][j]);
                }
            return true;
        }
    }
}
