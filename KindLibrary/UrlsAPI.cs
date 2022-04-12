using System;
using System.Collections.Generic;
using System.Text;

namespace KindLibrary
{
    public static class UrlsAPI
    {
        public const string WaitingListUrl = @"https://kg.sofia.bg/api/stat-rating/waiting/{0}";

        public const string AllGardensUrl = @"https://kg.sofia.bg/api/public/kg/type/kinderGarden/all?filterType=by_region&kgType=0&regionId=0";

        public const string NurseryGardensUrl = @"https://kg.sofia.bg/api/public/kg/type/kinderGarden/nursery?filterType=by_type&kgType=1&regionId=0";

        public const string GardenAllListsUrl = @"https://kg.sofia.bg/api/public/0/dz/{0}";
    }
}
