using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Infrastructure.Csv;

public struct JuniorCsvReader
{
    public static IList<Junior> ReadAll(string resourcePath)
    {
        Stream? juniorResourceStream;
        try
        {
            juniorResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
        }
        catch (Exception e)
        {
            throw new FileNotFoundException($"file {resourcePath} not found", e);
        }

        if (juniorResourceStream == null)
        {
            throw new FileNotFoundException($"file {resourcePath} not found");
        }

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        using var reader = new StreamReader(juniorResourceStream);
        using var csvReader = new CsvReader(reader, csvConfiguration);
        
        csvReader.Read();
        csvReader.ReadHeader();
        
        return csvReader.GetRecords<Junior>().ToList();
    }
}