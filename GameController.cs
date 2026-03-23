namespace BeJeweled;

public class GameController
{
    private readonly GemBoard board;
    private readonly MoveValidator validator;
    private readonly ScoreKeeper scorer;
    private GameState state;

    public GameController()
    {
        board = new GemBoard();
        validator = new MoveValidator();
        scorer = new ScoreKeeper();
        state = GameState.GAME_OVER;
    }

    public void newGame(int size)
    {
        board.init(size);
        scorer.reset();
        state = GameState.ACTIVE;
        updateGameState();
    }

    public bool requestSwap(int r1, int c1, int r2, int c2)
    {
        if (state != GameState.ACTIVE)
        {
            return false;
        }

        GemGrid grid = board.getGrid();

        if (!grid.inBounds(r1, c1) || !grid.inBounds(r2, c2))
        {
            return false;
        }

        if (!validator.isAdjacent(r1, c1, r2, c2))
        {
            return false;
        }

        board.swap(r1, c1, r2, c2);

        if (!board.hasMatch())
        {
            board.revertSwap(r1, c1, r2, c2);
            return false;
        }

        resolveBoard();
        updateGameState();
        return true;
    }

    public int resolveBoard()
    {
        int totalCleared = 0;
        int cascadeIndex = 1;

        while (true)
        {
            List<List<Position>> matches = board.findMatches();

            if (matches.Count == 0)
            {
                break;
            }

            int cleared = board.clearMatches(matches);

            if (cleared <= 0)
            {
                break;
            }

            scorer.addPoints(cleared, cascadeIndex);
            totalCleared += cleared;
            board.dropGems();
            board.refillGems();
            cascadeIndex++;
        }

        return totalCleared;
    }

    public void updateGameState()
    {
        state = validator.hasLegalMove(board.getGrid())
            ? GameState.ACTIVE
            : GameState.GAME_OVER;
    }

    public bool isGameOver()
    {
        return state == GameState.GAME_OVER;
    }

    public int getScore()
    {
        return scorer.getScore();
    }
}
