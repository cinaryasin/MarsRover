using MarsRover.Bussines.Services;
using MarsRover.Models;
using MarsRover.Validations;
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
        // N E W S
        public string ScoutRobot(Point location, RoamingRobot roamingRobot, string command)
        {
            if (ValidationCheck.Validations(location, roamingRobot, command) == "Başarılı")
            {
                CommandControl(roamingRobot, command);
                return (roamingRobot.PositionXPlane + " " + roamingRobot.PositionYPlane + " " + roamingRobot.Direction);
            }

            return ValidationCheck.Validations(location, roamingRobot, command);

        }





        #region Command Control
        private void CommandControl(RoamingRobot roamingRobot, string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if (CheckCommand(command[i], roamingRobot))
                {
                    if (CheckIfRoamingRobotXDirection(roamingRobot.Direction)) // Robotun X pozisyonundayken E veya W ye göre baktığı yöndeki X değerini değiştirme
                    {
                        CheckXDirection(roamingRobot);
                    }
                    else if (CheckIfRoamingRobotYDirection(roamingRobot.Direction))// Robotun Y pozisyonundayken baktığı yöne göre Y değerini değiştirme
                    {
                        CheckYDirection(roamingRobot);
                    }
                }
            }
        }
        #endregion

        #region Move komutu geldiğinde Gezici Robotun X yönündeki hareketi
        private void CheckXDirection(RoamingRobot roamingRobot)
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
        #endregion

        #region Move komutu geldiğinde Gezici Robotun Y yönündeki hareketi
        private void CheckYDirection(RoamingRobot roamingRobot)
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
        #endregion

        #region Gelen komuta göre Gezici Robotun izleyeceği yol
        private bool CheckCommand(char command, RoamingRobot roamingRobot)
        {
            if (command == 'M')
            {
                return true;
            }
            else if (command == 'R')
            {
                CheckCommandR(roamingRobot);
            }
            else if (command == 'L')
            {
                CheckCommandL(roamingRobot);
            }
            return false;
        }
        #endregion

        #region Komut L Geldiğinde
        private static void CheckCommandL(RoamingRobot roamingRobot)
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
        #endregion

        #region Komut R Geldiğinde
        private static void CheckCommandR(RoamingRobot roamingRobot)
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