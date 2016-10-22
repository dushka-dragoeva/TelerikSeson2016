
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LiveDemo
{
    public class Vendor
    {
        [JsonIgnore] // => pri serializaciq go skipva
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name", Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public class Phone
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("vendor")]
        public Vendor Vendor { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var phone = new Phone
            {
                Id = 1,
                Model = "Gamaxy S7",
                Vendor = new Vendor
                {
                    Id = 3,
                    Name = "Samsung"
                }
            };


            var xmlUrl = "../../musicCatalog.xml";
            var jsonUrl = "../../musicCataloq.json";

            var xml = File.ReadAllText(xmlUrl);
            var doc = XDocument.Parse(xml);
            var jsonFromXml = JsonConvert.SerializeXNode(doc, Formatting.Indented);
            File.WriteAllText(jsonUrl, jsonFromXml);

            var xmlFromJson = JsonConvert.DeserializeXNode(jsonFromXml,"catalog");
            Console.WriteLine( xmlFromJson );

           // Console.WriteLine(jsonFromXml);



            // var json = JsonConvert.SerializeObject(phone, Formatting.Indented);
            // var poco = JsonConvert.DeserializeObject<Phone>(json);
            // Console.WriteLine(json);
            // Console.WriteLine(poco);

            //var url = "../../phone.json";

            //var json = File.ReadAllText(url);

            //var jobject = JObject.Parse(json)["result"];
            //var count = jobject.Children()
            //    .FirstOrDefault(t => t.Path == "count");

            //int countN = jobject.Value<int>("count");

            //var phonesWithID1 = jobject["phones"]
            //      .Where(ph => ph.Value<int>("id") == 1)
            //      .Select(phJson => new
            //      {
            //          Model = phJson.Value<string>("model")
            //      });
            //foreach (var ph in phonesWithID1)
            //{
            //    Console.WriteLine(ph.Model);
            //}

            // SaveToFile(url, phone);
            // var phoneCopy = LoadFromFile(url);
            // Console.WriteLine(phoneCopy.Vendor.Name);




        }

        private static Phone LoadFromFile(string url)
        {
            var json = File.ReadAllText(url);
            var poco = JsonConvert.DeserializeObject<Phone>(json);
            return poco;
        }

        private static void SaveToFile(string url, Phone phone)
        {
            var json = JsonConvert.SerializeObject(phone, Formatting.Indented);
            File.WriteAllText(url, json);
        }
    }
}


