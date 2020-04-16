using System.Collections.Generic;

namespace KinderGarden
{
    public class Child
    {
        public Child(string name, int iD, double points, int wish)
        {
            Name = name;
            ID = iD;
            Points = points;
            Wish = wish;
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public double Points { get; set; }

        /// <summary>
        /// 3 - Първо желание
        /// 2 - Второ желание
        /// 1 - Трето желание
        /// </summary>
        public int Wish { get; set; }

        public List<KinderGarden> Gardens { get; set; }
    }
}