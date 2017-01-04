using System;

namespace PetStore.Data.Common
{
    public  interface IUnitOfWork :IDisposable
    {
        void Commit();
    }
}
