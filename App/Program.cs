using System.Collections.Immutable;
using RandomPreferenceGenerator.Infrastructure.Csv;
using RandomPreferenceGenerator.Service;

var juniors = JuniorCsvReader.ReadAll("RandomPreferenceGenerator.Resources.Juniors20.csv").ToImmutableHashSet();
var teamleads = TeamleadCsvReader.ReadAll("RandomPreferenceGenerator.Resources.Teamleads20.csv").ToImmutableHashSet();

var summaryResult = 0.0;
var juniorsDictionary = juniors.ToImmutableDictionary(j => j.Id, j => j);
var teamleadsDictionary = teamleads.ToImmutableDictionary(t => t.Id, t => t);

var hackathonService = new HackathonService();
var pairsCreator = new MaxPreferencePairsCreationService();
var averageHarmonicValueCalculationService = new AverageHarmonicValueCalculationService();

for (var i = 0; i < 1000; ++i)
{
    var preferences = hackathonService.Hold(teamleads, juniors);
    var pairs = pairsCreator.Create(preferences, juniorsDictionary, teamleadsDictionary);
    var harmonicValue = averageHarmonicValueCalculationService.Calculate(pairs);

    summaryResult += harmonicValue;
}

Console.WriteLine(summaryResult / 1000.0);