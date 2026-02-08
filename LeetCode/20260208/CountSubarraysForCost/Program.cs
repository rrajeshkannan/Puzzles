// Count Subarrays with cost less than or equal to K
// You are given an integer array nums, and an integer k.
// For any subarray nums[l..r], define its cost as: cost = (max(nums[l..r]) - min(nums[l..r])) * (r - l + 1).
// Return an integer denoting the number of subarrays of nums whose cost is less than or equal to k.
// A subarray is a contiguous non-empty sequence of elements within an array.
//  
// Example 1:
// Input: nums = [1,3,2], k = 4
// Output: 5
// Explanation:
// We consider all subarrays of nums:
// nums[0..0]: cost = (1 - 1) * 1 = 0
// nums[0..1]: cost = (3 - 1) * 2 = 4
// nums[0..2]: cost = (3 - 1) * 3 = 6
// nums[1..1]: cost = (3 - 3) * 1 = 0
// nums[1..2]: cost = (3 - 2) * 2 = 2
// nums[2..2]: cost = (2 - 2) * 1 = 0
// There are 5 subarrays whose cost is less than or equal to 4.
//
// Example 2:
// Input: nums = [5,5,5,5], k = 0
// Output: 10
// Explanation:
// For any subarray of nums, the maximum and minimum values are the same, so the cost is always 0.
// As a result, every subarray of nums has cost less than or equal to 0.
// For an array of length 4, the total number of subarrays is (4 * 5) / 2 = 10.
//
// Example 3:
// Input: nums = [1,2,3], k = 0
// Output: 3
// Explanation:
// The only subarrays of nums with cost 0 are the single-element subarrays, and there are 3 of them.
//  
// Constraints:
// 1 <= nums.length <= 10^5
// 1 <= nums[i] <= 10^9
// 0 <= k <= 10^15

Console.WriteLine(new Solution().CountSubarrays([1, 3, 2], 4)); // 5
Console.WriteLine(new Solution().CountSubarrays([5, 5, 5, 5], 0)); // 10
Console.WriteLine(new Solution().CountSubarrays([1, 2, 3], 0)); // 3

public class Solution
{
    private void AddMonotonic(LinkedList<int> deque, int[] nums, int index, bool isMax)
    {
        // Remove elements that are no longer useful for maintaining monotonic property:
        // For max deque: remove smaller/equal values (they can never be max if a larger value comes later)
        // For min deque: remove larger/equal values (they can never be min if a smaller value comes later)
        while (deque.Count > 0)
        {
            bool shouldRemove = isMax
                ? nums[deque.Last!.Value] <= nums[index]
                : nums[deque.Last!.Value] >= nums[index];
            if (shouldRemove) deque.RemoveLast();
            else break;
        }
        deque.AddLast(index);
    }

    public long CountSubarrays(int[] nums, long k)
    {
        // How Monotonic Deques work:
        // "Monotonic" = consistently one direction (mono=one, tonic=direction)
        // 
        // maxDeque maintains DECREASING order of VALUES (front = maximum):
        //   We only store indices whose values are potentially useful as future max.
        //   When a new larger value arrives, smaller values can never be max again, so remove them.
        //   Always: nums[maxDeque[0]] >= nums[maxDeque[1]] >= nums[maxDeque[2]] >= ...
        //   Result: Front always gives us the MAX value in O(1) time!
        //
        // minDeque maintains INCREASING order of VALUES (front = minimum):
        //   We only store indices whose values are potentially useful as future min.
        //   When a new smaller value arrives, larger values can never be min again, so remove them.
        //   Always: nums[minDeque[0]] <= nums[minDeque[1]] <= nums[minDeque[2]] <= ...
        //   Result: Front always gives us the MIN value in O(1) time!
        //
        // Example progression with nums=[4,6,2,8,1], k=12:
        // 
        // right=0, num=4: maxDeque=[0(4)], minDeque=[0(4)] 
        //                 window[0,0]: cost=0 --- OK
        //
        // right=1, num=6: maxDeque=[1(6)], minDeque=[0(4)]  ← Removed 0 from maxDeque (4<6)
        //                 window[0,1]: cost=(6-4)*2=4 --- OK
        //
        // right=2, num=2: maxDeque=[1(6),2(2)], minDeque=[2(2)]  ← MONOTONIC: 6≥2! 
        //                 window[0,2]: cost=(6-2)*3=12 --- OK
        //
        // right=3, num=8: maxDeque=[3(8)], minDeque=[2(2)]  ← Removed indices 0,1 from maxDeque (values 4,6 < 8)
        //                 window[0,3]: cost=(8-2)*4=24 > 12 --- NOK
        //                 Shrink to left=2: window[2,3]: cost=(8-2)*2=12 --- OK
        //
        // right=4, num=1: maxDeque=[3(8),4(1)], minDeque=[4(1)]  ← MONOTONIC: 8≥1!
        //                 window[2,4]: cost=(8-1)*3=21 > 12 --- NOK
        //                 Shrink to left=4: window[4,4]: cost=0 --- OK
        //
        // monotonic property + sliding window = O(n) time complexity!

        var maxDeque = new LinkedList<int>();
        var minDeque = new LinkedList<int>();
        long count = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            // Expand window: add current element and maintain monotonic property
            AddMonotonic(maxDeque, nums, right, true);
            AddMonotonic(minDeque, nums, right, false);

            // Shrink window from left while cost exceeds k
            while ((long)(nums[maxDeque.First!.Value] - nums[minDeque.First!.Value]) * (right - left + 1) > k)
            {
                // Remove left index from deques if it's no longer in the window
                // WHY THIS WORKS:
                // - We only store "useful" indices in deques (via AddMonotonic cleanup)
                // - Front of deque = current max/min in window [left, right]
                // - When we move left→left+1, any index < left is now OUTSIDE the window
                // - If front.Value == left, that index is outside, so remove it
                // - After removal, the next front is guaranteed to be inside [left+1, right]
                // - This check is O(1) because we only look at the front!
                if (maxDeque.First.Value == left) maxDeque.RemoveFirst();
                if (minDeque.First.Value == left) minDeque.RemoveFirst();
                left++;
            }

            // All subarrays ending at 'right' with start index in [left, right] are valid
            count += right - left + 1;
        }

        return count;
    }
}

// === THREE GOLDEN DISCIPLINES FOR O(n) OPTIMALITY ===
// 
// DISCIPLINE 1: KEEP ONLY RELEVANT ELEMENTS
//   AddMonotonic() discards dominated indices immediately
//   Result: Deque contains only indices that could be max/min
//
// DISCIPLINE 2: CHANGE WINDOW ONLY WHEN STATE CHANGES  
//   Expand right: add new element
//   Shrink left: only when cost > k
//   Never change unnecessarily!
//
// DISCIPLINE 3: ACCESS ONLY THE DATA YOU NEED
//   Check front only—don't scan the deque
//   Trust invariants—if front is valid, rest are too
//   Each index removed at most once = O(n) total
//
// Pattern: Tight Invariants → Minimal State Changes → O(n) Algorithm

// KEY INSIGHT: Left pointer only moves right (never backtracks)!
// This is why left+right = 2n max operations = O(n) total time!