using MarsRover.Bussines;
using MarsRover.Bussines.Services;
using MarsRover.Models;
using System;
using System.Drawing;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Platonun Düzlem Bilgisi
            Console.WriteLine("Platonun Düzlem Bilgisini Belirleyin = Örn: 5 5");
            var locationInput = Console.ReadLine().Split(" ");
            Point location = new Point
            {
                X = Convert.ToInt32(locationInput[0]),
                Y = Convert.ToInt32(locationInput[1])
            };
            #endregion

            #region Gezicinin Konum ve Yönü

            Console.WriteLine("Geziciyi konumlandıracağınız Konumu belirtiniz");
            var roamingRobotInput = Console.ReadLine().Split(" ");
            RoamingRobot roamingRobot = new RoamingRobot
            {
                PositionXPlane = Convert.ToInt32(roamingRobotInput[0]),
                PositionYPlane = Convert.ToInt32(roamingRobotInput[1]),
                Direction = Convert.ToChar(roamingRobotInput[2])
            };
            #endregion

            #region Komut bilgisi
            Console.WriteLine("Komutu giriniz. Örn : LMLMMLRMR");
            string command = Console.ReadLine();
            #endregion

            IRoamingRobotService roamingRobotService = new RoamingRobotService();
            Console.WriteLine(roamingRobotService.ScoutRobot(location, roamingRobot, command));
        }
    }
}
