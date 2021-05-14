using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi12.Interfaces
{
    public interface IDatabaseRepository
    {
        Task<string> GetDatabaseVersion();
    }
}
