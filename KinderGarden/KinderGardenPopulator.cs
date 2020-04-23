using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace KinderGarden
{
    public static class KinderGardenPopulator
    {
        public static void PopuleEmptyFields(KinderGarden kinderGarten)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string htmlCode = client.DownloadString(kinderGarten.URL);
                PopulateName(kinderGarten, htmlCode);
                PopulateFreeSlots(kinderGarten, htmlCode);
                PopulateSocialFreeSlots(kinderGarten, htmlCode);
                PopulateChildren(kinderGarten, htmlCode);
                PopulateSocialChildren(kinderGarten, htmlCode);
            }
        }

        public static void PopulateChildsGardens(List<KinderGarden> allGardens)
        {
            foreach (var garden in allGardens)
            {
                foreach (var child in garden.Children)
                {
                    if (child.Gardens == null || child.Gardens.Count == 0)
                    {
                        child.Gardens = allGardens.Where(e => e.Children.FirstOrDefault(e => e.ID == child.ID) != null).ToList();
                    }
                }

                foreach (var child in garden.SocialChildren)
                {
                    if (child.Gardens == null || child.Gardens.Count == 0)
                    {
                        child.Gardens = allGardens.Where(e => e.SocialChildren.FirstOrDefault(e => e.ID == child.ID) != null).ToList();
                    }
                }
            }
        }

        private static void PopulateSocialFreeSlots(KinderGarden kinderGarten, string htmlCode)
        {
            var matchFreeSlots = Regex.Match(htmlCode, @"Списък чакащи по социални критерии за (?<slots>\d+)\s");
            if (matchFreeSlots.Success)
            {
                int freeSlots = int.Parse(matchFreeSlots.Groups["slots"].Value);
                kinderGarten.SocialFreeSlots = freeSlots;
            }
            else
            {
                Console.WriteLine($"Не намери 'Списък чакащи по социални критерии за ... места' в {kinderGarten.URL}");
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

        private static void PopulateSocialChildren(KinderGarden kinderGarten, string htmlCode)
        {
            int startIndex = htmlCode.IndexOf("Списък чакащи по социални критерии");
            int endIndex = htmlCode.IndexOf("Списък чакащи по общи критерии");
            htmlCode = htmlCode.Substring(startIndex, endIndex - startIndex);
            var childrenMatches = Regex.Matches(htmlCode, @"<td>\d+\. (?<name>[А-Я]{3})</td><td>(?<ID>\d+)</td><td>(?<points>\d+)\.0</td><td>(?<wish>\d)т\.");

            if (childrenMatches.Count > 0)
            {
                kinderGarten.SocialChildren = new List<Child>();
                foreach (Match child in childrenMatches)
                {
                    string name = child.Groups["name"].Value;
                    int ID = int.Parse(child.Groups["ID"].Value);
                    double points = double.Parse(child.Groups["points"].Value);
                    int wish = int.Parse(child.Groups["wish"].Value);

                    kinderGarten.SocialChildren.Add(new Child(name, ID, points, wish));
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

        public static void UpdateFieldsFromSocialChildren(List<KinderGarden> allGardens)
        {
            foreach (var garden in allGardens)
            {
                garden.UpdateFieldsFromSocialChildren();
            }
        }

        public static void UpdateFreeSlots(List<KinderGarden> allGardens)
        {
            foreach (var garden in allGardens)
            {
                garden.UpdateFreeSlots();
            }
        }

    }
}