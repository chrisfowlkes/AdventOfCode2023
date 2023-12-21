using Classes;
using Classes.Models;
using Classes.Services;

var input = Console.ReadLine();
string[] data;
string result;

switch (input)
{
    case "1A":
        data = File.ReadAllLines(".\\Data\\1.txt");
        result = AdventOfCodeService.ReadCalibration(data);
        break;
    case "1B":
        data = File.ReadAllLines(".\\Data\\1.txt");
        result = AdventOfCodeService.ReadCalibration(data, true);
        break;
    case "2A":
        data = File.ReadAllLines(".\\Data\\2.txt");
        result = AdventOfCodeService.SumPossibleGameIds(data);
        break;
    case "2B":
        data = File.ReadAllLines(".\\Data\\2.txt");
        result = AdventOfCodeService.SumPowers(data);
        break;
    case "3A":
        data = File.ReadAllLines(".\\Data\\3.txt");
        result = AdventOfCodeService.SumEnginePartNumbers(data);
        break;
    case "3B":
        data = File.ReadAllLines(".\\Data\\3.txt");
        result = AdventOfCodeService.SumEngineGearRatios(data);
        break;
    case "4A":
        data = File.ReadAllLines(".\\Data\\4.txt");
        result = AdventOfCodeService.SumScratchcardPoints(data);
        break;
    case "4B":
        data = File.ReadAllLines(".\\Data\\4.txt");
        result = AdventOfCodeService.CountScratchcards(data);
        break;
    case "5A":
        data = File.ReadAllLines(".\\Data\\5.txt");
        result = AdventOfCodeService.FindClosestSeedLocation(data);
        break;
    case "5B":
        data = File.ReadAllLines(".\\Data\\5.txt");
        result = AdventOfCodeService.FindClosestSeedLocation(data, true);
        break;
    case "6A":
        data = File.ReadAllLines(".\\Data\\6.txt");
        result = AdventOfCodeService.CalculateProductOfWaysToWinRaces(data);
        break;
    case "6B":
        data = File.ReadAllLines(".\\Data\\6.txt");
        result = AdventOfCodeService.CalculateWaysToWinRace(data);
        break;
    case "7A":
        data = File.ReadAllLines(".\\Data\\7.txt");
        result = AdventOfCodeService.PlayCamelCards(data);
        break;
    case "7B":
        data = File.ReadAllLines(".\\Data\\7.txt");
        result = AdventOfCodeService.PlayCamelCards(data, true);
        break;
    case "8A":
        data = File.ReadAllLines(".\\Data\\8.txt");
        var map = new DesertMap(data);
        result = map.Navigate();
        break;
    case "8B":
        data = File.ReadAllLines(".\\Data\\8.txt");
        var multiMap = new DesertMap(data);
        result = multiMap.Navigate(true);
        break;
    case "9A":
        data = File.ReadAllLines(".\\Data\\9.txt");
        var historyNext = new OasisReport(data);
        result = historyNext.SumExtrapolatedNextValues();
        break;
    case "9B":
        data = File.ReadAllLines(".\\Data\\9.txt");
        var historyPrevious = new OasisReport(data);
        result = historyPrevious.SumExtrapolatedPreviousValues();
        break;
    case "10A":
        data = File.ReadAllLines(".\\Data\\10.txt");
        var sketch = new SurfacePipeSketch(data);
        result = sketch.CalculateDistanceToFurthestPipe();
        break;
    default:
        result = "Error";
        break;
}
Console.WriteLine(result);
Console.ReadLine();