namespace BeJeweled;

public class GemGrid
{
    private int size;
    private Gem?[][] cells;

    public GemGrid(int size)
    {
        this.size = size;
        cells = new Gem?[size][];

        for (int r = 0; r < size; r++)
        {
            cells[r] = new Gem?[size];
        }
    }

    public bool inBounds(int r, int c)
    {
        return r >= 0 && r < size && c >= 0 && c < size;
    }

    public Gem get(int r, int c)
    {
        return cells[r][c]!;
    }

    public void set(int r, int c, Gem g)
    {
        cells[r][c] = g;
    }

    public void swapCells(int r1, int c1, int r2, int c2)
    {
        Gem? temp = cells[r1][c1];
        cells[r1][c1] = cells[r2][c2];
        cells[r2][c2] = temp;
    }

    public bool isEmpty(int r, int c)
    {
        return cells[r][c] == null;
    }

    public void clearAt(int r, int c)
    {
        cells[r][c] = null;
    }

    public GemGrid clone()
    {
        GemGrid copy = new GemGrid(size);

        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                if (cells[r][c] != null)
                {
                    copy.set(r, c, new Gem(cells[r][c]!.getType()));
                }
            }
        }

        return copy;
    }
}
