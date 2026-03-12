namespace BeJeweled;

public class Gem
{
    private GemType type;

    public Gem(GemType type)
    {
        this.type = type;
    }

    public GemType getType()
    {
        return type;
    }

    public override string ToString()
    {
        return type switch
        {
            GemType.RED => "🔴",
            GemType.BLUE => "🔵",
            GemType.GREEN => "🟢",
            GemType.YELLOW => "🟡",
            GemType.PURPLE => "🟣",
            GemType.ORANGE => "🟠",
            _ => "?"
        };
    }
}
