using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TicTacToe
{
    public class TicTacToeHelpers : TicTacToePO
    {
        private readonly IWebDriver driver;

        public TicTacToeHelpers(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void OpenGamePage()
        {
            driver.Navigate().GoToUrl("https://playtictactoe.org/");
        }

        public bool DivIsChecked(IWebElement element)
        {
            IWebElement child = element.FindElement(By.TagName("div"));
            string classValue = child.GetAttribute("class");
            if (classValue.Contains("x") || classValue.Contains("o"))
            {
                return true;
            }
            return false;
        }

        public IWebElement GetFreeRandomElement()
        {
            List<IWebElement> allSquares = new List<IWebElement>() {
                SquareTopLeft, SquareTop, SquareTopRight,
                SquareLeft, Square, SquareRight,
                SquareBottomLeft, SquareBottom, SquareBottomRight
            };

            List<IWebElement> freeElements = new List<IWebElement>() { };
            foreach (IWebElement element in allSquares)
            {
                bool divChecked = DivIsChecked(element);
                
                if (!divChecked)
                {
                    freeElements.Add(element);
                }
            }

            Random item = new Random();
            int randomNumber = item.Next(0, freeElements.Count);
            IWebElement randomElement = freeElements[randomNumber];

            int cell = randomNumber + 1;
            return randomElement;
        }

        public bool IsGameOpen()
        {
            IWebElement restart = driver.FindElement(By.ClassName("restart"));
            string cssValue = restart.GetCssValue("display");
            if (cssValue.Contains("block"))
            {
                return false;
            }
            return true;
        }

        public bool ScoreIncremented()
        {
            foreach (IWebElement score in ScoreList)
            {
                if (score.Text != "0")
                {
                    return true;
                }
            }
            return false;
        }

        public List<object> GetFreeRandomElementWithID()
        {
            List<IWebElement> freeElements = new List<IWebElement>() { };
            foreach (IWebElement element in AllSquaresList)
            {
                bool divChecked = DivIsChecked(element);

                if (!divChecked)
                {
                    freeElements.Add(element);
                }
            }

            Random item = new Random();
            int randomNumber = item.Next(0, freeElements.Count);
            IWebElement randomElement = freeElements[randomNumber];

            int cell = randomNumber + 1;

            return new List<object>() { randomElement, cell };
        }

    }
}