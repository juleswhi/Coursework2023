using System;
using System.IO;
namespace ClaredonHighSchoolSkiTrip
{
    public class MenuControls
    {
        private static string createAscii()
        {
            string[] ascii = new string[6];
            string finalAscii = "";
            ascii[0] = @"  __  __       _         __  __                  ";
            ascii[1] = @" |  \/  |     (_)       |  \/  |                 ";
            ascii[2] = @" | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ ";
            ascii[3] = @" | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |";
            ascii[4] = @" | |  | | (_| | | | | | | |  | |  __/ | | | |_| |";
            ascii[5] = @" |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|";

            for (int i = 0; i < ascii.Length; i++)
            {
                finalAscii = finalAscii + "\n" + ascii[i];
            }

            return finalAscii;
        }




        protected static void GoToMainMenu()
        {
            string[] MainMenuArray = File.ReadAllLines("MainMenuOptions.csv");
            var MainMenu = new Menu("Main Menu", MainMenuArray, createAscii());
            MainMenu.OpenMenu(MainMenuArray);
        }

        protected void Exit()
        {
            Environment.Exit(0);
        }
    }
}