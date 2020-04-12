using System;
using System.Collections.Generic;
using System.Text;

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
        public int Wish { get; set; }

    }
}
