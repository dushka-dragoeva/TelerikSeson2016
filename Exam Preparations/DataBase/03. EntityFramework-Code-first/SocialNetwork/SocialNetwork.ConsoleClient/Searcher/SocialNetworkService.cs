namespace SocialNetwork.ConsoleClient.Searcher
{
    using Data.Common;
    using Models;
    using System;
    using System.Collections;
    using System.Linq;

    public class SocialNetworkService : ISocialNetworkService
    {
        //  private IUnitOfWork unitOfWork;
        private IRepository<User> users;
        private IRepository<Image> images;
        private IRepository<Post> posts;
        private IRepository<Friendship> friendships;

        public SocialNetworkService(IRepository<User> users, IRepository<Image> images, IRepository<Post> posts, IRepository<Friendship> friendships)
        {
            this.users = users;
            this.images = images;
            this.posts = posts;
            this.friendships = friendships;
        }

        //public SocialNetworkService()
        //{
        //    this.DbContext = new SocialNetworkDbContext();
        //}

        //public SocialNetworkDbContext DbContext { get; set; }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {

            return this.users.All()
               .Where(u => u.RegisteredOn.Value.Year >= year)
               .Select(u => new
               {
                   u.UserName,
                   u.FirstName,
                   u.LastName,
                   Images = u.Images.Count()
               })
               .ToList();
        }

        public IEnumerable GetPostsByUser(string username)
        {
            return this.posts.All()
                 .Where(p => p.TaggedUsers.Any(u => u.UserName == username))
                 .Select(p => new
                 {
                     p.PostenOn,
                     p.Content,
                     Users = p.TaggedUsers.Select(u => u.UserName)
                 })
                 .ToList();
        }


        /// <summary>
        /// Get all approved friendships, ordered ascending by the friendship date and
        /// paged by the provided numbers. Select FirstUserUsername, FirstUserImage,
        /// SecondUserUsername, SecondUserImage. Images are just the URLs of the first image for each user.
        /// </summary>
        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1) * pageSize;
            var take = pageSize;

            return this.friendships.All()
                .Where(f => f.Approved == true)
                .OrderBy(f => f.FriendsSience)
                .Skip(skip)
                .Take(take)
                               .Select(f => new
                               {
                                   Date = f.FriendsSience,
                                  // Approved = f.Approved,
                                   FirstUsername = f.FirstUser.UserName,
                                   FirstImage = f.FirstUser.Images.Select(i => i.Url).FirstOrDefault(),
                                   SecondUsername = f.SecondUser.UserName,
                                   SecondImage = f.SecondUser.Images.Select(i => i.Url).FirstOrDefault(),
                               })

                .ToList();
        }

        /// <summary>
        /// Get all usernames of all the unique users with which the provided user by username
        /// has at least one chat message, ordered alphabetically.
        /// </summary>
        public IEnumerable GetChatUsers(string username)
        {
            return this.friendships.All()
                .Where(f => f.FirstUser.UserName == username && f.Messages.Count > 0)
                .Select(f => f.SecondUser.UserName)
                .Union(this.friendships.All()
                .Where(f => f.SecondUser.UserName == username && f.Messages.Count > 0)
                .Select(f => f.FirstUser.UserName)
                )
                .Distinct()
                .OrderBy(u => u)
                .ToList();
        }
    }
}
