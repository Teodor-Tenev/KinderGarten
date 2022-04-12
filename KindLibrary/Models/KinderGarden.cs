using System;
using System.Collections.Generic;
using System.Linq;

namespace KindLibrary
{
    public class KinderGarden
    {
        public KinderGarden(string uRL, double distanceFromHome = 1000, int approxTimeInMinutes = 1000)
        {
            DistanceFromHome = distanceFromHome;
            ApproxTimeInMinutes = approxTimeInMinutes;
            ApiURL = uRL;
        }

        public int Id { get; set; }
        //static int Tab = 0;
        public double DistanceFromHome { get; set; }
        public string Region { get; set; }
        public int ApproxTimeInMinutes { get; set; }
        public string ApiURL { get; set; }
        public string Url { get; set; }
        public int WaitingId { get; set; }
        public string Name { get; set; }
        public int FreeSlots { get; set; }
        public int SocialFreeSlots { get; set; }
        public List<Child> SocialChildren { get; set; }
        public List<Child> Children { get; set; }
        public List<Child> AllKids { get; set; }
        public int ChildrenCount => Children.Count;
        public int RealRivals { get; set; }
        public int RealRivalsFreeSlots { get; set; }

        public double CalcChanceRegularChildren(int ID)
        {
            double points = Children.FirstOrDefault(e => e.ID == ID).Points;
            return CalcChanceRegularChildren(points, ID);
        }

        public double CalcChanceRegularChildren(double points, int ID)
        {
            //Tab++;
            double realRivals = 1;

            double freeSlots = FreeSlots;

            foreach (var kid in Children.Where(e => e.ID != ID).ToList())
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
                else if (kid.Points == points && kid.Wish <= 2 && kid.ID != ID)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name && e.Children.FirstOrDefault(c => c.ID == kid.ID && c.Wish == 3) != null).OrderByDescending(e => e.Children.Find(e => e.ID == kid.ID)?.Wish))
                    {
                        //for (int i = 0; i < Tab; i++)
                        //{
                        //    Debug.Write("-");
                        //}
                        //Debug.WriteLine($"Garden: {garden.Name}, KidName: {kid.Name}, Points: {kid.Points}, Wish: {kid.Wish}");

                        var chance = garden.CalcChanceRegularChildren(kid.ID);

                        if (chance < 100 && chance > 0)
                        {
                            realRivals += chance / 100;
                        }
                        else if (chance == 0)
                        {
                            realRivals++;
                        }
                        else if (chance == 100)
                        {
                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.Children.Remove(kid));
                            kid.Gardens.RemoveAll(e => e != garden);
                            garden.Children.Find(e => e == kid)?.Gardens.RemoveAll(e => e != garden);
                            break;
                        }
                    }
                }
                else if (kid.Points > points && kid.Wish <= 2)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name && e.Children.Any(c => c.ID == kid.ID)).OrderByDescending(e => e.Children.Find(e => e.ID == kid.ID)?.Wish))
                    {
                        //for (int i = 0; i < Tab; i++)
                        //{
                        //    Debug.Write("-");
                        //}
                        //Debug.WriteLine($"Garden: {garden.Name}, KidName: {kid.Name}, Points: {kid.Points}, Wish: {kid.Wish}");

                        var chance = garden.CalcChanceRegularChildren(kid.ID);
                        if (chance < 100 && chance > 0)
                        {
                            freeSlots -= chance / 100;
                        }
                        else if (chance == 0)
                        {
                            freeSlots--;
                        }
                        else if (chance == 100)
                        {

                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.Children.Remove(kid));
                            kid.Gardens.RemoveAll(e => e != garden);
                            break;
                        }
                    }
                }
                if (freeSlots <= 0)
                {
                    return 0;
                }
            }
            //Tab--;
            var finalChance = Math.Round(freeSlots / realRivals * 100, 2);
            RealRivals = (int)Math.Ceiling(realRivals);
            RealRivalsFreeSlots = (int)Math.Floor(freeSlots);
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

            foreach (var kid in SocialChildren.Where(e => e.ID != ID).ToList())
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
                else if (kid.Points == points && kid.Wish <= 2 && kid.ID != ID)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name && e.SocialChildren.FirstOrDefault(c => c.ID == kid.ID && c.Wish == 3) != null).OrderByDescending(e => e.SocialChildren.Find(e => e.ID == kid.ID)?.Wish))
                    {
                        var chance = garden.CalcChanceSocialChildren(kid.ID);
                        if (chance < 100 && chance > 0)
                        {
                            realRivals += chance / 100;
                        }
                        else if (chance == 0)
                        {
                            realRivals++;
                        }
                        else if (chance == 100)
                        {
                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.SocialChildren.Remove(kid));
                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.Children.Remove(kid));
                            kid.Gardens.RemoveAll(e => e != garden);
                            garden.SocialChildren.Find(e => e == kid)?.Gardens.RemoveAll(e => e != garden);
                            garden.Children.Find(e => e == kid)?.Gardens.RemoveAll(e => e != garden);
                            break;
                        }
                    }
                }
                else if (kid.Points > points && kid.Wish == 2)
                {
                    foreach (var garden in kid.Gardens.Where(e => e.Name != Name && e.SocialChildren.Any(c => c.ID == kid.ID)).OrderByDescending(e => e.SocialChildren.Find(e => e.ID == kid.ID)?.Wish))
                    {
                        var chance = garden.CalcChanceSocialChildren(kid.ID);
                        if (chance < 100 && chance > 0)
                        {
                            freeSlots -= chance / 100;
                        }
                        else if (chance == 0)
                        {
                            freeSlots--;
                        }
                        else if (chance == 100)
                        {
                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.SocialChildren.Remove(kid));
                            kid.Gardens.Where(e => e != garden).ToList().ForEach(e => e.Children.Remove(kid));
                            kid.Gardens.RemoveAll(e => e != garden);
                            break;
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

        public void UpdateFieldsFromSocialChildren()
        {
            for (int z = SocialChildren.Count() - 1; z >= 0; z--)
            //foreach (var child in SocialChildren)
            {
                if (z < SocialChildren.Count())
                {
                    var child = SocialChildren.ElementAt(z);
                    var chance = CalcChanceSocialChildren(child.ID);
                    var hasMultipleGardens = child.Gardens.Count > 1;

                    var hasSameChancesEverywhere = true;

                    for (int i = child.Gardens.Count - 1; i >= 0; i--)
                    {
                        var gard = child.Gardens.ElementAt(i);
                        //foreach (var gard in child.Gardens)
                        //{
                        var currChild = gard.SocialChildren.Find(e => e.ID == child.ID);
                        if (currChild == null)
                        {
                            gard.SocialChildren.Remove(currChild);
                            gard.Children.Remove(currChild);
                            child.Gardens.Remove(gard);
                        }
                        else
                        {
                            hasSameChancesEverywhere &= currChild.Points == child.Points;
                        }
                    }

                    if (chance == 100 || (hasMultipleGardens && hasSameChancesEverywhere) || child.WishOrder > 10)
                    {
                        Children.Remove(Children.FirstOrDefault(e => e.ID == child.ID));
                        var selectedGardens = child.Gardens.Where(e => e.Name != Name);
                        for (int i = selectedGardens.Count() - 1; i >= 0; i--)
                        {
                            if (i < selectedGardens.Count())
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
            }
        }

        public void UpdateFreeSlots()
        {
            if (SocialChildren.Count < SocialFreeSlots)
            {
                FreeSlots += SocialFreeSlots - SocialChildren.Count;
            }
        }

    }
}