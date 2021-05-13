using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_EFA_FightNight
{
    public class Opponent
    {
        public string OppName { get; set; }
        public int OppHealth { get; set; }
        public int OppPower { get; set; }

        public Opponent() { }
        public Opponent(string oppname, int opppower, int opphealth)
        {
            OppName = oppname;
            OppPower = opppower;
            OppHealth = opphealth;
        }

        //public Opponent HP()
        //{
        //    if (OppHealth ==  0)
        //    {
        //        return "Knocked out";
        //    }
        //}
    }
}
