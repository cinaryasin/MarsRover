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
        public void ScoutRobot_expected_output_location()
        {
            model.PositionXPlane = 1;
            model.PositionYPlane = 2;
            model.Direction = 'N';

            command = "LMLMLMLMM";
            
            Assert.AreEqual("1 3 N", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));

            model.PositionXPlane = 3;
            model.PositionYPlane = 3;
            model.Direction = 'E';

            command = "MMRMMRMRRM";
            Assert.AreEqual("5 1 E", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));
        }
        [Test]
        public void ScoutRobot_specified_command_errors_be_return()
        {
            model.PositionXPlane = 3;
            model.PositionYPlane = 3;
            model.Direction = 'N'; 

            command = "LMLMLMTMM"; // robota verilen komutta hatalı harf kullanıldı

            Assert.AreEqual("Gezici Robota verilen komut tanımlanamadı", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));

        }
        [Test]
        public void ScoutRobot_specified_direction_errors_be_return()
        {
            model.PositionXPlane = 3;
            model.PositionYPlane = 3;
            model.Direction = 'O'; // Robot yönü belirsiz girildi

            command = "LMLMLMM";

            Assert.AreEqual("Gezici Robotun yönü tanımlanamadı", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));

        }
        [Test]
        public void ScoutRobot_specified_location_errors_be_return()
        {
            model.PositionXPlane = 6; //Plato sınırları dışında veri girildi
            model.PositionYPlane = 4; //Plato sınırları dışında veri girildi
            model.Direction = 'O'; 

            command = "LMLMLMM";

            Assert.AreEqual("Gezici Robotun konumu Platonun Dışında Tanımlanmıştır", service.ScoutRobot(new System.Drawing.Point(5, 5), model, command));

        }
    }
}
