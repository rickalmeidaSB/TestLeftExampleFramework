using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.Web;

namespace WebOrdersModel
{
    public class LoginPageControls
    {
        private IWebPage _page;
        public LoginPageControls(IWebPage page)
        {
            _page = page;
        }

        public ITextEdit UserNameEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectIdentifier = "MainContent_username"
                }, 3);
            }
        }

        public ITextEdit PasswordEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectIdentifier = "MainContent_password"
                }, 3);
            }
        }

        public IButton LoginButton
        {
            get
            {
                return _page.Find<IButton>(new WebElementPattern()
                {
                    ObjectIdentifier = "MainContent_login_button"
                }, 3);
            }
        }

    }

    public class LoginPageModel
    {
        private LoginPageControls _controls;
        private IWebPage _page;

        public LoginPageModel(IWebPage page)
        {
            _controls = new LoginPageControls(page);
            _page = page;
        }

        public string UserNameEdit
        {
            get
            {
                return _controls.UserNameEdit.wText;
            }
            set
            {
                _controls.UserNameEdit.SetText(value);
            }
        }

        public string PasswordEdit
        {
            get
            {
                return _controls.PasswordEdit.wText;
            }
            set
            {
                _controls.PasswordEdit.SetText(value);
            }
        }

        public void LoginButtonClick()
        {

            _controls.LoginButton.Click();
        }

    }


    class NewOrderPageModel
    {
        private IWebPage _page;

        public NewOrderPageModel(IWebPage page)
        {
            _page = page;
        }

        public IComboBox ProductCombo
        {
            get
            {
                return _page.Find<IComboBox>(new WebElementPattern()
                {
                    ObjectType = "Select",
                    ObjectIdentifier = "MainContent_fmwOrder_ddlProduct"
                }, 7);
            }
        }

        public ITextEdit QuantityEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_txtQuantity"
                }, 7);
            }
        }

        public ITextEdit CustomerNameEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_txtName"
                }, 7);
            }
        }

        public ITextEdit AddressEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox2"
                }, 7);
            }
        }

        public ITextEdit CityEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox3"
                }, 7);
            }
        }

        public ITextEdit CountryEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox4"
                }, 7);
            }
        }

        public ITextEdit ZipEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox5"
                }, 7);
            }
        }

        public IRadioButton VisaCardButton
        {
            get
            {
                return _page.Find<IRadioButton>(new WebElementPattern()
                {
                    ObjectType = "RadioButton",
                    ObjectIdentifier = "MainContent_fmwOrder_cardList_0"
                }, 9);
            }
        }

        public IRadioButton MasterCardRadio
        {
            get
            {
                return _page.Find<IRadioButton>(new WebElementPattern()
                {
                    ObjectType = "RadioButton",
                    ObjectIdentifier = "MainContent_fmwOrder_cardList_1"
                }, 9);
            }
        }

        public IRadioButton AmericanExpressCardRadio
        {
            get
            {
                return _page.Find<IRadioButton>(new WebElementPattern()
                {
                    ObjectType = "RadioButton",
                    ObjectIdentifier = "MainContent_fmwOrder_cardList_2"
                }, 9);
            }
        }

        public ITextEdit CardNumber
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox6"
                }, 7);
            }
        }

        public ITextEdit DateEdit
        {
            get
            {
                return _page.Find<ITextEdit>(new WebElementPattern()
                {
                    ObjectType = "Textbox",
                    ObjectIdentifier = "MainContent_fmwOrder_TextBox1"
                }, 7);
            }
        }

        public IWebElement InsertLink
        {
            get
            {
                return _page.Find<IWebElement>(new WebElementPattern()
                {
                    ObjectType = "Link",
                    ObjectIdentifier = "MainContent_fmwOrder_InsertButton"
                }, 8);
            }
        }
    }


    class OrdersPageModel
    {
        private IWebPage _page;

        public OrdersPageModel(IWebPage page)
        {
            _page = page;
        }

        public IWebTable OrdersTable
        {
            get
            {
                return _page.Find<IWebTable>(new WebElementPattern()
                {
                    ObjectType = "Table",
                    ObjectIdentifier = "MainContent_orderGrid"
                }, 7);
            }
        }
    }


    class WebOrdersAppModel
    {
        private IWebBrowser _browser;

        public WebOrdersAppModel(IWebBrowser browser)
        {
            _browser = browser;
        }

        public LoginPageModel LoginPage
        {
            get
            {
                return new LoginPageModel(_browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/login.aspx"
                }));
            }
        }

        public NewOrderPageModel NewOrderPage
        {
            get
            {
                return new NewOrderPageModel(_browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/Process.aspx",
                    Visible = true
                }));
            }
        }

        public OrdersPageModel OrdersPage
        {
            get
            {
                return new OrdersPageModel(_browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/Default.aspx",
                    Visible = true
                }));
            }
        }

        public IWebElement ViewAllOrdersLink
        {
            get
            {
                return _browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/*.aspx",
                    Visible = true
                }).Find<IWebElement>(new WebElementPattern()
                {
                    ObjectType = "Link",
                    contentText = "View all orders"
                }, 4);
            }
        }

        public IWebElement ViewAllProductsLink
        {
            get
            {
                return _browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/*.aspx",
                    Visible = true
                }).Find<IWebElement>(new WebElementPattern()
                {
                    ObjectType = "Link",
                    contentText = "View all products"
                }, 4);
            }
        }

        public IWebElement OrderLink
        {
            get
            {
                return _browser.Find<IWebPage>(new WebPagePattern()
                {
                    URL = "*/WebOrders/*.aspx",
                    Visible = true
                }).Find<IWebElement>(new WebElementPattern()
                {
                    ObjectType = "Link",
                    contentText = "Order"
                }, 4);
            }
        }
    }
}
