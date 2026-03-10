using BeJeweled;

int boardSize = 8;

GemBoard board = new GemBoard();
ScoreKeeper scorer = new ScoreKeeper();

board.init(boardSize);
scorer.reset();

Console.WriteLine();
Console.WriteLine("BeJeweled board initialized.");
Console.WriteLine("Board size: " + boardSize + "x" + boardSize);
Console.WriteLine("Starting score: " + scorer.getScore());
