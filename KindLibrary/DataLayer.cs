using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KindLibrary
{
    public static class DataLayer
    {
        public static List<KinderGarden> InterestedGardens = new List<KinderGarden>()
            {
                  //ДГ №70 Пролет (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/5455", distanceFromHome:1.3, approxTimeInMinutes: 4),

                  //ДГ №189 Сто усмивки (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/5507", distanceFromHome:2.1, approxTimeInMinutes: 6),

             
                  //ДГ №188 Вяра, Надежда, Любов (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4760", distanceFromHome: 0.280, approxTimeInMinutes: 1),

               

                  //ДГ №186 Деница (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4752", distanceFromHome: 2.2, approxTimeInMinutes: 8),


                  //ДГ №59 Елхица (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4723", distanceFromHome: 1.2, approxTimeInMinutes: 4),

                  //ДГ №56 Здравец (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4745", distanceFromHome: 1.1, approxTimeInMinutes: 3),

                  //ДГ №109 Зорница (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4842", distanceFromHome: 2.7, approxTimeInMinutes: 9),

                  //ДГ №14 Карлсон (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4746", distanceFromHome: 1.4, approxTimeInMinutes: 6),

                  //ДГ №17 Мечо Пух (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4736", distanceFromHome: 3.5, approxTimeInMinutes:11),

                  //ДГ №11 Мики Маус (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4831", distanceFromHome: 4.5, approxTimeInMinutes: 16),


                  //ДГ №117 Надежда (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4726", distanceFromHome: 4.9, approxTimeInMinutes: 16),


                  //ДГ №71 Щастие (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4907", distanceFromHome: 4.8, approxTimeInMinutes: 18),

                  //ДГ №75 Сърчице (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4860", distanceFromHome: 2.7, approxTimeInMinutes: 9),

                  //ДГ №76 Сърничка (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4881", distanceFromHome: 0.8, approxTimeInMinutes: 3),

                    //ДГ №76 Сърничка - сграда 2
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/5396", distanceFromHome: 0.8, approxTimeInMinutes: 3),

                  //ДГ №123 Шарл Перо (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4789", distanceFromHome: 5.4, approxTimeInMinutes: 14),

                  //ДГ №28 Ян Бибиян (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4754", distanceFromHome: 2.1, approxTimeInMinutes: 7),

                  //ДГ №26 Калина (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4785", distanceFromHome: 3.5, approxTimeInMinutes: 10),

                  //ДГ №98 Слънчево зайче (с яслени групи)
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4872", distanceFromHome: 2, approxTimeInMinutes: 7),

                  //ДГ №178 Сребърно копитце - сграда 2
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/4826", distanceFromHome: 1.5, approxTimeInMinutes: 4),

                   //ДГ №178 Сребърно копитце
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6177", distanceFromHome: 2.1, approxTimeInMinutes: 4),
            };

        public static List<KinderGarden> AllGardensInMladost = InterestedGardens.Concat(new List<KinderGarden>()
        {
                 //ДГ №117 Надежда (с яслени групи)  - почасова организация
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6271", distanceFromHome: 4.9, approxTimeInMinutes: 16),

                     //ДГ №11 Мики Маус - почасова организация
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6243", distanceFromHome: 4.5, approxTimeInMinutes: 16),

                  //ДГ №186 Деница (с яслени групи) - почасова организация
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6221", distanceFromHome: 2.2, approxTimeInMinutes: 8),

                     //ДГ №188 Вяра, Надежда, Любов (с яслени групи) - почасова организация
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6233", distanceFromHome: 0.280, approxTimeInMinutes: 1),

                        //ДГ №189 Сто усмивки (с яслени групи) - почасова организация
                  new KinderGarden(@"https://kg.sofia.bg/api/stat-rating/waiting/6141", distanceFromHome:2.1, approxTimeInMinutes: 6),
        }).ToList();

         public static List<KinderGarden> AllGardensInMladostAndPancharevo = AllGardensInMladost.Concat(new List<KinderGarden>()
        {
                 new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6349"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4710"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5433"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6085"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5515"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6315"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4839"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6322"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6323"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6558"),
        }).ToList();

        public static List<KinderGarden> AllGardens = AllGardensInMladostAndPancharevo.Concat(new List<KinderGarden>()
        {
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5780"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4847"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5977"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6537"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4832"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6298"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4876"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4718"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5781"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6310"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6562"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4735"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6159"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5508"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5471"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6176"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6346"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6387"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6329"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5321"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5454"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5431"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5789"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5373"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4917"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5524"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5335"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5494"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6067"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5462"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4733"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6389"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5391"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4848"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5308"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4755"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4720"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4846"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6318"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6362"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4871"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6380"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5490"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6374"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5500"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5999"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4835"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4866"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6171"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4827"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4863"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5412"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4782"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4815"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6172"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4915"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4861"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6286"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4703"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4708"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4743"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6379"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6381"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6063"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5349"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6384"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6372"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4920"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6386"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4852"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4705"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6348"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4921"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6328"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4742"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5783"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6356"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6371"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6351"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6526"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6337"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6373"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6365"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6355"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6358"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4699"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5514"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6071"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5359"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5277"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5360"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5470"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5787"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6026"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5415"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5788"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6332"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4721"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4712"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4709"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6309"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6292"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6548"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6550"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6353"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6306"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6319"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6364"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5257"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6008"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6340"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6551"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6347"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6561"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5382"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5274"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4859"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4779"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4701"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5319"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6556"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4884"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6303"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4864"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4930"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4931"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4834"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4777"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4891"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4719"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5480"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6168"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4911"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6020"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4862"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4922"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4803"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5450"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6534"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4840"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5362"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5353"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6184"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5331"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5311"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5784"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4889"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6058"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4867"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6274"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4812"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4797"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4893"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5984"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6382"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5985"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5495"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4879"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6195"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6557"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5512"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5347"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5786"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4763"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6317"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6383"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6297"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6377"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4737"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4838"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6081"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4882"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6385"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4804"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4843"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4700"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5782"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6015"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6241"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4899"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4731"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4775"),

            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5994"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4698"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4717"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5456"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4894"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4795"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6237"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4730"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4756"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4829"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4794"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4783"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6114"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6375"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6307"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6343"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6376"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6334"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4875"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4811"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6231"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4918"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4713"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6300"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6342"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6390"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6366"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5325"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4706"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4704"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4707"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4724"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6378"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4912"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6277"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6272"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6131"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6325"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6333"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6352"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6295"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6368"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6299"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6330"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6302"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5343"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6089"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4714"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4757"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4749"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4716"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6363"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6336"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6316"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4904"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4809"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6391"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6017"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4702"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5380"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4759"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4903"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4909"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4788"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4711"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/4715"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6296"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6028"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6388"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5430"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6304"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6331"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/5354"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6244"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6553"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6301"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6321"),
            new KinderGarden("https://kg.sofia.bg/api/stat-rating/waiting/6361"),

        }).ToList();
    }
}
