using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KinderGarden
{
    class Program
    {
        static void Main(string[] args)
        {

            List<KinderGarden> allGardens = new List<KinderGarden>()
            {
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4760", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4752", distanceFromHome: 5, approxTimeInMinutes: 15),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4723", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4745", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4842", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4746", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4736", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4831", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4726", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4907", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4860", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4881", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4789", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4754", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4785", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4872", distanceFromHome: 2, approxTimeInMinutes: 5),
                  new KinderGarden(@"https://kg.sofia.bg/isodz/stat-rating/waiting/4826", distanceFromHome: 2, approxTimeInMinutes: 5),
            };
            Parallel.ForEach(allGardens, garden =>
            {
                PopuleEmptyFields(garden);
            });

            foreach (var garden in allGardens)
            {
                foreach (var child in garden.Children)
                {
                    if (child.Gardens == null || child.Gardens.Count == 0)
                    {
                        child.Gardens = allGardens.Where(e => e.Children.FirstOrDefault(e => e.ID == child.ID) != null).ToList();
                    }
                }
            }

            allGardens = allGardens.OrderByDescending(e => e.CalcChance(12, 19005022)).ToList();
            foreach (var item in allGardens)
            {
                item.PrintInfo(12, 19005022);
            }
        }

        static void PopuleEmptyFields(KinderGarden kinderGarten)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string htmlCode = client.DownloadString(kinderGarten.URL);
                PopulateName(kinderGarten, htmlCode);
                PopulateFreeSlots(kinderGarten, htmlCode);
                PopulateChildren(kinderGarten, htmlCode);
            }
        }

        private static void PopulateFreeSlots(KinderGarden kinderGarten, string htmlCode)
        {
            var matchFreeSlots = Regex.Match(htmlCode, @"Списък чакащи по общи критерии за (?<slots>\d+)\s");
            if (matchFreeSlots.Success)
            {
                int freeSlots = int.Parse(matchFreeSlots.Groups["slots"].Value);
                kinderGarten.FreeSlots = freeSlots;
            }
            else
            {
                Console.WriteLine($"Не намери 'Списък чакащи по общи критерии за ... места' в {kinderGarten.URL}");
            }
        }

        private static void PopulateChildren(KinderGarden kinderGarten, string htmlCode)
        {
            htmlCode = htmlCode.Substring(htmlCode.IndexOf("Списък чакащи по общи критерии"));
            var childrenMatches = Regex.Matches(htmlCode, @"<td>\d+\. (?<name>[А-Я]{3})</td><td>(?<ID>\d+)</td><td>(?<points>1[2-9])\.0</td><td>(?<wish>\d)т\.");

            if (childrenMatches.Count > 0)
            {
                kinderGarten.Children = new List<Child>();
                foreach (Match child in childrenMatches)
                {
                    string name = child.Groups["name"].Value;
                    int ID = int.Parse(child.Groups["ID"].Value);
                    double points = double.Parse(child.Groups["points"].Value);
                    int wish = int.Parse(child.Groups["wish"].Value);

                    kinderGarten.Children.Add(new Child(name, ID, points, wish));
                }
            }
            else
            {
                Console.WriteLine($"Не намери деца в списъка по търсения regex в {kinderGarten.URL}");
            }
        }

        private static void PopulateName(KinderGarden kinderGarten, string htmlCode)
        {
            var matchName = Regex.Match(htmlCode, @"(?<name>ДГ №\d+ .*?)<\/strong>");
            if (matchName.Success)
            {
                kinderGarten.Name = matchName.Groups["name"].Value;
            }
            else
            {
                Console.WriteLine($"Не намери името на градината! {kinderGarten.URL}");
            }
        }
    }
}
