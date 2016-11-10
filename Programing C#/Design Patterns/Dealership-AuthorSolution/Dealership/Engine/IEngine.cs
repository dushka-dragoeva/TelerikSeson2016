using Dealership.Contracts;
using System.Collections.Generic;

namespace Dealership.Engine
{
    public interface IEngine
    {
        ICollection<IUser> Users { get; }

        IUser LoggedUser { get; }

        void SetLoggedUser(IUser user);

        void Start();

        void Reset();
    }
}
