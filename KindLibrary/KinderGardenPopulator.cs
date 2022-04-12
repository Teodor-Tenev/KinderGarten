using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace KindLibrary
{
    public static class KinderGardenPopulator
    {
        const string GardenBaseUrlPrefix = @"https://kg.sofia.bg/#/kindergarten/";

        public static void PopuleEmptyFields(KinderGarden kinderGarten)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                while (true)
                {
                    try
                    {
                        Uri myUri = new Uri(kinderGarten.ApiURL, UriKind.Absolute);
                        string jsonString = client.DownloadString(kinderGarten.ApiURL);
                        ImportKinderGardenDto rootobject = JsonConvert.DeserializeObject<ImportKinderGardenDto>(jsonString);

                        PopulateName(kinderGarten, rootobject);
                        PopulateId(kinderGarten, rootobject);
                        PopulateFreeSlots(kinderGarten, rootobject);
                        PopulateSocialFreeSlots(kinderGarten, rootobject);
                        PopulateChildren(kinderGarten, rootobject);
                        PopulateSocialChildren(kinderGarten, rootobject);
                        PopulateUrl(kinderGarten, rootobject);
                        break;
                    }
                    catch (Exception ex)
                    {
                        //if (stopwatch.Elapsed.TotalMinutes > 1)
                        //{
                        //    throw ex;
                        //}
                    }

                }
            }
        }

        private static void PopulateId(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.Id = (rootobject.Items.Group).Id;
        }

        private static void PopulateUrl(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.Url = GardenBaseUrlPrefix + (rootobject.Items.Group).KinderGarden.Id;
        }

        private static void PopulateSocialChildren(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.SocialChildren = new List<Child>();
            if (rootobject.Items.SocialChildren != null)
            {
                foreach (var child in rootobject.Items.SocialChildren)
                {
                    //if (child.ChildNum <= 19010963)
                    //{
                    kinderGarten.SocialChildren.Add(new Child(child.FirstName + child.MiddleName + child.LastName, child.ChildNum, child.Points, child.OrderPoints, child.WishOrder));
                    //}
                }
            }

        }

        private static void PopulateChildren(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.Children = new List<Child>();
            kinderGarten.AllKids = new List<Child>();
            //List<String> childs = new List<string>();
            //StringBuilder sb = new StringBuilder();
            foreach (var child in rootobject.Items.CommonChildren)
            {
                //if (child.ChildNum <= 19010963)
                //{

                kinderGarten.Children.Add(new Child(child.FirstName + child.MiddleName + child.LastName, child.ChildNum, child.Points, child.OrderPoints, child.WishOrder));
                //}

                kinderGarten.AllKids.Add(new Child(child.FirstName + child.MiddleName + child.LastName, child.ChildNum, child.Points, child.OrderPoints, child.WishOrder));

                //if (kinderGarten.Name.Contains("76 Сърничка"))
                //{
                //    sb.AppendLine(child.ChildNum.ToString());
                //}
            }
            //if (kinderGarten.Name.Contains("76 Сърничка"))
            //{
            //}
        }

        private static void PopulateSocialFreeSlots(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.SocialFreeSlots = rootobject.Items.FreeSocial ?? 0;
        }

        private static void PopulateFreeSlots(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.FreeSlots = rootobject.Items.FreeCommon ?? rootobject.Items.FreeSpots.Value;
        }

        private static void PopulateName(KinderGarden kinderGarten, ImportKinderGardenDto rootobject)
        {
            kinderGarten.Name = $"{(rootobject.Items.Group).KinderGarden.DetskoZavedenieType.Label} №{(rootobject.Items.Group).KinderGarden.external} {(rootobject.Items.Group).KinderGarden.Name}";
        }

        public static void PopulateChildsGardens(List<KinderGarden> allGardens)
        {
            foreach (var garden in allGardens)
            {
                foreach (var child in garden.Children)
                {
                    if (child.Gardens == null || child.Gardens.Count == 0)
                    {
                        child.Gardens = allGardens.Where(e => e.Children.FirstOrDefault(x => x.ID == child.ID) != null).ToList();
                    }
                }

                foreach (var child in garden.SocialChildren)
                {
                    if (child.Gardens == null || child.Gardens.Count == 0)
                    {
                        child.Gardens = allGardens.Where(e => e.SocialChildren.FirstOrDefault(x => x.ID == child.ID) != null).ToList();
                    }
                }
            }
        }

        private static void PopulateSocialFreeSlots(KinderGarden kinderGarten, string htmlCode)
        {
            string pattern1 = $"{Messages.SocialCriteria1} (?<slots>\\d+)\\s";
            string pattern2 = $"{Messages.SocialCriteria2} (?<slots>\\d+)\\s";
            var matchFreeSlots = Regex.Match(htmlCode, $"({pattern1}|{pattern2})");
            if (matchFreeSlots.Success)
            {
                int freeSlots = int.Parse(matchFreeSlots.Groups["slots"].Value);
                kinderGarten.SocialFreeSlots = freeSlots;
            }
            else
            {
                throw new ArgumentException($"Не намери 'Списък чакащи по социални критерии за ... места' в {kinderGarten.ApiURL}");
            }
        }

        private static void PopulateFreeSlots(KinderGarden kinderGarten, string htmlCode)
        {
            string pattern1 = @$"{Messages.GeneralCriteria1} (?<slots>\d+)\s";
            string pattern2 = @$"{Messages.GeneralCriteria2} (?<slots>\d+)\s";
            var matchFreeSlots = Regex.Match(htmlCode, @$"({pattern1}|{pattern2})");
            if (matchFreeSlots.Success)
            {
                int freeSlots = int.Parse(matchFreeSlots.Groups["slots"].Value);
                kinderGarten.FreeSlots = freeSlots;
            }
            else
            {
                throw new ArgumentException($"Не намери '{Messages.GeneralCriteria1} или {Messages.GeneralCriteria2} ... места' в {kinderGarten.ApiURL}");
            }
        }

        private static void PopulateChildren(KinderGarden kinderGarten, string htmlCode)
        {
            int startIndex = htmlCode.IndexOf($"{Messages.GeneralCriteria1}");
            startIndex = startIndex == -1 ? htmlCode.IndexOf($"{Messages.GeneralCriteria2}") : startIndex;

            htmlCode = htmlCode.Substring(startIndex);

            var childrenMatches = Regex.Matches(htmlCode, @"<td>\d+\. (?<name>[А-Я]{3})</td><td>(?<ID>\d+)</td><td>(?<points>1[2-9])\.0</td><td>(?<wish>\d)т\.");

            kinderGarten.Children = new List<Child>();
            if (childrenMatches.Count > 0)
            {
                foreach (Match child in childrenMatches)
                {
                    string name = child.Groups["name"].Value;
                    int ID = int.Parse(child.Groups["ID"].Value);
                    double points = double.Parse(child.Groups["points"].Value);
                    int wish = int.Parse(child.Groups["wish"].Value);
                    int wishOrder = int.Parse(child.Groups["wishOrder"].Value);

                    kinderGarten.Children.Add(new Child(name, ID, points, wish, wishOrder));
                }
            }
            else
            {
                throw new ArgumentException($"Не намери деца в списъка по търсения regex в {kinderGarten.ApiURL}");
            }
        }

        private static void PopulateSocialChildren(KinderGarden kinderGarten, string htmlCode)
        {
            int startIndex = htmlCode.IndexOf($"{Messages.SocialCriteria1}");
            startIndex = startIndex == -1 ? htmlCode.IndexOf($"{Messages.SocialCriteria2}") : startIndex;
            int endIndex = htmlCode.IndexOf($"{Messages.GeneralCriteria1}");
            endIndex = endIndex == -1 ? htmlCode.IndexOf($"{Messages.GeneralCriteria2}") : endIndex;

            htmlCode = htmlCode.Substring(startIndex, endIndex - startIndex);
            var childrenMatches = Regex.Matches(htmlCode, @"<td>\d+\. (?<name>[А-Я]{3})</td><td>(?<ID>\d+)</td><td>(?<points>\d+)\.0</td><td>(?<wish>\d)т\.");

            kinderGarten.SocialChildren = new List<Child>();
            if (childrenMatches.Count > 0)
            {
                foreach (Match child in childrenMatches)
                {
                    string name = child.Groups["name"].Value;
                    int ID = int.Parse(child.Groups["ID"].Value);
                    double points = double.Parse(child.Groups["points"].Value);
                    int wish = int.Parse(child.Groups["wish"].Value);
                    int wishOrder = int.Parse(child.Groups["wish"].Value);

                    kinderGarten.SocialChildren.Add(new Child(name, ID, points, wish, wishOrder));
                }
            }
            else
            {
                Debug.WriteLine($"Не намери деца в списъка по търсения regex в {kinderGarten.ApiURL}");
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
                throw new ArgumentException($"Не намери името на градината! {kinderGarten.ApiURL}");
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