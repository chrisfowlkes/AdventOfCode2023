using Classes;

var input = Console.ReadLine();
string result;
switch (input)
{
    case "1A":
        var data = File.ReadAllLines(".\\Data\\1A.txt");
        var doc = new CalibrationDocument(data);
        result = doc.Calculate();
        break;
    default:
        result = "Error";
        break;
}
Console.WriteLine(result);
Console.ReadLine();