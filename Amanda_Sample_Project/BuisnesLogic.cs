using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Amanda_Sample_Project
{
    public class BuisnesLogic
    {
        private static int doneNothing = 0;

        public static void DoNothing()
        {
            doneNothing += 1000;
 
            Thread.Sleep(1000);
        }

        public static void DoNothingFor(int i)
        {
            doneNothing += i;

            Thread.Sleep(i);
        }

        public static void DoNothingForFactor(double d, int i)
        {
            doneNothing += (int) Math.Pow(d, i);

            Thread.Sleep((int) Math.Pow(d, i));
        }

        public static int GetWastedTime()
        {
            return doneNothing;
        }

        public static string GetUsersUsername(User usr)
        {
            return usr.Username;
        }

        public static User SpliceUsers(User usr1, User usr2)
        {
            return new User()
                       {
                           ID = usr1.ID,
                           Username = usr2.Username,
                           Password = usr1.Password + usr2.Password
                       };
        }
    }
}