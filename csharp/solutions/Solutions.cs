using System.Text;
using utils;

namespace solutions;

public class Solutions
{
    public static void FindLongestChain()
    {
        Console.WriteLine("Find Longest Chain");
        int[][] pairs = [[1, 2], [2, 3], [3, 4]];
        Console.WriteLine("Input: {0}", pairs.Select(p => $"[{p[0]}, {p[1]}]").Aggregate((a, b) => $"{a}, {b}"));
        int result = FindLongestChain(pairs);
        Console.WriteLine($"Result: {result}");
    }

    private static int FindLongestChain(int[][] pairs)
    {
        Array.Sort(pairs, (a, b) => a[1] - b[1]);
        var count = 0;
        var end = int.MinValue;
        foreach (var pair in pairs)
        {
            if (pair[0] > end)
            {
                end = pair[1];
                count++;
            }
        }
        return count;
    }

    public static void FrogJump()
    {
        Console.WriteLine("Frog Jump");
        int[] stones = [0, 1, 3, 5, 6, 8, 12, 17];
        Console.WriteLine("Input: {0}", stones.Select(s => $"{s}").Aggregate((a, b) => $"{a}, {b}"));
        bool result = FrogJump(stones, true);
        Console.WriteLine($"Result: {result}");
    }

    private static bool FrogJump(int[] stones, bool timeComplexity = false)
    {
        if (timeComplexity)
        {
            bool[,] mem = new bool[stones.Length, stones.Length];
            return Cross(stones, 0, 0);
            bool Cross(int[] stones, int jl, int pos)
            {
                if (mem[pos, jl]) return false;
                if (pos == stones.Length - 1) return true;

                int a = pos;
                while (++a < stones.Length && (stones[a] - stones[pos]) - jl < 2)
                {
                    if ((stones[a] - stones[pos]) - jl > -2)
                        if (Cross(stones, (stones[a] - stones[pos]), a)) return true;
                }
                mem[pos, jl] = true;
                return false;
            }
        }
        else
        {
            bool[,] cached = new bool[stones.Length, stones.Length];

            bool CanCross(int jumpLength, int pos)
            {
                // To prevent stack overflow (infinite loop)
                // This state has been visited before
                if (cached[pos, jumpLength]) return false;
                // We have reached the end
                if (pos == stones.Length - 1) return true;

                int start = pos;
                int currentStone;
                int jumpDistance;

                while (++start < stones.Length)
                {
                    currentStone = stones[start];
                    jumpDistance = currentStone - stones[pos];

                    bool isJumpPossible = jumpDistance - jumpLength > -2 && jumpDistance - jumpLength < 2;

                    if (isJumpPossible && CanCross(jumpDistance, start))
                    {
                        return true;
                    }
                }

                cached[pos, jumpLength] = true;
                return false;
            }

            return CanCross(0, 0);
        }
    }

    public static void MyStack()
    {
        Console.WriteLine("My Stack");
        MyStack<int> stack = new();
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine($"Top: {stack.Top()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Empty: {stack.Empty()}");
    }

    public static void SkyLine()
    {
        Console.WriteLine("Sky Line");
        int[][] buildings = [
            [1,2,1],[1,2,2],[1,2,3]
        ];
        Console.WriteLine("Input: {0}", buildings.Select(b => $"[{b[0]}, {b[1]}, {b[2]}]").Aggregate((a, b) => $"{a}, {b}"));
        var skyLine = new SkyLine(buildings);
        var result = skyLine.GetSkyLine();
        Console.WriteLine($"Result: ");
    }

    public static void Rob()
    {
        Console.WriteLine("Rob");
        int[] nums = [1, 2, 3, 1];
        Console.WriteLine("Input: {0}", nums.Select(n => $"{n}").Aggregate((a, b) => $"{a}, {b}"));
        int result = Rob(nums);
        Console.WriteLine($"Result: {result}");
    }

    private static int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int[] result = new int[nums.Length];
        result[0] = nums[0];
        result[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            result[i] = Math.Max(result[i - 1], result[i - 2] + nums[i]);
        }

