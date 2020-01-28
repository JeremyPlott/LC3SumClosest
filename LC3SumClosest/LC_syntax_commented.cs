using System;

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {

        //it's important to get the array sorted so we can efficiently work with it
        Array.Sort(nums);

        //initiating the variable with the sum of the largest three numbers in the set now that it's sorted
        var closestThreeSum = nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3];

        //it's called squishingSide for fun, but this is basically the leftmost side of our sets, our minimum value.
        //We increment this each iteration, and then use the other two pointers to home in on the closest
        //sum of the three numbers. The array gets squished in by one each time.
        for (int squishingSide = 0; squishingSide < nums.Length - 2; squishingSide++)
        {
            //these will be our two pointers that we use to search for the best set of numbers
            var leftPointer = squishingSide + 1;
            var rightPointer = nums.Length - 1;

            //do this as long as the two pointers don't overlap
            while (leftPointer < rightPointer)
            {
                //we need to track the sum of the current three numbers
                int threeSum = nums[squishingSide] + nums[leftPointer] + nums[rightPointer];

                //initiating two variables to keep track of how close the current sum of numbers is,
                //and how close the best set of numbers we have so far is
                var currentDistance = Math.Abs(threeSum - target);
                var currentBest = Math.Abs(closestThreeSum - target);

                //if we hit the target right on the money, stop everything and return the value
                if (currentDistance == 0) return threeSum;

                //if our current set of numbers is closer than our best so far, update the best set
                if (currentDistance < currentBest)
                {
                    closestThreeSum = threeSum;
                }

                //if our sum is larger than the target, we need to make it smaller and vice-versa.
                //we do that by making the highest number smaller, or the smallest number larger.
                //this is how our two pointers home in on the target efficiently.
                if (threeSum > target) rightPointer--;
                if (threeSum < target) leftPointer++;
            }
        }

        return closestThreeSum;
    }
}