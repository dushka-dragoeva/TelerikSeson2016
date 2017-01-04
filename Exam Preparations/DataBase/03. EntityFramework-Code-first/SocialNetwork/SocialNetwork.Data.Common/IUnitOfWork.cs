using System;

namespace SocialNetwork.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
