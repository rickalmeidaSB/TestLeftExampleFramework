using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.Web;

namespace WebOrders
{
    [TestClass]
    public class TestLeftTest : UnitTestClassBase
    {
        [TestMethod]
        public void AddOrderTest()
        {
            const string customerName = "John Black";

            IWebBrowser browser = Driver.Applications.RunBrowser(BrowserType.IExplorer);
            Login(browser, "Tester", "test");

            IWebCell cell;
            Assert.IsFalse(browser.Find<IWebPage>(new WebPagePattern()
            {
                URL = "*/WebOrders/Default.aspx",
                Visible = true
            }).Find<IWebTable>(new WebElementPattern()
            {
                ObjectType = "Table",
                ObjectIdentifier = "MainContent_orderGrid"
            }, 7).TryFind<IWebCell>(new WebCellElementPattern()
            {
                ColumnIndex = 1,
                contentText = customerName
            }, out cell));

            ToNewOrderView(browser);
            AddNewOrder(browser, customerName);

            ToAllOrdersView(browser);
            Assert.IsTrue(browser.Find<IWebPage>(new WebPagePattern()
            {
                URL = "*/WebOrders/Default.aspx",
                Visible = true
            }).Find<IWebTable>(new WebElementPattern()
            {
                ObjectType = "Table",
                ObjectIdentifier = "MainContent_orderGrid"
            }, 7).TryFind<IWebCell>(new WebCellElementPattern()
            {
                ColumnIndex = 1,
                contentText = customerName
            }, out cell));

            browser.Close();
        }

        private void Login(IWebBrowser browser, string username, string password)
        {
            IWebPage page = browser.ToUrl("http://secure.smartbearsoftware.com/samples/testcomplete11/WebOrders/login.aspx");

            ITextEdit textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_username"
            }, 3);
            textbox.SetText(username);

            ITextEdit passwordBox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_password"
            }, 3);
            passwordBox.SetText(password);

            IButton submitButton = page.Find<IButton>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_login_button"
            }, 3);
            submitButton.Click();
        }

        private void ToNewOrderView(IWebBrowser browser)
        {
            IWebElement link = browser.Find<IWebPage>(new WebPagePattern()
            {
                URL = "*/WebOrders/*.aspx",
                Visible = true
            }).Find<IWebElement>(new WebElementPattern()
            {
                ObjectType = "Link",
                contentText = "Order"
            }, 4);
            link.Click();
        }

        private void AddNewOrder(IWebBrowser browser, string customerName)
        {
            IWebPage page = browser.Find<IWebPage>(new WebPagePattern()
            {
                URL = "*/WebOrders/Process.aspx",
                Visible = true
            });

            IComboBox select = page.Find<IComboBox>(new WebElementPattern()
            {
                ObjectType = "Select",
                ObjectIdentifier = "MainContent_fmwOrder_ddlProduct"
            }, 7);
            select.ClickItem("ScreenSaver");

            ITextEdit textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_txtQuantity"
            }, 7);
            textbox.SetText("4");

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_txtName"
            }, 7);
            textbox.SetText(customerName);

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox2"
            }, 7);
            textbox.SetText("Light street");

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox3"
            }, 7);
            textbox.SetText("Rain city");

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox4"
            }, 7);
            textbox.SetText("US");

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox5"
            }, 7);
            textbox.SetText("123456");

            IRadioButton radioButton = page.Find<IWebTable>(new WebElementPattern()
            {
                ObjectType = "Table",
                ObjectIdentifier = "MainContent_fmwOrder_cardList"
            }, 7).Find<IRadioButton>(new WebElementPattern()
            {
                ObjectType = "RadioButton",
                ObjectIdentifier = "MainContent_fmwOrder_cardList_0"
            }, 2);
            radioButton.Click();

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox6"
            }, 7);
            textbox.SetText("1324354657");

            textbox = page.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectType = "Textbox",
                ObjectIdentifier = "MainContent_fmwOrder_TextBox1"
            }, 7);
            textbox.SetText(DateTime.Now.ToString("MM/yy"));

            IWebElement link = page.Find<IWebElement>(new WebElementPattern()
            {
                ObjectType = "Link",
                ObjectIdentifier = "MainContent_fmwOrder_InsertButton"
            }, 8);
            link.Click();
        }

        private void ToAllOrdersView(IWebBrowser browser)
        {
            IWebElement link = browser.Find<IWebPage>(new WebPagePattern()
            {
                URL = "*/WebOrders/*.aspx",
                Visible = true
            }).Find<IWebElement>(new WebElementPattern()
            {
                ObjectType = "Link",
                contentText = "View all orders"
            }, 4);
            link.Click();
        }
        
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            UnitTestClassBase.InitializeClass(context);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            UnitTestClassBase.FinalizeClass();
        }
        #endregion
    }
}
