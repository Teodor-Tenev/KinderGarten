using KindLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarden
{
    internal class Program
    {
        private static readonly int ID = 19005022;
        private static readonly int Points = 12;

        private static void Main(string[] args)
        {
            List<KindLibrary.KinderGarden> allGardens = DataLayer.Gardens;
            Parallel.ForEach(allGardens, garden =>
            {
                KinderGardenPopulator.PopuleEmptyFields(garden);
            });
            KinderGardenPopulator.PopulateChildsGardens(allGardens);
            KinderGardenPopulator.UpdateFieldsFromSocialChildren(allGardens);
            KinderGardenPopulator.UpdateFreeSlots(allGardens);
            
            allGardens = allGardens.OrderByDescending(e => e.CalcChanceRegularChildren(Points, ID)).ToList();
            foreach (var item in allGardens)
            {
                item.PrintInfo(Points, ID);
            }
        }
    }
}