using System;
using System.Xml.Serialization;

Console.Write("Write ur name: ");
var name = Console.ReadLine();
var date = DateTime.Now;
var score = 0;
var totalQuestions = 0;

Console.WriteLine($"Hello {name} it's {date} and this is a math game.");
while (true)
{
    Console.WriteLine("\n----------------------------------------\n");
    Console.WriteLine($@"Which game would you like to play?: 
    A - Addition
    S - Subtraction
    M - Multiplicaiton
    D - Division
    Q - Quit");
    GameCore();
}



void GameCore()
{
    var choice = Console.ReadLine();
    choice = String.IsNullOrEmpty(choice) ? "" : choice.Trim().ToUpper();
    while (true)
    {
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
            case "Q":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Unknown input, try again");
                choice = Console.ReadLine();
                choice = String.IsNullOrEmpty(choice) ? "" : choice;
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
            roundScore++;
        }
        else Console.WriteLine("Wrong :(");
        totalQuestions++;
    }
    PresentResults(start, roundScore);
}


void SubtractionGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Console.WriteLine("You choose subtraction, begin! \n");
    for (int i = 0; i < 10; i++)
    {
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
            roundScore++;
        }
        else Console.WriteLine("Wrong :(");
        totalQuestions++;
    }
    PresentResults(start, roundScore);
}
void MultiplicatonGame()
{
    DateTime start = DateTime.Now;
    var roundScore = 0;
    Console.WriteLine("You choose multiplication, begin! \n");
    for (int i = 0; i < 10; i++)
    {
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
            roundScore++;
        }
        else Console.WriteLine("Wrong :(");
        totalQuestions++;
    }
    PresentResults(start, roundScore);
}
void DivisionGame()
{
    var roundScore = 0;
    DateTime start = DateTime.Now;
    Console.WriteLine("You choose division, begin! \n");
    for (int i = 0; i < 10; i++)
    {
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
            roundScore++;
        }
        else Console.WriteLine("Wrong :(");
        totalQuestions++;
    }
    PresentResults(start, roundScore);
}
