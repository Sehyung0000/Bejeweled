using BeJeweled;

int boardSize = 8;

GemBoard board = new GemBoard();
ScoreKeeper scorer = new ScoreKeeper();

board.init(boardSize);
scorer.reset();

Console.WriteLine("=== BeJeweled Demo ===");
Console.WriteLine("Board initialized: " + boardSize + "x" + boardSize);
Console.WriteLine("Starting score: " + scorer.getScore());
Console.WriteLine();

Console.WriteLine("[Initial Board]");
for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("[Swap / Revert Demo]");
Console.WriteLine("Swapping (0,0) and (0,1)");
board.swap(0, 0, 0, 1);

for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Reverting swap");
board.revertSwap(0, 0, 0, 1);

for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("[Force a Match]");
board.getGrid().set(0, 0, new Gem(GemType.RED));
board.getGrid().set(0, 1, new Gem(GemType.RED));
board.getGrid().set(0, 2, new Gem(GemType.RED));

for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
    }

    Console.WriteLine();
}

Console.WriteLine();
List<List<Position>> matches = board.findMatches();
Console.WriteLine("Match groups found: " + matches.Count);

for (int i = 0; i < matches.Count; i++)
{
    Console.Write("Group " + (i + 1) + ": ");

    foreach (Position position in matches[i])
    {
        Console.Write("(" + position.r + "," + position.c + ") ");
    }

    Console.WriteLine();
}

Console.WriteLine();
int cleared = board.clearMatches(matches);
scorer.addPoints(cleared, 1);
Console.WriteLine("Cleared gems: " + cleared);
Console.WriteLine("Score after clear: " + scorer.getScore());
Console.WriteLine();

Console.WriteLine("[After clearMatches]");
for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        if (board.getGrid().isEmpty(r, c))
        {
            Console.Write(".   ");
        }
        else
        {
            Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
        }
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("[After dropGems]");
board.dropGems();

for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        if (board.getGrid().isEmpty(r, c))
        {
            Console.Write(".   ");
        }
        else
        {
            Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
        }
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("[After refillGems]");
board.refillGems();

for (int r = 0; r < boardSize; r++)
{
    for (int c = 0; c < boardSize; c++)
    {
        Console.Write(board.getGrid().get(r, c).ToString().PadRight(4));
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Has remaining match? " + board.hasMatch());
Console.WriteLine("Final score: " + scorer.getScore());
