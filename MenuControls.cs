using System;
using System.IO;
namespace ClaredonHighSchoolSkiTrip
{
    public class MenuControls
    {
        protected static void GoToMainMenu()
        {
            string[] MainMenuArray = File.ReadAllLines("MainMenuOptions.csv");
            var MainMenu = new Menu("Main Menu", MainMenuArray);
            MainMenu.OpenMenu(MainMenuArray);
        }

        protected void Exit()
        {
            Environment.Exit(0);
        }
    }
}