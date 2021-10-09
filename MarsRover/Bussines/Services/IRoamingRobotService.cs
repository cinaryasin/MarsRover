using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Bussines.Services
{
    public interface IRoamingRobotService
    {
        public string ScoutRobot(Point Location, RoamingRobot roamingRobot, string command); // keşif robotu

    }
}
