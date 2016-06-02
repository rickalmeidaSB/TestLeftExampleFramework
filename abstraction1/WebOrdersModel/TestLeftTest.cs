using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects.Web;
using SmartBear.TestLeft.TestObjects;

namespace WebOrdersModel
{
    [TestClass]
    public class TestLeftTest : UnitTestClassBase
    {
        [TestMethod]
        public void MultiBrowserTest()
        {
            AddOrderTest(BrowserType.Chrome);
            AddOrderTest(BrowserType.IExplorer);
 

        }
                
        private void AddOrderTest(BrowserType browserType)
        {
            Driver.Applications.RunBrowser(browserType, "http://secure.smartbearsoftware.com/samples/testcomplete11/WebOrders/login.aspx");

            IWebBrowser browser = Driver.Find<IWebBrowser>(new WebBrowserPattern()
            {
                ObjectIdentifier = browserType.ToString().ToLower().TrimEnd('r')
            });


            const string customerName = "John Black";

            WebOrdersAppModel app = new WebOrdersAppModel(browser);

            Login(app, "Tester", "test");

            IWebCell cell;
            Assert.IsFalse(app.OrdersPage.OrdersTable.TryFind<IWebCell>(new WebCellElementPattern()
            {
                ColumnIndex = 1,
                contentText = customerName
            }, out cell));

            ToNewOrderView(app);
            AddNewOrder(app, customerName);

            ToAllOrdersView(app);
            Assert.IsTrue(app.OrdersPage.OrdersTable.TryFind<IWebCell>(new WebCellElementPattern()
            {
                ColumnIndex = 1,
                contentText = customerName
            }, out cell));

            browser.Close();
        }

        private void Login(WebOrdersAppModel app, string username, string password)
        {
            LoginPageModel login_page = app.LoginPage;

            login_page.UserNameEdit.SetText(username);
            login_page.PasswordEdit.SetText(password);

            login_page.LoginButton.Click();
        }


        private void BrittleLogin(IWebBrowser browser, string username, string password)
        {
            // Find the user name text box
            var UserNameEdit = browser.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_username"
            }, 5);

            // Set the user name text box
            UserNameEdit.SetText(username);

            // Find the password text box
            var PasswordEdit = browser.Find<ITextEdit>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_password"
            }, 5);

            // Set the password text box
            PasswordEdit.SetText(password);

            // Find the login button
            var LoginButton = browser.Find<IButton>(new WebElementPattern()
            {
                ObjectIdentifier = "MainContent_login_button"
            }, 5);

            // click the login button
            LoginButton.Click();
        }

        private void ToNewOrderView(WebOrdersAppModel app)
        {
            app.OrderLink.Click();
        }

        private void AddNewOrder(WebOrdersAppModel app, string customerName)
        {
            NewOrderPageModel new_order_page = app.NewOrderPage;

            new_order_page.ProductCombo.ClickItem("ScreenSaver");
            new_order_page.QuantityEdit.SetText("4");
            new_order_page.CustomerNameEdit.SetText(customerName);
            new_order_page.AddressEdit.SetText("Light street");
            new_order_page.CityEdit.SetText("Rain city");
            new_order_page.CountryEdit.SetText("US");
            new_order_page.ZipEdit.SetText("123456");
            new_order_page.MasterCardRadio.Click();
            new_order_page.CardNumber.SetText("1324354657");
            new_order_page.DateEdit.SetText(DateTime.Now.ToString("MM/yy"));

            new_order_page.InsertLink.Click();
        }

        private void ToAllOrdersView(WebOrdersAppModel app)
        {
            app.ViewAllOrdersLink.Click();
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
