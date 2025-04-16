using System.Text.RegularExpressions;

string url = "https://archive.ssps.cajthaml.eu/2024-2025/3-dvop-wbb/05_backend.html#/";
Dictionary<string, List<string>> headings = new Dictionary<string, List<string>>();
HttpClient client = new HttpClient();
string pattern = @"<h[1-5].*?>.*?<\/h[1-5]>";
string source;

using (StreamReader reader = new StreamReader(await client.GetStreamAsync(url)))
{
    source = await reader.ReadToEndAsync();
}
try
{
    foreach (Match match in Regex.Matches(source, pattern))
    {
        if (!string.IsNullOrEmpty(match.Value))
        {
            Add(match.Value.Substring(1, 2), match.Value.Substring(4, match.Value.Length - 9));
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Dictionary<string, List<string>> sortedhHeadings = headings
    .OrderBy(kvp => kvp.Key)
    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

foreach (var item in sortedhHeadings)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{item.Key}:\n    ");
    Console.ResetColor();
    Console.WriteLine(string.Join("\n    ", item.Value));
}

void Add(string key, string value)
{
    if (headings.ContainsKey(key))
    {
        List<string> list = headings[key];
        if (list.Contains(value) == false)
        {
            list.Add(value);
        }
    }
    else
    {
        List<string> list = new List<string>();
        list.Add(value);
        headings.Add(key, list);
    }
}
