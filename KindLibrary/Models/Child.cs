using System;
using System.Collections.Generic;

namespace KindLibrary
{
    public class Child
    {
        public Child(string name, int iD, double points, int wish, int wishOrder)
        {
            Name = name;
            ID = iD;
            Points = points;
            Wish = wish;
            WishOrder = wishOrder;
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
        public int WishOrder { get; set; }

        public List<KinderGarden> Gardens { get; set; }

    }
}