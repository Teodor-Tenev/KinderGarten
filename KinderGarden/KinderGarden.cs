using System;
using System.Collections.Generic;
using System.Text;

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

        public void PrintInfo()
        {
            Console.WriteLine($"\"{Name}\" има свободни {FreeSlots} места.");
            for (int i = 1; i <= Children.Count; i++)
            {
                var child = Children[i-1];
                Console.WriteLine($"{i}. {child.Name} {child.ID} {child.Points} {child.Wish}");
            }
            Console.WriteLine(new String('=', 12));

        }
    }
}
