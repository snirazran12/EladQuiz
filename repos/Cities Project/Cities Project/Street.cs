using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_Project
{
    class Street
    {
        private static int ID_Counter = 0;
        private string name { get; set; }
        private int ID { get; set; }

        private int cityId;
        public Street(string streetName, int cityId)
        {
            name = streetName;
            ID = System.Threading.Interlocked.Increment(ref ID_Counter);
            ID_Counter++;
            this.cityId = cityId;
        }

    }
}
