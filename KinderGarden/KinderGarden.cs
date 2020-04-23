using System;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarden
{
    public class KinderGarden
    {
        public KinderGarden(string uRL, double distanceFromHome, int approxTimeInMinutes)
        {
            DistanceFromHome = distanceFromHome;
            ApproxTimeInMinutes = approxTimeInMinutes;
            URL = uRL;
        }

        public double DistanceFromHome { get; set; }
        public int ApproxTimeInMinutes { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public int FreeSlots { get; set; }
        public int SocialFreeSlots { get; set; }
        public List<Child> SocialChildren { get; set; }
        public List<Child> Children { get; set; }

        public double CalcChanceRegularChildren(int ID)
        {
            double points = Children.FirstOrDefault(e => e.ID == ID).Points;
            return CalcChanceRegularChildren(points, ID);
        }

        public double CalcChanceRegularChildren(double points, int ID)
        {
            double realRivals = 1;
            double freeSlots = FreeSlots;

            foreach (var kid in Children)
            {
                if (kid.Points > points && kid.Wish == 3)
                {
                    freeSlots--;
                }
                else if (kid.Points == points
                    && kid.Wish == 3 && kid.ID != ID)
                {
                    realRivals++;
                }
                else if (kid.Points == points && kid.Wish == 2 && kid.ID != ID)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name))
                    {
                        var chance = garden.CalcChanceRegularChildren(kid.ID);
                        if (chance < 100 && chance > 0)
                        {
                            realRivals += chance / 100;
                        }
                        else if (chance == 0)
                        {
                            realRivals++;
                        }
                    }
                }
                else if (kid.Points > points && kid.Wish == 2)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name))
                    {
                        var chance = garden.CalcChanceRegularChildren(kid.ID);
                        if (chance < 100 && chance > 0)
                        {
                            freeSlots -= chance / 100;
                        }
                        else if (chance == 0)
                        {
                            freeSlots--;
                        }
                    }
                }

                if (freeSlots == 0)
                {
                    return 0;
                }
            }
            var finalChance = Math.Round(freeSlots / realRivals * 100, 2);
            return finalChance > 100 ? 100 : finalChance;
        }

        public double CalcChanceSocialChildren(int ID)
        {
            double points = SocialChildren.FirstOrDefault(e => e.ID == ID).Points;
            return CalcChanceSocialChildren(points, ID);
        }

        public double CalcChanceSocialChildren(double points, int ID)
        {
            double realRivals = 1;
            double freeSlots = SocialFreeSlots;

            foreach (var kid in SocialChildren)
            {
                if (kid.Points > points && kid.Wish == 3)
                {
                    freeSlots--;
                }
                else if (kid.Points == points
                    && kid.Wish == 3 && kid.ID != ID)
                {
                    realRivals++;
                }
                //else if (kid.Points == points && kid.Wish == 2 && kid.ID != ID)
                //{
                //    foreach (var garden in kid.Gardens.Where(e => e.Name != Name))
                //    {
                //        var chance = garden.CalcChanceSocialChildren(kid.ID);
                //        if (chance < 100 && chance > 0)
                //        {
                //            realRivals += chance / 100;
                //        }
                //        else if (chance == 0)
                //        {
                //            realRivals++;
                //        }
                //    }
                //}
                //else if (kid.Points > points && kid.Wish == 2)
                //{
                //    foreach (var garden in kid.Gardens.Where(e => e.Name != Name))
                //    {
                //        var chance = garden.CalcChanceSocialChildren(kid.ID);
                //        if (chance < 100 && chance > 0)
                //        {
                //            freeSlots -= chance / 100;
                //        }
                //        else if (chance == 0)
                //        {
                //            freeSlots--;
                //        }
                //    }
                //}

                if (freeSlots == 0)
                {
                    return 0;
                }
            }
            var finalChance = Math.Round(freeSlots / realRivals * 100, 2);
            return finalChance > 100 ? 100 : finalChance;
        }

        public void UpdateFieldsFromSocialChildren()
        {
            foreach (var child in SocialChildren)
            {
                var chance = CalcChanceSocialChildren(child.ID);
                if (chance == 100)
                {
                    Children.Remove(Children.FirstOrDefault(e => e.ID == child.ID));
                    var selectedGardens = child.Gardens.Where(e => e.Name != Name);
                    for (int i = selectedGardens.Count() - 1; i >= 0; i--)
                    {
                        var garden = selectedGardens.ElementAt(i);
                        var socChild = garden.SocialChildren.FirstOrDefault(e => e.ID == child.ID);

                        if (socChild.Wish < child.Wish)
                        {
                            for (int x = child.Gardens.Count() - 1; x >= 0; x--)
                            {
                                var gard = child.Gardens.ElementAt(x);
                                var singleChild = gard.SocialChildren.Single(e => e.ID == child.ID);
                                singleChild.Gardens.Remove(singleChild.Gardens.FirstOrDefault(e => e.Name == garden.Name));
                            }
                           
                            garden.SocialChildren.Remove(socChild);
                            garden.Children.Remove(garden.Children.FirstOrDefault(e => e.ID == child.ID));
                            child.Gardens.Remove(garden);
                        }
                    }
                }
            }
        }

        public void UpdateFreeSlots()
        {
            if (SocialChildren.Count < SocialFreeSlots)
            {
                FreeSlots += SocialFreeSlots - SocialChildren.Count;
            }
        }

        public void PrintInfo(double points, int ID)
        {
            Console.WriteLine($"\"{Name}\" има свободни {FreeSlots} места. Шанс да влезе: {CalcChanceRegularChildren(points, ID)}%");
            Console.WriteLine(new String('=', 12));
        }
    }
}