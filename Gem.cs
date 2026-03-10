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
}
