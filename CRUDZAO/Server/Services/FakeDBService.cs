using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDZAO.Server.Services
{
    public class FakeDBService : IFakeDBService
    {
        public ConcurrentDictionary<Guid, string> Db { get; set; } = new ConcurrentDictionary<Guid, string>();
    }

    public interface IFakeDBService
    {
        ConcurrentDictionary<Guid, string> Db { get; set; }
    }
}
