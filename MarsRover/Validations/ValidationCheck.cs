using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Validations
{
    public static class ValidationCheck
    {
        #region Kuralların Kontrolü sağlandı
        public static string Validations(Point Location, RoamingRobot roamingRobot, string command)
        {
            if (!CheckIfRobotLocation(Location, roamingRobot))
            {
                return "Gezici Robotun konumu Platonun Dışında Tanımlanmıştır";
            }
            else if (!CheckIfRobotRotation(roamingRobot))
            {
                return "Gezici Robotun yönü tanımlanamadı";
            }
            else if (!CheckIfCommand(command))
            {
                return "Gezici Robota verilen komut tanımlanamadı";
            }
            return "Başarılı";
        }
        #endregion
        #region Gezici Robota girilen komut harflerinin kontrolü
        private static bool CheckIfCommand(string command)
        {
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'R' || command[i] == 'L' || command[i] == 'M')
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Gezici Robota verilen yönün kontrolü
        private static bool CheckIfRobotRotation(RoamingRobot roamingRobot)
        {
            if (roamingRobot.Direction == 'N' || roamingRobot.Direction == 'E' || roamingRobot.Direction == 'W' || roamingRobot.Direction == 'S')
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Robotun Lokasyon içerisinde bulunup bulunmama durumu
        private static bool CheckIfRobotLocation(Point location, RoamingRobot roamingRobot)
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


    }
}
