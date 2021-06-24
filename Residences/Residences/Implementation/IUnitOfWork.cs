using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Implementation
{
    public interface IUnitOfWork : IDisposable
    {
        BoligContext Context { get; }
        void Commit();
    }
}
