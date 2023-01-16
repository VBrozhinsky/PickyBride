﻿namespace PickyBride;
public class ContendersGenerator
{
    private const char CsvSeparator = ';';
    private const int HeaderRowsNumber = 1;

    private readonly string _sourceFilePath;

    public ContendersGenerator(string sourceFilePath = "data/names.txt")
    {
        _sourceFilePath = sourceFilePath ?? throw new ArgumentNullException(nameof(sourceFilePath));
        if (!File.Exists(_sourceFilePath))
        {
            throw new FileNotFoundException($"File {_sourceFilePath} does not exist on your machine!");
        }
    }

    private List<string[]> GetDataFromFile()
    {
        var contentLines = File.ReadAllText(_sourceFilePath).Split("\n");
        var csv = from line in contentLines select line.Split(CsvSeparator).ToArray();
        return csv.Skip(HeaderRowsNumber).ToList();
    }

    private static List<RatingContender> ShuffleContenders(IEnumerable<RatingContender> contenders)
    {
        var random = new Random();
        return contenders.OrderBy(contender => random.Next()).ToList();
    }

    public List<RatingContender> GetShuffledContenders()
    {
        var contenders = new List<RatingContender>();
        foreach (var row in GetDataFromFile())
        {
            contenders.Add(new RatingContender(
                surname: row[0],
                name: row[1],
                rating: int.Parse(row[2])));
        }

        return ShuffleContenders(contenders);
    }
}
