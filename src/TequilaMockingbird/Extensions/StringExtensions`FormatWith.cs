using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TequilaMockingbird.Extensions
{
    public static partial class StringExtensions
    {
public static string FormatWith(this string format, params object[] args)
    {
        args = args ?? new object[0];
        string result;
        var numberedTemplateCount = (from object match in new Regex(@"\{\d{1,2}\}").Matches(format) select match.ToString()).Distinct().Count();

        if (numberedTemplateCount != args.Length)
        {
            var argsDictionary = args[0].ToDictionary();

            if (!argsDictionary.Any())
            {
                throw new InvalidOperationException("Please supply enough args for the numbered templates or use an anonymous object to identify the templates by name.");
            }

            result = argsDictionary.Aggregate(format, (current, o) => current.Replace("{" + o.Key + "}", (o.Value ?? string.Empty).ToString()));
        }
        else
        {
            result = string.Format(format, args);
        }

        if (result == format)
        {
            throw new InvalidOperationException("You cannot mix template types. Use numbered templates or named ones with an anonymous object.");
        }

        return result;
    }    
}
}
