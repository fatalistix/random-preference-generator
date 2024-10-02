using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Infrastructure.Csv;

public struct TeamleadCsvReader
{
    
    public static IList<Teamlead> ReadAll(string resourcePath)
    {
        Stream? teamleadResourceStream;
        try
        {
            teamleadResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
        }
        catch (Exception e)
        {
            throw new FileNotFoundException($"file {resourcePath} not found", e);
        }

        if (teamleadResourceStream == null)
        {
            throw new FileNotFoundException($"file {resourcePath} not found");
        }

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        using var reader = new StreamReader(teamleadResourceStream);
        using var csvReader = new CsvReader(reader, csvConfiguration);
        
        csvReader.Read();
        csvReader.ReadHeader();
        
        return csvReader.GetRecords<Teamlead>().ToList();
    }
}