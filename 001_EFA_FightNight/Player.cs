using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_EFA_FightNight
{
    public class Player
    {
        public string MyName { get; set; }
        public int MyPower { get; set; }
        public int MyHealth { get; set; }
        public Player(string myName, int myPower, int myHealth)
        {
            MyName = myName;
            MyPower = myPower;
            MyHealth = myHealth;
        }
      
    }
}
