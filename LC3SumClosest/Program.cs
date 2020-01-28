using System;

namespace LC3SumClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {-1, 0, 1, 1, 55 };
            int target = 3;

            Console.WriteLine(ThreeSumClosest(nums, target));

            int ThreeSumClosest(int[] nums, int target)
            {
                Array.Sort(nums);

                var closestThreeSum = nums[nums.Length - 1] + nums[nums.Length - 2] + nums[nums.Length - 3];

                for (int squishingSide = 0; squishingSide < nums.Length - 2; squishingSide++)
                {
                    var leftPointer = squishingSide + 1;
                    var rightPointer = nums.Length - 1;

                    while (leftPointer < rightPointer)
                    {
                        int threeSum = nums[squishingSide] + nums[leftPointer] + nums[rightPointer];

                        var currentDistance = Math.Abs(threeSum - target);
                        var currentBest = Math.Abs(closestThreeSum - target);

                        if (currentDistance == 0) return threeSum;

                        if (currentDistance < currentBest)
                        {
                            closestThreeSum = threeSum;
                        }
                        
                        if (threeSum > target) rightPointer--;
                        if (threeSum < target) leftPointer++;
                    }                    
                }

                return closestThreeSum;
            }
        }
    }
}
