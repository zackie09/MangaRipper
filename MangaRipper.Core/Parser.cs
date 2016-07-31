﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MangaRipper.Core
{
    class Parser
    {
        public IList<Chapter> ParseGroup(string regExp, string input, string nameGroup, string valueGroup)
        {
            var list = new List<Chapter>();
            Regex reg = new Regex(regExp, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(input);

            foreach (Match match in matches)
            {
                var value = match.Groups[valueGroup].Value;
                string name = match.Groups[nameGroup].Value;
                var chapter = new Chapter(name, value);
                list.Add(chapter);
            }

            return list.Distinct().ToList();
        }

        public IList<string> Parse(string regExp, string input, string groupName)
        {
            var list = new List<string>();
            Regex reg = new Regex(regExp, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(input);

            foreach (Match match in matches)
            {
                var value = match.Groups[groupName].Value;
                list.Add(value);
            }

            return list.Distinct().ToList();
        }
    }
}