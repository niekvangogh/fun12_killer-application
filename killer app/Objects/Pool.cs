using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killer_app.Objects
{
    public class Pool
    {
        public Pool(long id, List<Pool> pools)
        {
            this.Id = id;
            this.Pools = pools;
        }

        public long Id { get; private set; }

        public List<Pool> Pools { get; private set; }
    }
}
