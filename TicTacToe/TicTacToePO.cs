using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace TicTacToe
{
    public class TicTacToePO
    {

        private IWebDriver driver;
        private readonly By bySquareTopLeft;
        private readonly By bySquareTop;
        private readonly By bySquareTopRight;
        private readonly By bySquareLeft;
        private readonly By bySquare;
        private readonly By bySquareRight;
        private readonly By bySquareBottomLeft;
        private readonly By bySquareBottom;
        private readonly By bySquareBottomRight;
        private readonly By byScoreElements;

        public TicTacToePO(IWebDriver driver)
        {
            this.driver = driver;

            bySquareTopLeft = By.XPath("//div[@class='game']/div/div[1]");
            bySquareTop = By.XPath("//div[@class='game']/div/div[2]");
            bySquareTopRight = By.XPath("//div[@class='game']/div/div[3]");

            bySquareLeft = By.XPath("//div[@class='game']/div/div[4]");
            bySquare = By.XPath("//div[@class='game']/div/div[5]");
            bySquareRight = By.XPath("//div[@class='game']/div/div[6]");

            bySquareBottomLeft = By.XPath("//div[@class='game']/div/div[7]");
            bySquareBottom = By.XPath("//div[@class='game']/div/div[8]");
            bySquareBottomRight = By.XPath("//div[@class='game']/div/div[9]");

            byScoreElements = By.ClassName("score");
        }

        public IWebElement SquareTopLeft => driver.FindElement(bySquareTopLeft);
        public IWebElement SquareTop => driver.FindElement(bySquareTop);
        public IWebElement SquareTopRight => driver.FindElement(bySquareTopRight);
        public IWebElement SquareLeft => driver.FindElement(bySquareLeft);
        public IWebElement Square => driver.FindElement(bySquare);
        public IWebElement SquareRight => driver.FindElement(bySquareRight);
        public IWebElement SquareBottomLeft => driver.FindElement(bySquareBottomLeft);
        public IWebElement SquareBottom => driver.FindElement(bySquareBottom);
        public IWebElement SquareBottomRight => driver.FindElement(bySquareBottomRight);
        public ReadOnlyCollection<IWebElement> ScoreList => driver.FindElements(byScoreElements);
        public List<IWebElement> AllSquaresList => new List<IWebElement>() {              
            SquareTopLeft, SquareTop, SquareTopRight,
            SquareLeft, Square, SquareRight,
            SquareBottomLeft, SquareBottom, SquareBottomRight
        };

    }
}