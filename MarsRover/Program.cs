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

            IRoamingRobotService roamingRobotService = new RoamingRobotService();
            #region Platonun Düzlem Bilgisi
            Console.WriteLine("Platonun Düzlem Bilgisini Belirleyin. Örn: 5 5");
            var locationInput = Console.ReadLine().Split(" ");
            Point location = new Point
            {
                X = Convert.ToInt32(locationInput[0]),
                Y = Convert.ToInt32(locationInput[1])
            };

            #endregion

            Console.WriteLine("Robot sayısı Giriniz. Örn: 2");
            var robotCount = int.Parse(Console.ReadLine());
            var commands = new string[robotCount];
            var roamingRobots = new RoamingRobot[robotCount];
            for (int i = 0; i < robotCount; i++)
            {
                #region Gezicinin Konum ve Yönü
                Console.WriteLine("Geziciyi konumlandıracağınız Konumu ve Yönü belirtiniz. Örn: 1 5 E");
                var roamingRobotInput = Console.ReadLine().Split(" ");
                
                roamingRobots[i] = new RoamingRobot
                {
                    PositionXPlane = Convert.ToInt32(roamingRobotInput[0]),
                    PositionYPlane = Convert.ToInt32(roamingRobotInput[1]),
                    Direction = Convert.ToChar(roamingRobotInput[2])
                };
                #endregion

                #region Komut bilgisi
                Console.WriteLine("Geziciyi Yönlendireceğiniz komutu giriniz. 'L', 'R', 'M' Örn : LMLMMLRMR");
                //string command = Console.ReadLine();
                commands[i] = Console.ReadLine();
                #endregion
               
            }
            for (int i = 0; i < robotCount; i++)
            {
                Console.WriteLine(roamingRobotService.ScoutRobot(location, roamingRobots[i], commands[i]));
            }  


        }
    }
}
