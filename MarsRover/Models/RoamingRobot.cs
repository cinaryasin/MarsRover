using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class RoamingRobot  //Gezici Robot
    {
        //Robotun X pozisyonu
        public int PositionXPlane { get; set; }
        //Robotun Y pozisyonu
        public int PositionYPlane { get; set; }
        //Robotun baktığı yön
        public char Direction { get; set; }
    }
}
