using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisInfo
{
    public class KrisInfoResponse
    {
        public int Identifier { get; set; }
        public string PushMessage { get; set; }
        public DateTime Published { get; set; }
        public List<Area> Area { get; set; }
    }
}
