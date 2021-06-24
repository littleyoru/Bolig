using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public BoligContext Context { get; }

        public UnitOfWork(BoligContext boligContext)
        {
            Context = boligContext;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
