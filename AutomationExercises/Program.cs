using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://candidate.jamacloud.com";
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            
            var UserName = driver.FindElement(By.Id("j_username"));
            var Password = driver.FindElement(By.Id("j_password"));
            var LogInBtn = driver.FindElement(By.Id("loginButton"));
            UserName.SendKeys("candidate-53ab5");
            Password.SendKeys("j@M@2018");
            LogInBtn.Click();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#j-header-tab-ct > li:nth-child(2)"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-comment"))).Click();
            var CommentBox = driver.FindElement(By.Id("js-add-comment-field"));
            var CommentText = "Jama Rocks!";
            CommentBox.SendKeys(CommentText);
            var CommentBtn = driver.FindElement(By.CssSelector(".js-add-comment"));
            CommentBtn.Click();

            /*var SubmittedComment = driver.FindElements(By.ClassName("comment-container"))[0];
            var SubmittedCommentText = SubmittedComment.FindElement(By.ClassName("js-root-comment-text-wrapper")).Text;
            Console.WriteLine(SubmittedCommentText);
            if (CommentText==SubmittedCommentText)
                return true;*/

            driver.PageSource.Contains(CommentText);
            driver.Quit();
        }

    }

}
