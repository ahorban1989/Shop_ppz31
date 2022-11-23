using System;
using Shop_PPZ_31.models;
using Shop_PPZ_31.views;

namespace Shop_PPZ_31
{
    class Program
    {
        internal MainMenu MainMenu { get; set; }
        static void Main(string[] args)
        {


            tests.TestHrManager testHrManager = new tests.TestHrManager();
            testHrManager.RunTest();

            views.MainMenu mainMenu = new MainMenu();
            mainMenu.Run();

        }
    }
}
