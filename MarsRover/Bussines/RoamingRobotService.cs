using MarsRover.Bussines.Services;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Bussines
{
    public class RoamingRobotService : IRoamingRobotService
    {
        public string ScoutRobot(Point Location, RoamingRobot roamingRobot, string command)
        {
            if (!CheckIfRobotLocation(Location, roamingRobot))
            {
                return "Robot konumu Lokasyonun Dışında Tanımlanmıştır";
            }
            CommandControl(roamingRobot, command);
            return (roamingRobot.PositionXPlane + " " + roamingRobot.PositionYPlane + " " + roamingRobot.Direction);
        }

        private void CommandControl(RoamingRobot roamingRobot, string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if (CheckCommand(command[i], roamingRobot))
                {
                    if (CheckIfRoamingRobotXDirection(roamingRobot.Direction))// Robotun X pozisyonundayken baktığı yöne göre X değerini değiştirme
                    {
                        if (roamingRobot.Direction == 'E')
                        {
                            roamingRobot.PositionXPlane++;
                        }
                        else
                        {
                            roamingRobot.PositionXPlane--;
                        }
                    }
                    else if (CheckIfRoamingRobotYDirection(roamingRobot.Direction))// Robotun Y pozisyonundayken baktığı yöne göre Y değerini değiştirme
                    {
                        if (roamingRobot.Direction == 'N')
                        {
                            roamingRobot.PositionYPlane++;
                        }
                        else
                        {
                            roamingRobot.PositionYPlane--;
                        }
                    }
                }
            }
        }

        

        #region Komut Kontrolü ile Robotun yönünü belirleme
        private bool CheckCommand(char command, RoamingRobot roamingRobot)
        {

            if (command == 'M')
            {
                return true;
            }
            else if (command == 'R')
            {
                if (roamingRobot.Direction == 'W')
                {
                    roamingRobot.Direction = 'N';
                }
                else if (roamingRobot.Direction == 'N')
                {
                    roamingRobot.Direction = 'E';
                }
                else if (roamingRobot.Direction == 'E')
                {
                    roamingRobot.Direction = 'S';
                }
                else
                {
                    roamingRobot.Direction = 'W';
                }
            }
            else if (command == 'L')
            {
                if (roamingRobot.Direction == 'N')
                {
                    roamingRobot.Direction = 'W';
                }
                else if (roamingRobot.Direction == 'W')
                {
                    roamingRobot.Direction = 'S';
                }
                else if (roamingRobot.Direction == 'S')
                {
                    roamingRobot.Direction = 'E';
                }
                else
                {
                    roamingRobot.Direction = 'N';
                }
            }


            return false;
        }
        #endregion


        #region Robotun Lokasyon içerisinde bulunup bulunmama durumu
        private bool CheckIfRobotLocation(Point location, RoamingRobot roamingRobot)
        {
            if (roamingRobot.PositionXPlane > location.X)
            {
                return false;
            }
            if (roamingRobot.PositionYPlane > location.Y)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Gezicinin Y Yönünde Bulunup Bulunmama Durumu
        private bool CheckIfRoamingRobotYDirection(char direction)
        {
            if (direction == 'N' || direction == 'S')
            {
                return true;
            }
            return false;

        }
        #endregion
        #region Gezicinin X Yönünde Bulunup Bulunmama Durumu
        private bool CheckIfRoamingRobotXDirection(char direction)
        {
            if (direction == 'E' || direction == 'W')
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}