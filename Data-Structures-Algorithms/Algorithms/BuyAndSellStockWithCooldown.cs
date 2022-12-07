using System;

namespace Data_Structures_Algorithms.Algorithms
{
    public class BuyAndSellStockWithCooldown
    {
        public void Test()
        {
            int[] prices = { 1, 2, 3, 0, 2 }; // Total is 3. Explanation: transactions = [buy, sell, cooldown, buy, sell]
            Console.WriteLine("Total profit is: " + MaxProfit(prices));
            Console.ReadLine();
        }

        private int MaxProfit(int[] prices)
        {
            //Case 1: Have a stock on day i (dp[i][1])
            // - Bought it today
            //      dp[i-2][0] - prices[i] (Cooldown)
            // - Do nothing
            //      dp[i-1][1] (Hold the stock)

            //Case 2: Does not have a stock on day i (dp[i][0]) 
            // - I sold it today
            //      dp[i-1][1] + prices[i]
            // - Do nothing
            //      dp[i-1][0] (Hold the stock)

            if (prices == null || prices.Length <= 1)
                return 0;


            var length = prices.Length;


            if (length == 2 && prices[1] > prices[0]) // Buy and sell one time
                return prices[1] - prices[0];
            else if (length == 2 && prices[0] > prices[1]) 
                return 0;


            //First and second day can´t be on the loop to calculate max profit, because it will be just one day to have profit
            int[,] dp = new int[length, 2]; //Two possibilities. We have or not have stock on the day
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];
            dp[1, 0] = Math.Max(dp[0, 0], dp[0, 1] + prices[1]);
            dp[1, 1] = Math.Max(dp[0, 1], dp[0, 0] - prices[1]);


            for (int i = 2; i < length; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]); //Selling
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 2, 0] - prices[i]); // Buying and setting one day for cooldown
            }

            return dp[length - 1, 0];
        }

        //Time complexity - O(n)
        //Space Complexity - 0(n)
    }
}
