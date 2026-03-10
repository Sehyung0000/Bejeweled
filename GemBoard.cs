namespace BeJeweled;

public class GemBoard
{
    private GemGrid grid = null!;
    private int size;

    public void init(int size)
    {
        this.size = size;
        grid = new GemGrid(size);

        do
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    GemType randomType = (GemType)Random.Shared.Next(0, 6);
                    grid.set(r, c, new Gem(randomType));
                }
            }
        }
        while (hasMatch());
    }

    public void swap(int r1, int c1, int r2, int c2)
    {
        grid.swapCells(r1, c1, r2, c2);
    }

    public void revertSwap(int r1, int c1, int r2, int c2)
    {
        grid.swapCells(r1, c1, r2, c2);
    }

    public List<List<Position>> findMatches()
    {
        List<List<Position>> matches = new List<List<Position>>();

        for (int r = 0; r < size; r++)
        {
            int c = 0;

            while (c < size)
            {
                if (grid.isEmpty(r, c))
                {
                    c++;
                    continue;
                }

                GemType currentType = grid.get(r, c).getType();
                int start = c;

                while (c + 1 < size &&
                       !grid.isEmpty(r, c + 1) &&
                       grid.get(r, c + 1).getType() == currentType)
                {
                    c++;
                }

                int length = c - start + 1;

                if (length >= 3)
                {
                    List<Position> group = new List<Position>();

                    for (int col = start; col <= c; col++)
                    {
                        group.Add(new Position { r = r, c = col });
                    }

                    matches.Add(group);
                }

                c++;
            }
        }

        for (int c = 0; c < size; c++)
        {
            int r = 0;

            while (r < size)
            {
                if (grid.isEmpty(r, c))
                {
                    r++;
                    continue;
                }

                GemType currentType = grid.get(r, c).getType();
                int start = r;

                while (r + 1 < size &&
                       !grid.isEmpty(r + 1, c) &&
                       grid.get(r + 1, c).getType() == currentType)
                {
                    r++;
                }

                int length = r - start + 1;

                if (length >= 3)
                {
                    List<Position> group = new List<Position>();

                    for (int row = start; row <= r; row++)
                    {
                        group.Add(new Position { r = row, c = c });
                    }

                    matches.Add(group);
                }

                r++;
            }
        }

        return matches;
    }

    public int clearMatches(List<List<Position>> matches)
    {
        bool[,] shouldClear = new bool[size, size];

        foreach (List<Position> group in matches)
        {
            foreach (Position position in group)
            {
                if (grid.inBounds(position.r, position.c))
                {
                    shouldClear[position.r, position.c] = true;
                }
            }
        }

        int cleared = 0;

        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                if (shouldClear[r, c] && !grid.isEmpty(r, c))
                {
                    grid.clearAt(r, c);
                    cleared++;
                }
            }
        }

        return cleared;
    }

    public void dropGems()
    {
        for (int c = 0; c < size; c++)
        {
            int writeRow = size - 1;

            for (int r = size - 1; r >= 0; r--)
            {
                if (!grid.isEmpty(r, c))
                {
                    Gem gem = grid.get(r, c);
                    grid.set(writeRow, c, gem);

                    if (writeRow != r)
                    {
                        grid.clearAt(r, c);
                    }

                    writeRow--;
                }
            }

            while (writeRow >= 0)
            {
                grid.clearAt(writeRow, c);
                writeRow--;
            }
        }
    }

    public void refillGems()
    {
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                if (grid.isEmpty(r, c))
                {
                    GemType randomType = (GemType)Random.Shared.Next(0, 6);
                    grid.set(r, c, new Gem(randomType));
                }
            }
        }
    }

    public bool hasMatch()
    {
        return findMatches().Count > 0;
    }

    public GemGrid getGrid()
    {
        return grid;
    }
}
