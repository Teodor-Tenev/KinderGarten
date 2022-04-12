using Newtonsoft.Json;
using System;

namespace KindLibrary
{
    public class ImportKinderGardenDto
    {
        //[JsonProperty("content")]
        //public object Content { get; set; }

        //public object error { get; set; }

        //public object itemCount { get; set; }

        [JsonProperty("items")]
        public Items Items { get; set; }

        //public bool locked { get; set; }

        //public DateTime createdAt { get; set; }

        //public object success { get; set; }

        //public object token { get; set; }
    }

    public class Items
    {
        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("freeSocial")]
        public int? FreeSocial { get; set; }

        [JsonProperty("freeCommon")]
        public int? FreeCommon { get; set; }

        //public int freeSop { get; set; }
        //public int freeHz { get; set; }
        [JsonProperty("freeSpots")]
        public int? FreeSpots { get; set; }

        [JsonProperty("listSocial")]
        public ImportChildDto[] SocialChildren { get; set; }

        [JsonProperty("listCommon")]
        //[JsonProperty("listWaiting")]

        public ImportChildDto[] CommonChildren;

   
        //public object[] listSop { get; set; }
        //public object[] listHz { get; set; }
        //public object listWaiting { get; set; }
        //public object listWaitingHzWithChangedDraft { get; set; }
        //public object listWaitingWithChangedDraft { get; set; }
        //public object listWaitingSopWithChangedDraft { get; set; }
    }

    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("kinderGarden")]
        public Kindergarden KinderGarden { get; set; }

        public int draft { get; set; }
        public int capacity { get; set; }
        public int capacitySop { get; set; }
        public int capacityHz { get; set; }
        public DateTime firstRating { get; set; }
        public DateTime acceptingFrom { get; set; }
        public int spotsChangeUncommited { get; set; }
        public bool active { get; set; }
    }

    public class Kindergarden
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public object communications { get; set; }
        public object groups { get; set; }
        public object address { get; set; }
        public object headOffice { get; set; }

        [JsonProperty("detskoZavedenieType")]
        public Detskozavedenietype DetskoZavedenieType { get; set; }

        public object director { get; set; }
        public object sofiaRegion { get; set; }
        public object sofiaRegionExtra { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external")]
        public int external { get; set; }

        public string mapUrl { get; set; }
        public string eik { get; set; }
        public DateTime dateCreated { get; set; }
        public object dateClosed { get; set; }
        public bool active { get; set; }
        public string infoForParents { get; set; }
        public string tmpCrit { get; set; }
        public int esriId { get; set; }
    }

    public class Detskozavedenietype
    {
        public int id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public bool school { get; set; }
    }

    public class ImportChildDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("points")]
        public float Points { get; set; }

        //public object entryDate { get; set; }
        //public object entryNum { get; set; }

        [JsonProperty("wishOrder")]
        public int WishOrder { get; set; }

        [JsonProperty("orderPoints")]
        public int OrderPoints { get; set; }

        //public object socialPoints { get; set; }
        [JsonProperty("childNum")]
        public int ChildNum { get; set; }
        //public float sopPoints { get; set; }
        //public float hzPoints { get; set; }
    }
}