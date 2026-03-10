namespace BeJeweled;

public class ScoreKeeper
{
    private int score;

    public void reset()
    {
        score = 0;
    }

    public void addPoints(int cleared, int cascadeIndex)
    {
        if (cleared <= 0)
        {
            return;
        }

        if (cascadeIndex < 1)
        {
            cascadeIndex = 1;
        }

        score += cleared * 100 * cascadeIndex;
    }

    public int getScore()
    {
        return score;
    }
}
