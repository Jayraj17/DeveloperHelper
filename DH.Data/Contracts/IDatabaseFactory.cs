using DH.Data.Database;
using System;

namespace DH.Data.Contracts
{
    public interface IDatabaseFactory : IDisposable
    {
        DeveloperHelperEntities Get();
    }
}
