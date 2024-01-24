using utils;

namespace solutions;

public class FindModeBST(TreeNode root)
{
    private readonly TreeNode root = root;

    int currentVal = int.MinValue;
    int currentCount = 0;
    int maxCount = 0;

    public int[] FindMode()
    {
        List<int> modes = [];

        CountOccurrences(root, modes);

        return [.. modes];
    }

    private void CountOccurrences(TreeNode node, List<int> modes)
    {
        if (node == null) return;

        // First recur on left child
        CountOccurrences(node.left, modes);

        // If this is the first occurrence of this value
        if (node.val != currentVal)
        {
            currentVal = node.val;
            currentCount = 0;
        }

        currentCount++;

        if (currentCount > maxCount)
        {
            maxCount = currentCount;
            modes.Clear();
            modes.Add(currentVal);
        }
        else if (currentCount == maxCount)
        {
            modes.Add(currentVal);
        }

        // Now recur on right child
        CountOccurrences(node.right, modes);
    }
}