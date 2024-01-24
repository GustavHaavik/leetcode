using utils;

namespace solutions;

public class PseudoPalindrome
{
    public int PseudoPalindromicPaths(TreeNode root)
    {
        return PseudoPalindromicPaths(root, new int[10]);
    }

    private int PseudoPalindromicPaths(TreeNode? root, int[] count)
    {
        if (root == null) return 0;

        count[root.val]++;

        // We have reached a leaf node
        if (root.left == null && root.right == null)
        {
            int odd = 0;
            for (int i = 1; i < count.Length; i++)
                if (count[i] % 2 == 1) odd++;

            count[root.val]--;
            return odd <= 1 ? 1 : 0;
        }

        int left = PseudoPalindromicPaths(root.left, count);
        int right = PseudoPalindromicPaths(root.right, count);

        count[root.val]--;

        return left + right;
    }
}