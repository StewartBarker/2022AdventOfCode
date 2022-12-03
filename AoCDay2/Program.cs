// See https://aka.ms/new-console-template for more information
Console.WriteLine("AoC Day2!");

string[] lines = File.ReadAllLines("InputFile.txt");
var score = 0;
const int winnerScore = 6;
const int drawScore = 3;
const int loserScore = 0;

foreach(var line in lines)
{
    var turns = line.Split(" ");
    var opponent = GetRPS(turns[0]);
    var winner = GetWinnerFromInput(turns[1]);
    var me = winner == GameWinner.me ? GetWinner(opponent) :
             winner == GameWinner.opponent ? GetLoser(opponent) :
             opponent;
    
    score += GetScore(opponent, me);
}

Console.WriteLine($"Score: {score}");
Console.ReadKey();

static RPS GetWinner(RPS rps) => rps switch
{
    RPS.Rock => RPS.Paper,
    RPS.Scissors => RPS.Rock,
    RPS.Paper => RPS.Scissors
};

static RPS GetLoser(RPS rps) => rps switch
{
    RPS.Rock => RPS.Scissors,
    RPS.Scissors => RPS.Paper,
    RPS.Paper => RPS.Rock
};

static GameWinner GetWinnerFromInput(string s) => s switch
{
    "X" => GameWinner.opponent,
    "Y" => GameWinner.draw,
    "Z" => GameWinner.me,
    _ => throw new ArgumentOutOfRangeException()
};

static int GetScore(RPS opponent, RPS me)
{
    var winner = WhoIsTheWinner(opponent, me);
    var score = winner == GameWinner.me ? winnerScore :
                winner == GameWinner.draw ? drawScore :
                loserScore;
    
    return score + GetRPSScore(me);
}

static int GetRPSScore(RPS rps) => rps switch
{
    RPS.Rock => 1,
    RPS.Paper => 2,
    RPS.Scissors => 3,
    _ => throw new ArgumentOutOfRangeException()
};

static GameWinner WhoIsTheWinner(RPS opponent, RPS me) => (opponent, me) switch
{
    (RPS.Rock, RPS.Paper) => GameWinner.me,
    (RPS.Paper, RPS.Scissors) => GameWinner.me,
    (RPS.Scissors, RPS.Rock) => GameWinner.me,
    (RPS.Paper, RPS.Rock) => GameWinner.opponent,
    (RPS.Scissors, RPS.Paper) => GameWinner.opponent,
    (RPS.Rock, RPS.Scissors) => GameWinner.opponent,
    _ => GameWinner.draw
};

static RPS GetRPS(string s) => s switch
{
    "A" or "X" => RPS.Rock,
    "B" or "Y" => RPS.Paper,
    "C" or "Z" => RPS.Scissors,
    _ => throw new ArgumentOutOfRangeException()
};

public enum GameWinner
{
    opponent,
    me,
    draw
}

public enum RPS
{
    Rock,
    Paper,
    Scissors
}
