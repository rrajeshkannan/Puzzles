// Final Array After Subarray Deletions
// You are given an integer array nums.
// Two players, Alice and Bob, play a game in turns, with Alice playing first.
// In each turn, the current player chooses any subarray nums[l..r] such that r - l + 1 < m, where m is the current length of the array.
// The selected subarray is removed, and the remaining elements are concatenated to form the new array.
// The game continues until only one element remains.
// Alice aims to maximize the final element, while Bob aims to minimize it. Assuming both play optimally, return the value of the final remaining element.
// A subarray is a contiguous non-empty sequence of elements within an array.
// Example 1:
// Input: nums = [1,5,2]
// Output: 2
// Explanation:
// One valid optimal strategy:
// Alice removes [1], array becomes [5, 2].
// Bob removes [5], array becomes [2]​​​​​​​. Thus, the answer is 2.
// Example 2:
// Input: nums = [3,7]
// Output: 7
// Explanation:
// Alice removes [3], leaving the array [7]. Since Bob cannot play a turn now, the answer is 7.
// Constraints:
// 1 <= nums.length <= 10^5
// 1 <= nums[i] <= 10^5

Console.WriteLine("Final Array After Subarray Deletions");
Console.WriteLine(new Solution().FinalElement(new int[] { 1, 5, 2 })); // Expected output: 2
Console.WriteLine(new Solution().FinalElement(new int[] { 3, 7 }));    // Expected output: 7
Console.WriteLine(new Solution().FinalElement(new int[] { 9, 1, 5, 3, 7 })); // Expected output: 5

public class Solution
{
    public int FinalElement(int[] nums)
    {
        var interim = new List<int>(nums);

        for (int turn = 0; interim.Count > 1; turn++)
        {
            int right = 1;

            for (; right < interim.Count - 1; right++)
            {
                if (turn % 2 == 0) // Alice's turn
                {
                    if (interim[right] > interim[right + 1])
                    {
                        // Keep larger elements for Alice
                        break;
                    }
                }
                else // Bob's turn
                {
                    if (interim[right] < interim[right + 1])
                    {
                        // Keep smaller elements for Bob
                        break;
                    }
                }
            }

            interim.RemoveRange(0, right - 1);
            interim.RemoveAt(0); // Remove the chosen element
        }

        return interim[0];
    }
}