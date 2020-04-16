﻿using System;
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
        public List<Child> Children { get; set; }
        public double Chance { get; set; }

        public double CalcChance(int ID)
        {
            double points = Children.FirstOrDefault(e => e.ID == ID).Points;
            return CalcChance(points, ID);
        }

        public double CalcChance(double points, int ID)
        {
            double freeSlots = FreeSlots;
            double realRivals = 1;
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
                        var chance = garden.CalcChance(kid.ID);
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
                        var chance = garden.CalcChance(kid.ID);
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
            Chance = Math.Round(freeSlots / realRivals * 100, 2);
            Chance = Chance > 100 ? 100 : Chance;
            return Chance;
        }

        public void PrintInfo(double points, int ID)
        {
            Console.WriteLine($"\"{Name}\" има свободни {FreeSlots} места. Шанс да влезе: {CalcChance(points, ID)}%");
            Console.WriteLine(new String('=', 12));
        }
    }
}