        return result[nums.Length - 1];
    }

    public static void FindModeBST()
    {
        Console.WriteLine("Find Mode BST");
        TreeNode root = new(1, null, new TreeNode(2, new TreeNode(2), null));
        FindModeBST findModeBST = new(root);

        Console.WriteLine("Input: {0}", root.ToString());
        int[] result = findModeBST.FindMode();
        Console.WriteLine($"Result: {result.Select(r => $"{r}").Aggregate((a, b) => $"{a}, {b}")}");
    }

    public static void IsSubSequence()
    {
        Console.WriteLine("Is Sub Sequence");
        string s1 = "abc";
        string s2 = "ahbgdc";
        Console.WriteLine("Input: {0}, {1}", s1, s2);
        bool result = IsSubSequence(s1, s2);
        Console.WriteLine($"Result: {result}");
    }

    private static bool IsSubSequence(string s, string t)
    {
        if (string.IsNullOrEmpty(s)) return true;
        if (string.IsNullOrEmpty(t)) return false;

        int i = 0, j = 0;

        do
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
            }
            else
            {
                j++;
            }
        } while (i < s.Length && j < t.Length);

        return i == s.Length;
    }

    public static void FindErrorInNums()
    {
        Console.WriteLine("Find Error In Nums");
        int[] nums = [1, 2, 2, 4];
        Console.WriteLine("Input: {0}", nums.Select(n => $"{n}").Aggregate((a, b) => $"{a}, {b}"));
        int[] result = FindErrorInNums(nums);
        Console.WriteLine($"Result: {result.Select(r => $"{r}").Aggregate((a, b) => $"{a}, {b}")}");
    }

    private static int[] FindErrorInNums(int[] nums)
    {
        int[] result = new int[2];
        // Occurences of each number
        int[] count = new int[nums.Length + 1];

        foreach (var num in nums) count[num]++;

        for (int i = 1; i < count.Length; i++)
        {
            // If a number has not occured, it is missing
            if (count[i] == 0) result[1] = i;
            // If a number has occured twice, it is the duplicate
            else if (count[i] == 2) result[0] = i;
        }

        return result;
    }

    public static void ReverseWord()
    {
        Console.WriteLine("Reverse Word");
        string s = "Let's take LeetCode contest";
        Console.WriteLine("Input: {0}", s);
        string result = ReverseWord(s);
        Console.WriteLine($"Result: {result}");
    }

    private static string ReverseWord(string s)
    {
        var words = s.Split(' ');
        var result = new StringBuilder();
        foreach (var word in words)
        {
            result.Append(Reverse(word));
            result.Append(' ');
        }
        return result.ToString().Trim();
    }

    private static string Reverse(string s)
    {
        var result = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            result.Append(s[i]);
        }
        return result.ToString();
    }

    public static void FindMaxConcatenatedString()
    {
        Console.WriteLine("Find Max Concatenated String");
        string[] arr = ["cha", "r", "act", "ers"];
        Console.WriteLine("Input: {0}", arr.Select(a => $"{a}").Aggregate((a, b) => $"{a}, {b}"));
        int result = MaxLength(arr);
        Console.WriteLine($"Result: {result}");
    }

    private static int MaxLength(IList<string> arr)
    {
        return Dfs(arr, "", 0);
    }

    private static int Dfs(IList<string> arr, string path, int idx)
    {
        if (path.Length != path.Distinct().Count()) return 0;

        int maxLen = path.Length;
        for (int i = idx; i < arr.Count; i++)
            maxLen = Math.Max(maxLen, Dfs(arr, path + arr[i], i + 1));

        return maxLen;
    }

    // private static bool IsUniqueCharStr(string str)
    // {
    //     int[] count = new int[26];
    //     foreach (char c in str)
    //     {
    //         if (count[c - 'a']++ > 0)
    //         {
    //             return false;
    //         }
    //     }
    //     return true;
    // }

    public static void CountNicePairs()
    {
        Console.WriteLine("Count Nice Pairs");
        int[] nums = [42, 11, 1, 97];
        Console.WriteLine("Input: {0}", nums.Select(n => $"{n}").Aggregate((a, b) => $"{a}, {b}"));
        int result = CountNicePairs(nums);
        Console.WriteLine($"Result: {result}");
    }

    private static int CountNicePairs(int[] nums)
    {
        int count = 0;

        Dictionary<int, int> map = [];
        int MOD = 1000000007;

        foreach (var num in nums)
        {
            int diff = num - Rev(num);

            if (map.TryGetValue(diff, out int value))
            {
                count = (count + value) % MOD;
                map[diff] = value + 1;
            }
            else
            {
                map[diff] = 1;
            }
        }

        return count;
    }

    private static int Rev(int num)
    {
        int reverse = 0;
        while (num > 0)
        {
            reverse = (reverse * 10) + (num % 10);
            num /= 10;
        }
        return reverse;
    }

    public static void PseudoPalindrome()
    {
        Console.WriteLine("Pseudo Palindrome");
        TreeNode root = new(2, new TreeNode(3, new TreeNode(3), new TreeNode(1)), new TreeNode(1, null, new TreeNode(1)));
        var pseudoPalindrome = new PseudoPalindrome();

        Console.WriteLine("Input: {0}", root.ToString());
        int result = pseudoPalindrome.PseudoPalindromicPaths(root);
        Console.WriteLine($"Result: {result}");
    }
}