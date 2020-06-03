using System.Threading;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TicTacToe
{
    public class TestGame : IDisposable
    {

        private readonly IWebDriver driver;
        private readonly TicTacToeHelpers ticTacToe;

        public TestGame()
        {
            DriverSetUp driverSetUp = new DriverSetUp();
            driverSetUp.SetUpDrivers();

            driver = new ChromeDriver(driverSetUp.ChromeDriverFolder);

            ticTacToe = new TicTacToeHelpers(driver);
        }

        [Fact]
        public void RandomGame()
        {
            // Open the game page;
            ticTacToe.OpenGamePage();

            // Check if the game is "open" to play;
            Assert.True(ticTacToe.IsGameOpen());

            // Play until game ends;
            while(ticTacToe.IsGameOpen())
            {
                IWebElement cellToClick = ticTacToe.GetFreeRandomElement();
                cellToClick.Click();

                Thread.Sleep(500); // FIX ME
            }

            Thread.Sleep(1000); // FIX ME

            bool scoreChanged = ticTacToe.ScoreIncremented();
            Assert.True(scoreChanged);
        }

        public void Dispose()
        {
            driver.Quit();
        }
        
    }
}
