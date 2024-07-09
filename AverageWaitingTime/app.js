//https://leetcode.com/problems/average-waiting-time/description/?envType=daily-question&envId=2024-07-09
/** 
* @param {number[][]} customers
* @return {number}
*/
var averageWaitingTime = function (customers) {

    var waitingTimeCollector = [];
    var totalWaitTime = 0;
    var previousOperationFinishTime = customers[0][0];

    for (let customer of customers) {
        let arrangedTime = customer[0];
        let resolutionDurationTime = customer[1];

        let waitingTime = previousOperationFinishTime - arrangedTime + resolutionDurationTime;

        if (previousOperationFinishTime - arrangedTime < 0) {
            waitingTimeCollector.push(resolutionDurationTime);
            previousOperationFinishTime = arrangedTime + resolutionDurationTime;

            totalWaitTime += resolutionDurationTime;
        }
        else {
            waitingTimeCollector.push(waitingTime);
            previousOperationFinishTime = arrangedTime + waitingTime;

            totalWaitTime += waitingTime;
        }
    }

    return totalWaitTime / waitingTimeCollector.length;
};


var result1 = averageWaitingTime([[1, 2], [2, 5], [4, 3]]);

var result2 = averageWaitingTime([[5, 2], [5, 4], [10, 3], [20, 1]]);

var result3 = averageWaitingTime([[2, 3], [6, 3], [7, 5], [11, 3], [15, 2], [18, 1]]);
