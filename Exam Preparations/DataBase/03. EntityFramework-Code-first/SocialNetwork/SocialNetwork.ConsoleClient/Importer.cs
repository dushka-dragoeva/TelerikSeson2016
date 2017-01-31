using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.Xml.Serialization;
using SocialNetwork.ConsoleClient.XmlModel;
using SocialNetwork.Data;
using SocialNetwork.Models;
using System.IO;

namespace SocialNetwork.ConsoleClient
{

    public class Importer
    {
        private readonly TextWriter textWrite;
        //  private readonly SocialNetworkDbContext dbContext;


        private Importer(TextWriter textWr)
        {
            this.textWrite = textWr;
            // this.dbContext = context;
        }

        public static Importer Create(TextWriter textWr)
        {
            return new Importer(textWr);
        }


        public void Import()
        {
            var friendships = Deserialize<FriendshipXmlModel>("XmlFiles/Friendships.xml", "Friendships");
            this.ProcessFrienships(friendships);
            this.textWrite.WriteLine();

            var posts = Deserialize<PostXmlModel>("XmlFiles/Posts.xml", "Posts");
            this.ProcessPosts(posts);
            this.textWrite.WriteLine();

        }

        private void ProcessPosts(IEnumerable<PostXmlModel> posts)
        {
            var context = new SocialNetworkDbContext();

            foreach (var p in posts)
            {
                Post post = new Post()
                {
                    PostenOn = p.PostedOn,
                    Content = p.Content,
                };

                var usernames = p.Users.Split(',');
                var user = new User();
                foreach (var username in usernames)
                {
                    user = context.Users.SingleOrDefault(u => u.UserName == username);
                    post.TaggedUsers.Add(user);
                }


                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private void ProcessFrienships(IEnumerable<FriendshipXmlModel> friendships)
        {
            var usersNames = new HashSet<string>();
            var context = new SocialNetworkDbContext();
            var counter = 0;

            foreach (var fs in friendships)
            {
                User firstUser = GetUser(context, fs.FirstUser, usersNames);
                User secondUser = GetUser(context, fs.SecondUser, usersNames);

                Friendship friendship = new Friendship()
                {
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                    FriendsSience = fs.FriendsSince,
                    Approved = fs.Approved
                };

                var messages = fs.Messages;

                foreach (var msg in messages)
                {
                    Message message = new Message()
                    {
                        Author = msg.Author == firstUser.UserName ? firstUser : secondUser,
                        Content = msg.Content,
                        SentOn = msg.SentOn,
                        SeenOn = msg.SeenOn
                    };

                    friendship.Messages.Add(message);
                }

                context.Friendship.Add(friendship);
                counter++;
                if (counter % 100==0)
                {
                    this.textWrite.Write("*");
                }
            }

            context.SaveChanges();
        }

        private User GetUser(SocialNetworkDbContext context, UserXmlModel model, HashSet<string> addedUsers)
        {
            var user = new User();
            bool isAlreadyadded = addedUsers.Contains(model.Username);

            if (isAlreadyadded)
            {
                user = context.Users.SingleOrDefault(u => u.UserName == model.Username);
            }
            else
            {
                addedUsers.Add(model.Username);

                user = new User()
                {
                    UserName = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegisteredOn = model.RegisteredOn
                };

                var images = model.Images;
                foreach (var img in images)
                {
                    Image image = new Image()
                    {
                        Url = img.ImageUrl,

                        FileExtension = img.FileExtension
                    };

                    if (!user.Images.Contains(image))
                    {
                        user.Images.Add(image);
                    }
                }

                context.Users.Add(user);
                context.SaveChanges();
            }

            return user;
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found!", fileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }

        public static void ImportFriendships(SocialNetworkDbContext dbContext)
        {


        }
    }
    // Deserialize<FriendshipXmlModel>("XmlFiles/Friendships.xml", "Friendships");
}
