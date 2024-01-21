namespace solutions;

public class SkyLine(int[][] buildings)
{
    private readonly int[][] buildings = buildings;

    public IList<IList<int>> GetSkyLine()
    {
        return GetSkyLine(buildings, 0, buildings.Length - 1);
    }

    private IList<IList<int>> GetSkyLine(int[][] buildings, int start, int end)
    {
        if (start == end)
        {
            List<IList<int>> skyLine =
            [
                [buildings[start][0], buildings[start][2]],
                [buildings[start][1], 0],
            ];

            return skyLine;
        }

        int mid = start + (end - start) / 2;
        IList<IList<int>> leftSkyLine = GetSkyLine(buildings, start, mid);
        IList<IList<int>> rightSkyLine = GetSkyLine(buildings, mid + 1, end);

        return MergeSkyLines(leftSkyLine, rightSkyLine);
    }

    private IList<IList<int>> MergeSkyLines(IList<IList<int>> leftSkyLine, IList<IList<int>> rightSkyLine)
    {
        int leftHeight = 0;
        int rightHeight = 0;
        int left = 0;
        int right = 0;
        int x = 0;
        int height = 0;
        List<IList<int>> skyLine = new();

        while (left < leftSkyLine.Count && right < rightSkyLine.Count)
        {
            if (leftSkyLine[left][0] < rightSkyLine[right][0])
            {
                x = leftSkyLine[left][0];
                leftHeight = leftSkyLine[left][1];
                left++;
            }
            else
            {
                x = rightSkyLine[right][0];
                rightHeight = rightSkyLine[right][1];
                right++;
            }

            height = Math.Max(leftHeight, rightHeight);
            if (skyLine.Count == 0 || height != skyLine[skyLine.Count - 1][1])
            {
                skyLine.Add([x, height]);
            }
        }

        while (left < leftSkyLine.Count)
        {
            skyLine.Add(leftSkyLine[left]);
            left++;
        }

        while (right < rightSkyLine.Count)
        {
            skyLine.Add(rightSkyLine[right]);
            right++;
        }

        for (int i = 0; i < skyLine.Count - 1; i++)
        {
            if (skyLine[i][0] == skyLine[i + 1][0])
            {
                skyLine[i][1] = Math.Max(skyLine[i][1], skyLine[i + 1][1]);
                skyLine.RemoveAt(i + 1);
                i--;
            }
        }

        return skyLine;
    }
}