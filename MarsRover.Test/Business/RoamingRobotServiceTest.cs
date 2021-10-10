using MarsRover.Bussines.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Test.Business
{
    public class RoamingRobotServiceTest
    {
        IRoamingRobotService service;
        Models.RoamingRobot model;
        string command;
        [SetUp]
        public void Setup()
        {
            service = new MarsRover.Bussines.RoamingRobotService();
            
            model = new Models.RoamingRobot();

        }
        

        [Test]
        public void ScoutRobot_lokasyon_donmeli()
        {
            model.PositionXPlane = 1;
            model.PositionYPlane = 2;
            model.Direction = 'N';

            command = "LMLMLMLMM";
            
            Assert.AreEqual("1 3 N", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));
        }
        [Test]
        public void ScoutRobot_()
        {
            model.PositionXPlane = 1;
            model.PositionYPlane = 2;
            model.Direction = 'N';

            command = "LMLMLMLMM";

            Assert.AreEqual("1 3 N", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));
        }
    }
}
