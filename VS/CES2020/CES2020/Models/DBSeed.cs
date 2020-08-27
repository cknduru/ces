using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Repositories;

namespace CES2020.Models
{
    public class DBSeed
    {
        private readonly ByRepository byRepository;
        private readonly TelstarForbindelseRepository telstarForbindelseRepository;


        public DBSeed()
        {
            this.byRepository = new ByRepository();
            this.telstarForbindelseRepository = new TelstarForbindelseRepository();
        }

        private List<string> Byer = new List<string>()
        {
            "Tanger",
            "Tunis",
            "Marrakesh",
            "De Kanariske Øer",
            "Sahara",
            "Tripoli",
            "Cairo",
            "Omdurman",
            "Dakar",
            "Timbuktu",
            "Wadai",
            "Suakin",
            "Sierra Leone",
            "Guldkysten",
            "Slavekysten",
            "Darfur",
            "Addis Abeba",
            "Kap Guardafui",
            "Congo",
            "Luanda",
            "Kabalo",
            "Bahr El Shazal",
            "Victoriasøen",
            "Zanzibar",
            "Hvalbugten",
            "Victoriafaldene",
            "Mocambique",
            "Amatave",
            "Dragebjerget",
            "Kap St. Marie",
            "Kapstaden",
            "St. Helena"
        };

        public List<(string, string, int)> Forbindelser = new List<(string, string, int)>()
        {
            // Fra      Til     Antal segmenter
            ("Tanger","Marrakesh",2),
            ("Tanger","Sahara",5),
            ("Tanger","Tunis",5),
            ("Marrakesh","Tanger",2),
            ("Marrakesh","Dakar",8),
            ("Marrakesh","Sahara",5),
            ("Dakar","Marrakesh",8),
            ("Dakar","Sierra Leone",4),
            ("Sierra Leone","Dakar",4),
            ("Sierra Leone","Timbuktu",5),
            ("Sierra Leone","Guldkysten",5),
            ("Guldkysten","Sierra Leone",5),
            ("Guldkysten","Timbuktu",4),
            ("Timbuktu","Guldkysten",4),
            ("Timbuktu","Sierra Leone",5),
            ("Timbuktu","Slavekysten",5),
            ("Slavekysten","Timbuktu",5),
            ("Slavekysten","Wadai",7),
            ("Slavekysten","Darfur",7),
            ("Slavekysten","Congo",5),
            ("Congo","Slavekysten",5),
            ("Congo","Darfur",6),
            ("Congo","Wadai",6),
            ("Congo","Luanda",3),
            ("Luanda","Congo",3),
            ("Luanda","Kabalo",4),
            ("Luanda","Mocambique",10),
            ("Luanda","Victoriafaldene",11),
            ("Luanda","Dragebjerget",11),
            ("Mocambique","Luanda",10),
            ("Mocambique","Victoriafaldene",5),
            ("Mocambique","Dragebjerget",4),
            ("Mocambique","Zanzibar",3),
            ("Mocambique","Victoriasøen",6),
            ("Victoriafaldene","Mocambique",5),
            ("Victoriafaldene","Dragebjerget",3),
            ("Victoriafaldene","Hvalbugten",4),
            ("Victoriafaldene","Luanda",11),
            ("Hvalbugten","Victoriafaldene",4),
            ("Hvalbugten","Kapstaden",4),
            ("Kapstaden","Hvalbugten",4),
            ("Dragebjerget","Victoriafaldene",3),
            ("Dragebjerget","Mocambique",4),
            ("Dragebjerget","Luanda",11),
            ("Zanzibar","Mocambique",3),
            ("Zanzibar","Victoriasøen",5),
            ("Zanzibar","Kap Guardafui",6),
            ("Kap Guardafui","Zanzibar",6),
            ("Kap Guardafui","Addis Abeba",6),
            ("Addis Abeba","Kap Guardafui",6),
            ("Addis Abeba","Suakin",3),
            ("Addis Abeba","Victoriasøen",3),
            ("Victoriasøen","Mocambique",6),
            ("Victoriasøen","Zanzibar",5),
            ("Victoriasøen","Kabalo",4),
            ("Victoriasøen","Bahr El Shazal",2),
            ("Victoriasøen","Addis Abeba",3),
            ("Kabalo","Victoriasøen",4),
            ("Kabalo","Luanda",4),
            ("Bahr El Shazal","Victoriasøen",2),
            ("Bahr El Shazal","Darfur",2),
            ("Suakin","Addis Abeba",3),
            ("Suakin","Darfur",4),
            ("Darfur","Suakin",4),
            ("Darfur","Bahr El Shazal",2),
            ("Darfur","Congo",6),
            ("Darfur","Slavekysten",7),
            ("Darfur","Wadai",4),
            ("Darfur","Sahara",8),
            ("Darfur","Omdurman",3),
            ("Wadai","Darfur",4),
            ("Wadai","Slavekysten",7),
            ("Wadai","Congo",6),
            ("Omdurman","Darfur",3),
            ("Omdurman","Cairo",4),
            ("Omdurman","Tripoli",6),
            ("Cairo","Omdurman",4),
            ("Tripoli","Omdurman",6),
            ("Tripoli","Tunis",3),
            ("Tunis","Tripoli",3),
            ("Tunis","Tanger",5),
            ("Sahara","Tanger",5),
            ("Sahara","Marrakesh",5),
            ("Sahara","Darfur",8)
        };

        public void SeedByer()
        {
            var byer = new List<By>();

            foreach (var byNavn in this.Byer)
            {
                byer.Add(new By() { Name = byNavn });
            }

            byRepository.AddMultiple(byer);
        }

        public void SeedForbindelser()
        {
            foreach (var forbindelseTuple in this.Forbindelser)
            {
                var forbindelse = new TelstarForbindelse()
                {
                    Fra = new By() { Id = byRepository.GetIdFromName(forbindelseTuple.Item1) },
                    Til = new By() { Id = byRepository.GetIdFromName(forbindelseTuple.Item2) },
                    AntalSegmenter = forbindelseTuple.Item3
                };

                telstarForbindelseRepository.Add(forbindelse);
            }
        }
    }
}