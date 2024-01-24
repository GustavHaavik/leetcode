namespace utils;

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)

{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;

    public override string ToString()
    {
        string leftStr = left != null ? left.ToString() : "null";
        string rightStr = right != null ? right.ToString() : "null";

        return $"[{val},{leftStr},{rightStr}]".Replace(",,", ",");
    }
}
