namespace solutions;

public class FindModeBST(FindModeBST.TreeNode root)
{
    private readonly TreeNode root = root;

    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode Left { get; set; } = left;
        public TreeNode Right { get; set; } = right;

        public override string ToString()
        {
            string leftStr = Left != null ? Left.ToString() : "null";
            string rightStr = Right != null ? Right.ToString() : "null";

            return $"[{val},{leftStr},{rightStr}]".Replace(",,", ",");
        }
    }

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
        CountOccurrences(node.Left, modes);

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
        CountOccurrences(node.Right, modes);
    }
}