Console.Write("Write ur name: ");
var name = Console.ReadLine();
var date = DateTime.Now;
var score = 0;
var totalQuestions = 0;
List<GamePlayed> history = new();

Console.WriteLine($"Hello {name} it's {date} and this is a math game.");
while (true)
{
    Console.WriteLine("\n----------------------------------------\n");
    Console.WriteLine($@"Which game would you like to play?: 
    A - Addition
    S - Subtraction
    M - Multiplicaiton
    D - Division
    R - Random
    H - Present history of games played
    Q - Quit");
    Round();
}



void Round()
{
    while (true)
    {
        var choice = Console.ReadLine();
        choice = String.IsNullOrEmpty(choice) ? "" : choice.Trim().ToUpper();
        switch (choice)
        {
            case "A":
                AdditionGame();
                return;
            case "S":
                SubtractionGame();
                return;
            case "M":
                MultiplicatonGame();
                return;
            case "D":
                DivisionGame();
                return;
            case "R":
                RandomGame();
                return;
            case "H":
                PresentHistory();
                return;
            case "Q":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Unknown input, try again");
                break;
        }
    }
}


void PresentResults(DateTime start, int roundScore)
{
    TimeSpan roundDuration = DateTime.Now - start;
    Console.WriteLine(@$"
Round Score: {roundScore} / 10
You took {Math.Round(roundDuration.TotalSeconds, 2)} seconds
Ur total score {name} is {score} / {totalQuestions}");
}

void AdditionGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Console.WriteLine("You choose addition, begin!\n");
    for (int i = 0; i < 10; i++)
    {
        roundScore += Addition();
    }
    PresentResults(start, roundScore);
    history.Add(new GamePlayed(roundScore, "Addition"));
}

int Addition()
{
    int singleScore = 0;
    Random r = new();
    int a = r.Next(10), b = r.Next(10);
    Console.Write($"{a} + {b} = ");
    var answer = Console.ReadLine();
    var answerInt = -1;
    int.TryParse(answer, out answerInt);
    if (answerInt == a + b)
    {
        Console.WriteLine("Good!");
        score++;
        singleScore++;
    }
    else Console.WriteLine("Wrong :(");
    totalQuestions++;
    return singleScore;
}


void SubtractionGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Console.WriteLine("You choose subtraction, begin! \n");
    for (int i = 0; i < 10; i++)
    {
        roundScore += Subtraction();
    }
    PresentResults(start, roundScore);
    history.Add(new GamePlayed(roundScore, "Subtraction"));
}

int Subtraction()
{
    int singleScore = 0;
    Random r = new();
    int a = r.Next(5), b = r.Next(a, 10);
    Console.Write($"{b} - {a} = ");
    var answer = Console.ReadLine();
    var answerInt = -1;
    int.TryParse(answer, out answerInt);
    if (answerInt == b - a)
    {
        Console.WriteLine("Good!");
        score++;
        singleScore++;
    }
    else Console.WriteLine("Wrong :(");
    totalQuestions++;
    return singleScore;

}
void MultiplicatonGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Console.WriteLine("You choose multiplication, begin! \n");
    for (int i = 0; i < 10; i++)
    {
        roundScore += Multiplication();
    }
    PresentResults(start, roundScore);
    history.Add(new GamePlayed(roundScore, "Multiplication"));
}

int Multiplication()
{
    int singleScore = 0;
    Random r = new();
    int a = r.Next(10), b = r.Next(10);
    Console.Write($"{b} * {a} = ");
    var answer = Console.ReadLine();
    var answerInt = -1;
    int.TryParse(answer, out answerInt);
    if (answerInt == b * a)
    {
        Console.WriteLine("Good!");
        score++;
        singleScore += 1;
    }
    else Console.WriteLine("Wrong :(");
    totalQuestions++;
    return singleScore;
}
void DivisionGame()
{
    var roundScore = 0;
    DateTime start = DateTime.Now;
    Console.WriteLine("You choose division, begin! \n");
    for (int i = 0; i < 10; i++)
    {
        roundScore += Division();
    }
    PresentResults(start, roundScore);
    history.Add(new GamePlayed(roundScore, "Division"));
}

int Division()
{
    int singleScore = 0;
    Random r = new();
    int a = r.Next(1, 10), b = a * r.Next(10);
    Console.Write($"{b} / {a} = ");
    var answer = Console.ReadLine();
    var answerInt = -1;
    int.TryParse(answer, out answerInt);
    if (answerInt == b / a)
    {
        Console.WriteLine("Good!");
        score++;
        singleScore++;
    }
    else Console.WriteLine("Wrong :(");
    totalQuestions++;
    return singleScore;
}
void RandomGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Random r = new();
    for (int i = 0; i < 10; i++)
    {
        var a = r.Next(3);
        switch (a)
        {
            case 0:
                roundScore += Addition();
                break;
            case 1:
                roundScore += Subtraction();
                break;
            case 2:
                roundScore += Multiplication();
                break;
            case 3:
                roundScore += Division();
                break;
        }
    }
    PresentResults(start, roundScore);
    history.Add(new GamePlayed(roundScore, "Random"));
}

void PresentHistory()
{
    Console.WriteLine();
    foreach (var game in history) Console.WriteLine(game.ToString());
    Console.WriteLine($"\nOverall score: {score} / {totalQuestions} \n");
}


public struct GamePlayed(int score, string game)
{
    readonly int _score = score;
    readonly string _game = game;
  

    public readonly override string ToString()
    {
        return $"Game type: {_game}, Score: {_score} / 10";
    }
}




