//https://leetcode.com/problems/best-time-to-buy-and-sell-stock-v/description/




var maximumProfit = function(prices, k) {
    const firstPrice = prices[0];
    const dp = Array(k + 1).fill(null).map(() => ({
        maxProfit: 0,
        buyHold: -firstPrice,
        sellHold: firstPrice
    }));
    const n = prices.length;
    
    for (let day = 1; day < n; day++) {
        const currPrice = prices[day];
        for (let trans = k; trans > 0; trans--) {
            const prevProfit = dp[trans - 1].maxProfit;
            dp[trans].maxProfit = Math.max(dp[trans].maxProfit, dp[trans].buyHold + currPrice, dp[trans].sellHold - currPrice);
            dp[trans].buyHold = Math.max(dp[trans].buyHold, prevProfit - currPrice);
            dp[trans].sellHold = Math.max(dp[trans].sellHold, prevProfit + currPrice);
        }
    }
    
    return dp[k].maxProfit;
};

var res1 = maximumProfit([1, 7, 9, 8, 2], 2) //14
var res2 = maximumProfit([12, 16, 19, 19, 8, 1, 19, 13, 9], 3) //36
var res3 = maximumProfit([3,8,9,6,4], 2) //10
var res4 = maximumProfit([5,8], 1) //3
var res5 = maximumProfit([1,10], 1) //9
var res6 = maximumProfit([2,3,2,3,2,3,2,3], 4) //4
var res7 = maximumProfit([6,11,1,5,3,15,8], 3) //22
//12+5+4
//7
console.log('End');