using Classes;
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
    default:
        result = "Error";
        break;
}
Console.WriteLine(result);
Console.ReadLine();