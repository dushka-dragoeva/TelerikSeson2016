namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using Data;
    public class DataSearcher
    {
        ISocialNetworkService service;

        public DataSearcher(ISocialNetworkService socialService)
        {
            this.service = socialService;
        }
        public void Search()
        {
            var users = this.service.GetUsersAfterCertainDate(2013);
            var postsByUsers = this.service.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
           
            var friendships = this.service.GetFriendships(2, 10);
            var chatUsers = this.service.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            //var jsons = new List<string>();
            //jsons.Add(JsonConvert.SerializeObject(users, Formatting.Indented));
            //jsons.Add(JsonConvert.SerializeObject(postsByUsers, Formatting.Indented));
            //jsons.Add(JsonConvert.SerializeObject(friendships, Formatting.Indented));
            //jsons.Add(JsonConvert.SerializeObject(chatUsers, Formatting.Indented));



            //for (int i = 1; i <= jsons.Count; i++)
            //{
            //    using (var writer = new StreamWriter($"Result{i}"))
            //    {
            //        writer.WriteLine(jsons[i - 1]);
            //    }
            //}



            //   var xmls = new List<string>();
            var db = new SocialNetworkDbContext();

            var xmlSerializer = new XmlSerializer(db.Users.GetType(), new XmlRootAttribute("Users"));
            using (var fs = new FileStream($"XmlResult", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, db.Users);
            }
            System.Console.WriteLine();
            System.Console.WriteLine("File Ready ready.");


        }
    }
}
