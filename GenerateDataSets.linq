<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
</Query>

var sets = new[] { "FirstName" };
var root = @"c:\source\bendetat\TequilaMockingbird";

var template = @"
using System;
using System.Collections.Generic;
using System.Linq;

namespace TequilaMockingbird.DataSets
{
    public class {{DataSetName}}
        : IDataSet<string>
    {
        public IEnumerable<string> GetData()
        {
{{Data}}
        }
    }
}
";

foreach (var set in sets)
{
	var allFiles = Directory.GetFiles(Path.Combine(root, "DataSets", set), "*.txt");
	Console.WriteLine(string.Format("Found {0} files", allFiles.Count()));
	
	var allData = allFiles
		.SelectMany(filename => File.ReadAllLines(filename).Skip(2))
		.Where(x => !string.IsNullOrWhiteSpace(x))
		.Distinct()
		.Select(x => x.Replace("\"", "\\\""));
	Console.WriteLine(string.Format("Found {0} distinct items", allData.Count()));
		
	var data = new StringBuilder();
	foreach (var item in allData)
	{
		data
			.AppendFormat("            yield return \"{0}\";", item)
			.AppendLine();
	}
	
	var result = template
		.Replace("{{DataSetName}}", set)
		.Replace("{{Data}}", data.ToString());
		
	var dest = Path.Combine(root, "src", "TequilaMockingbird", "DataSets", set + ".cs");
	File.WriteAllText(dest, result);
	Console.WriteLine(string.Format("Wrote to {0}", dest));
}