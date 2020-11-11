using System;
using System.Collections.Generic;
using System.Text;
//https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/564/
namespace LCProblems.Arrays
{
    public class BestTimeToBuyAndSellStock
    {
        public static void Run()
        {
            Console.WriteLine(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));   //7
            Console.WriteLine(MaxProfit(new int[] { 1, 2, 3, 4, 5 }));      //4
            Console.WriteLine(MaxProfit(new int[] { 7, 6, 4, 3, 1 }));      //0
            Console.WriteLine(MaxProfit(new int[] { 2, 2, 5 }));          //3
            Console.WriteLine(MaxProfit(new int[] { 2, 5, 5 }));          //3
            Console.WriteLine(MaxProfit(new int[] { 2, 5, 5, 1, 4 }));    //6
        }

        static int MaxProfit(int[] prices)
        {
            int profit = 0;
            int buy = 0, sell = 0;
            int i = 0;
            while(i < prices.Length - 1)
            {
                while (i < prices.Length - 1 && prices[i] > prices[i + 1]) i++;
                buy = prices[i];
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1]) i++;
                sell = prices[i];

                profit += sell - buy;
            }
            return profit;
        }

        static int MaxProfit1(int[] prices)
        {
            int profit = 0;
            int buy = -1;
            for(int i  = 0; i < prices.Length; i++)
            {
                if(buy == -1 && (((i > 0 && prices[i] <= prices[i-1]) || i <= 0) && 
                    (( (i+1 < prices.Length) && prices[i] < prices[i+1]) || (i+1 >= prices.Length))
                  ))
                {
                    buy = i; 
                    i = i + 1;
                }
                 
                if (buy >= 0 && i < prices.Length && (((i > 0 && prices[i] > prices[i - 1]) || i <= 0) &&
                    (((i + 1 < prices.Length) && prices[i] >= prices[i + 1]) || (i + 1 >= prices.Length))
                  ))
                {
                    profit += prices[i] - prices[buy];
                    buy = -1;
                }
            }
            return profit;
        }
    }
}
