namespace Domain;

public class Game
{
    private Dice _dice1;
    private Dice _dice2;
    private readonly List<int> _highscores = new();

    public int Eye1 => _dice1.Dots;
    public int Eye2 => _dice2.Dots;
    public bool HasSnakeEyes => Eye1 == 1 && Eye2 == 1;

    public int Total { get; private set; }
    public IReadOnlyList<int> HighScores => _highscores.AsReadOnly();

    public Game()
    {
        Initialze();
    }

    public void Play()
    {
        _dice1.Roll();
        _dice2.Roll();
        if (HasSnakeEyes)
        {
            _highscores.Add(Total);
            Total = 0;
        }
        Total += Eye1 + Eye2;
    }

    private void Initialze()
    {
        _dice1 = new Dice();
        _dice2 = new Dice();
    }
    public void Restart()
    {
        Initialze();
    }
}
