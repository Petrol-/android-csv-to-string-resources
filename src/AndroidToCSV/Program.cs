using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AndroidToCSV
{
    class Program
    {
        private const int _key = 0;
        private const int _value =1;

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(@"Error: ");
                Console.WriteLine(@"Please run Android.exe Path\to\CSV\File");
                Console.WriteLine("The CSV file must of the form KEY;VALUE");
                return;
            }
            var csvPath = Path.GetFullPath(args[0]);
            using (var file = new StreamWriter(File.OpenWrite("string.xml")))
            {
                using (var sr = new StreamReader(csvPath, Encoding.UTF8))
                {
                    InitFile(file);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        var keyValue = SplitLine(line);
                        var toAppend = $"<string name=\"{keyValue.key}\">\"{keyValue.value}\"</string>";
                        Console.WriteLine(toAppend);
                        AppendLine(file, toAppend);
                    }
                    EndFile(file);
                }
            }
        }

        private static void InitFile(StreamWriter sw)
        {
           AppendLine(sw, "<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            AppendLine(sw, "<resources>");
        }

        private static void EndFile(StreamWriter sw)
        {
            AppendLine(sw, "</resources>");
        }

        private static void AppendLine(StreamWriter sw, string line)
        {
            sw.WriteLine(line);
        }

        private static (string key, string value) SplitLine(string line)
        {
            var keyValue = line.Split(";");
            var key = keyValue[_key];
            var value = ReplaceSpecialChar(keyValue[_value]);
            return (key, value);
        }

        private static string ReplaceSpecialChar(string value)
        {
            var result = value;
            if (value.Contains("&"))
            {
                result = result.Replace("&", "&#38;");
            }

            return result;
        }
    }
}
